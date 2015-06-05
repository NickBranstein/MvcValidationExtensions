using MvcValidationExtensions.Enum;

namespace MvcValidationExtensions.Attribute
{
    public class GreaterThanAttribute : ComparativeValidationAttribute
    {
        public GreaterThanAttribute(string otherProperty) : base(otherProperty, Comparison.GreaterThan) { }
    }
}
