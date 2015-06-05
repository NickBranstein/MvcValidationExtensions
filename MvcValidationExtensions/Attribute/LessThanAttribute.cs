using MvcValidationExtensions.Enum;

namespace MvcValidationExtensions.Attribute
{
    public class LessThanAttribute : ComparativeValidationAttribute
    {
        public LessThanAttribute(string otherProperty) : base(otherProperty, Comparison.LessThan)
        {
        }
    }
}
