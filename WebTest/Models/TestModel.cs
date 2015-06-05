using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MvcValidationExtensions.Attribute;

namespace WebTest.Models
{
    public class TestModel
    {
        [RequiredIf("RequiredIntControl")]
        public int? SomeIntThatMightBeRequired { get; set; }

        [RequiredIfValue("RequiredIntControl", "15")]
        public int? SomeRequiredIfValue { get; set; }

        public string RequiredIntControl { get; set; }

        [RequiredIfAnyValue("RequiredIfAnyValueControl", new []{"ValOne", "ValTwo", "ValThree"})]
        public int? RequiredIfAnyValue { get; set; }
        public string RequiredIfAnyValueControl { get; set; }

        [DisplayName("> Hidden Int")]
        [GreaterThan("HiddentInt")]
        public int? SomeValue { get; set; }

        [Required]
        [GreaterThan("SomeValue", ErrorMessage = "Overriding the error message.")]
        public int? RequiredInt { get; set; }

        [Required]
        [DisplayName("< Date")]
        [LessThan("SomeOtherDate")]
        public DateTime? SomeDate { get; set; }

        [DisplayName("<= Some Other Date")]
        [LessThanEqualTo("HiddenDateTime")]
        public DateTime? SomeOtherDate { get; set; }

        [DisplayName(">= Kendo Date")]
        [GreaterThanEqualTo("KendoDateOther")]
        public DateTime? KendoDate { get; set; }

        public int? HiddentInt { get; set; }
        public DateTime? HiddenDateTime { get; set; }
        public DateTime? KendoDateOther { get; set; }
    }
}