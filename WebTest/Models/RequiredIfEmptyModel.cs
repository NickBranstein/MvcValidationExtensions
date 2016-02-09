using MvcValidationExtensions.Attribute;

namespace WebTest.Models
{
    public class RequiredIfEmptyModel 
    {
        public string RequiredIfEmptyControl { get; set; }

        [RequiredIfEmpty("RequiredIfEmptyControl")]
        public int? MightBeRequired { get; set; }
    }
}