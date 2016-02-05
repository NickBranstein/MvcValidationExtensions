using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using MvcValidationExtensions.Enum;

namespace MvcValidationExtensions.Attribute
{
    public abstract class ComparativeValidationAttribute : ValidationAttribute, IClientValidatable
    {
        protected string OtherProperty { get; private set; }
        protected string OtherPropertyDisplayName { get; private set; }
        protected Comparison Comparison { get; private set; }
        private const string UnknownProperty = "The property {0} could not be found.";

        protected ComparativeValidationAttribute(string otherProperty, Comparison comparison)
        {
            if (otherProperty == null)
            {
                throw new ArgumentNullException($"{nameof(otherProperty)} cannot be null or empty.");
            }

            OtherProperty = otherProperty;
            Comparison = comparison;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessage ?? GetErrorMessageStringFormat(), name, OtherPropertyDisplayName ?? OtherProperty);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);

            if (otherPropertyInfo == null)
            {
                return new ValidationResult(String.Format(CultureInfo.CurrentCulture, UnknownProperty, OtherProperty));
            }

            var otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance);

            if (value is IComparable && otherPropertyValue is IComparable && IsComparisonTrue((IComparable)value, (IComparable)(otherPropertyValue), Comparison))
            {
                return ValidationResult.Success;
            }

            if (OtherPropertyDisplayName == null)
            {
                OtherPropertyDisplayName = GetDisplayNameForProperty(validationContext.ObjectType, OtherProperty);
            }

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        private static string GetDisplayNameForProperty(Type containerType, string propertyName)
        {
            ICustomTypeDescriptor typeDescriptor = GetTypeDescriptor(containerType);
            PropertyDescriptor property = typeDescriptor.GetProperties().Find(propertyName, true);
            if (property == null)
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, UnknownProperty, propertyName));
            }
            IEnumerable<System.Attribute> attributes = property.Attributes.Cast<System.Attribute>();
            DisplayAttribute display = attributes.OfType<DisplayAttribute>().FirstOrDefault();
            if (display != null)
            {
                return display.GetName();
            }
            DisplayNameAttribute displayName = attributes.OfType<DisplayNameAttribute>().FirstOrDefault();
            if (displayName != null)
            {
                return displayName.DisplayName;
            }
            return propertyName;
        }

        private static ICustomTypeDescriptor GetTypeDescriptor(Type type)
        {
            return new AssociatedMetadataTypeTypeDescriptionProvider(type).GetTypeDescriptor(type);
        }

        private static bool IsComparisonTrue(IComparable value, IComparable otherValue, Comparison comparison)
        {
            switch (comparison)
            {
                case Comparison.GreaterThan:
                    return value.CompareTo(otherValue) > 0;
                case Comparison.GreaterThanEqualTo:
                    return value.CompareTo(otherValue) > 0 || value.CompareTo(otherValue) == 0;
                case Comparison.LessThan:
                    return value.CompareTo(otherValue) < 0;
                case Comparison.LessThanEqualTo:
                    return value.CompareTo(otherValue) < 0 || value.CompareTo(otherValue) == 0;
                default:
                    return false;
            }
        }

        private string GetErrorMessageStringFormat()
        {
            var message = "{0} must be comparison {1}";

            switch (Comparison)
            {
                case Comparison.GreaterThan:
                    message = message.Replace("comparison", "greater than");
                    break;
                case Comparison.GreaterThanEqualTo:
                    message = message.Replace("comparison", "greater than or equal to");
                    break;
                case Comparison.LessThan:
                    message = message.Replace("comparison", "less than");
                    break;
                case Comparison.LessThanEqualTo:
                    message = message.Replace("comparison", "less than or equal to");
                    break;
                default:
                    message = "Unknown comparison type.";
                    break;
            }

            return message;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var result = new ModelClientValidationRule()
            {
                ValidationType =  GetType().Name.Replace("Attribute", "").ToLower(),
                ErrorMessage = FormatErrorMessage(metadata.DisplayName ?? metadata.PropertyName)
            };

            result.ValidationParameters.Add("otherproperty", OtherProperty);

            yield return result;
        }
    }
}
