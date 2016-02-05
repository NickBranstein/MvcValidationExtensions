using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebTest.UnitTest
{
    public static class ValidationHelper
    {
        public static IEnumerable<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}
