using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcValidationExtensions.Attribute
{
    public class RequiredIfAnyValueAttribute : RequiredAttribute, IClientValidatable
    {
        protected string[] OtherValues { get; private set; }
        protected string OtherProperty { get; private set; }
        private const string UnknownProperty = "The property {0} could not be found.";

        public RequiredIfAnyValueAttribute(string otherProperty, string[] otherValues)
        {
            OtherValues = otherValues;
            OtherProperty = otherProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);

            if (otherPropertyInfo == null)
            {
                return new ValidationResult(String.Format(CultureInfo.CurrentCulture, UnknownProperty, OtherProperty));
            }

            var otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance);

            return base.IsValid(otherPropertyValue) && OtherValues.Any(val => val == otherPropertyValue.ToString())
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
            result.ValidationParameters.Add("othervalue", Json.Encode(OtherValues));

            yield return result;
        }
    }
}
