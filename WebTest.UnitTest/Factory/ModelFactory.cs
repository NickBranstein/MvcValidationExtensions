using System;
using WebTest.Models;

namespace WebTest.UnitTest.Factory
{
    public static class ModelFactory
    {
        public static TestModel ValidTestModel
        {
            get
            {
                return new TestModel()
                {
                    RequiredIntControl = "require Some int",
                    SomeIntThatMightBeRequired = 100,
                    SomeValue = 60,
                    RequiredInt = 61,
                    SomeOtherDate = DateTime.Today,
                    SomeDate = DateTime.Today.AddDays(-1.0),
                    HiddentInt = 55,
                    HiddenDateTime = DateTime.Today,
                    KendoDateOther = DateTime.Today,
                    KendoDate = DateTime.Today
                };
            }
        }

        public static TestModel InvalidGreaterThanIntModel
        {
            get
            {
                return new TestModel()
                {
                    RequiredIntControl = "require Some int",
                    SomeIntThatMightBeRequired = 100,
                    SomeValue = 55,
                    RequiredInt = 61,
                    SomeOtherDate = DateTime.Today,
                    SomeDate = DateTime.Today.AddDays(-1.0),
                    HiddentInt = 55,
                    HiddenDateTime = DateTime.Today,
                    KendoDateOther = DateTime.Today,
                    KendoDate = DateTime.Today
                };
            }
        }

        public static TestModel InvalidLessThanDateModel
        {
            get
            {
                return new TestModel()
                {
                    RequiredIntControl = "require Some int",
                    SomeIntThatMightBeRequired = 100,
                    SomeValue = 60,
                    RequiredInt = 61,
                    SomeOtherDate = DateTime.Today,
                    SomeDate = DateTime.Today,
                    HiddentInt = 55,
                    HiddenDateTime = DateTime.Today,
                    KendoDateOther = DateTime.Today,
                    KendoDate = DateTime.Today
                };
            }
        }

        public static TestModel InvalidLessThanEqualToDateModel
        {
            get
            {
                return new TestModel()
                {
                    RequiredIntControl = "require Some int",
                    SomeIntThatMightBeRequired = 100,
                    SomeValue = 60,
                    RequiredInt = 61,
                    SomeOtherDate = DateTime.Today.AddDays(1.0),
                    SomeDate = DateTime.Today.AddDays(-1.0),
                    HiddentInt = 55,
                    HiddenDateTime = DateTime.Today,
                    KendoDateOther = DateTime.Today,
                    KendoDate = DateTime.Today
                };
            }
        }

        public static TestModel InvalidGreaterThanEqualToDateModel
        {
            get
            {
                return new TestModel()
                {
                    RequiredIntControl = "require Some int",
                    SomeIntThatMightBeRequired = 100,
                    SomeValue = 60,
                    RequiredInt = 61,
                    SomeOtherDate = DateTime.Today,
                    SomeDate = DateTime.Today.AddDays(-1.0),
                    HiddentInt = 55,
                    HiddenDateTime = DateTime.Today,
                    KendoDateOther = DateTime.Today,
                    KendoDate = DateTime.Today.AddDays(-1.0)
                };
            }
        }

        public static TestModel ValidRequiredIfModel
        {
            get
            {
                return new TestModel()
                {
                    RequiredIntControl = null,
                    SomeIntThatMightBeRequired = null,
                    SomeValue = 60,
                    RequiredInt = 61,
                    SomeOtherDate = DateTime.Today,
                    SomeDate = DateTime.Today.AddDays(-1.0),
                    HiddentInt = 55,
                    HiddenDateTime = DateTime.Today,
                    KendoDateOther = DateTime.Today,
                    KendoDate = DateTime.Today
                };
            }
        }

        public static TestModel InvalidRequiredIfModel
        {
            get
            {
                return new TestModel()
                {
                    RequiredIntControl = "require Some int",
                    SomeIntThatMightBeRequired = null,
                    SomeValue = 60,
                    RequiredInt = 61,
                    SomeOtherDate = DateTime.Today,
                    SomeDate = DateTime.Today.AddDays(-1.0),
                    HiddentInt = 55,
                    HiddenDateTime = DateTime.Today,
                    KendoDateOther = DateTime.Today,
                    KendoDate = DateTime.Today
                };
            }
        }

        public static TestModel ValidRequiredIfValueModel
        {
            get
            {
                return new TestModel()
                {
                    RequiredIntControl = "15",
                    SomeIntThatMightBeRequired = 100,
                    SomeRequiredIfValue = 200,
                    SomeValue = 60,
                    RequiredInt = 61,
                    SomeOtherDate = DateTime.Today,
                    SomeDate = DateTime.Today.AddDays(-1.0),
                    HiddentInt = 55,
                    HiddenDateTime = DateTime.Today,
                    KendoDateOther = DateTime.Today,
                    KendoDate = DateTime.Today
                };
            }
        }

        public static TestModel InvalidRequiredIfValueModel
        {
            get
            {
                return new TestModel()
                {
                    RequiredIntControl = "15",
                    SomeIntThatMightBeRequired = null,
                    SomeRequiredIfValue = 200,
                    SomeValue = 60,
                    RequiredInt = 61,
                    SomeOtherDate = DateTime.Today,
                    SomeDate = DateTime.Today.AddDays(-1.0),
                    HiddentInt = 55,
                    HiddenDateTime = DateTime.Today,
                    KendoDateOther = DateTime.Today,
                    KendoDate = DateTime.Today
                };
            }
        }

        public static TestModel ValidRequiredIfAnyValuesModel
        {
            get
            {
                return new TestModel()
                {
                    RequiredIntControl = "15",
                    SomeIntThatMightBeRequired = 100,
                    SomeRequiredIfValue = 200,
                    SomeValue = 60,
                    RequiredInt = 61,
                    SomeOtherDate = DateTime.Today,
                    SomeDate = DateTime.Today.AddDays(-1.0),
                    HiddentInt = 55,
                    HiddenDateTime = DateTime.Today,
                    KendoDateOther = DateTime.Today,
                    KendoDate = DateTime.Today,
                    RequiredIfAnyValue = 15,
                    RequiredIfAnyValueControl = "ValTwo"
                };
            }
        }

        public static TestModel InvalidRequiredIfAnyValuesModel
        {
            get
            {
                return new TestModel()
                {
                    RequiredIntControl = "15",
                    SomeIntThatMightBeRequired = 100,
                    SomeRequiredIfValue = 200,
                    SomeValue = 60,
                    RequiredInt = 61,
                    SomeOtherDate = DateTime.Today,
                    SomeDate = DateTime.Today.AddDays(-1.0),
                    HiddentInt = 55,
                    HiddenDateTime = DateTime.Today,
                    KendoDateOther = DateTime.Today,
                    KendoDate = DateTime.Today,
                    RequiredIfAnyValueControl = "ValThree"
                };
            }
        }
    }
}
