using MvcValidationExtensions.Enum;

namespace MvcValidationExtensions.Attribute
{
    public class LessThanEqualToAttribute : ComparativeValidationAttribute
    {
        public LessThanEqualToAttribute(string otherProperty) : base(otherProperty, Comparison.LessThanEqualTo)
        {
        }
    }
}
