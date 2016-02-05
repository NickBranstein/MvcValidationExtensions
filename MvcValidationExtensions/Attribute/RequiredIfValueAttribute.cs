using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;

namespace MvcValidationExtensions.Attribute
{
    public class RequiredIfValueAttribute : RequiredAttribute, IClientValidatable
    {
        protected string OtherValue { get; private set; }
        protected string OtherProperty { get; private set; }
        private const string UnknownProperty = "The property {0} could not be found.";

        public RequiredIfValueAttribute(string otherProperty, string otherValue)
        {
            if (string.IsNullOrWhiteSpace(otherProperty) || string.IsNullOrWhiteSpace(otherValue))
            {
                throw new ArgumentNullException($"{nameof(otherProperty)} and {nameof(otherValue)} cannot but null or empty.");
            }

            OtherValue = otherValue;
            OtherProperty = otherProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);

            if (otherPropertyInfo == null)
            {
                return new ValidationResult(string.Format(CultureInfo.CurrentCulture, UnknownProperty, OtherProperty));
            }

            var otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance);

            return base.IsValid(otherPropertyValue) && OtherValue == otherPropertyValue.ToString()
                ? base.IsValid(value) ? ValidationResult.Success : new ValidationResult(FormatErrorMessage(validationContext.DisplayName))
                : ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var result = new ModelClientValidationRule()
            {
                ValidationType = GetType().Name.Replace("Attribute", "").ToLower(),
                ErrorMessage = FormatErrorMessage(metadata.DisplayName ?? metadata.PropertyName)
            };

            result.ValidationParameters.Add("otherproperty", OtherProperty);
            result.ValidationParameters.Add("othervalue", OtherValue);

            yield return result;
        }
    }
}
