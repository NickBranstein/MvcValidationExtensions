using MvcValidationExtensions.Enum;

namespace MvcValidationExtensions.Attribute
{
    public class GreaterThanEqualToAttribute : ComparativeValidationAttribute
    {
        public GreaterThanEqualToAttribute(string otherProperty) : base(otherProperty, Comparison.GreaterThanEqualTo)
        {
        }
    }
}
