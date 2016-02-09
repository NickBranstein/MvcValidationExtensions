using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using WebTest.Factory;

namespace WebTest.UnitTest
{
    [TestClass]
    public class ValidationAttributeUnitTest
    {
        [TestMethod]
        public void CheckForValidModel()
        {
            ValidationHelper.ValidateModel(ModelFactory.ValidTestModel).Any().ShouldBeFalse();
        }

        [TestMethod]
        public void GreaterThanIntValidationTest()
        {
            ValidationHelper.ValidateModel(ModelFactory.InvalidGreaterThanIntModel).Count().ShouldBe(1);
        }

        [TestMethod]
        public void LessThanDateValidationTest()
        {
            ValidationHelper.ValidateModel(ModelFactory.InvalidLessThanDateModel).Count().ShouldBe(1);
        }

        [TestMethod]
        public void LessThanEqualToDateValidationTest()
        {
            ValidationHelper.ValidateModel(ModelFactory.InvalidLessThanEqualToDateModel).Count().ShouldBe(1);
        }

        [TestMethod]
        public void GreaterThanEqualToDateValidationTest()
        {
            ValidationHelper.ValidateModel(ModelFactory.InvalidGreaterThanEqualToDateModel).Count().ShouldBe(1);
        }

        [TestMethod]
        public void ValidRequiredIfValueValidationTest()
        {
            ValidationHelper.ValidateModel(ModelFactory.ValidRequiredIfValueModel).Any().ShouldBeFalse();
        }

        [TestMethod]
        public void InvalidRequiredIfValueValidationTest()
        {
           ValidationHelper.ValidateModel(ModelFactory.InvalidRequiredIfValueModel).Count().ShouldBe(1);
        }

        [TestMethod]
        public void ValidRequiredIfAnyValueValidationTest()
        {
            ValidationHelper.ValidateModel(ModelFactory.ValidRequiredIfAnyValuesModel).Any().ShouldBeFalse();
        }

        [TestMethod]
        public void InvalidRequiredIfAnyValueValidationTest()
        {
            ValidationHelper.ValidateModel(ModelFactory.InvalidRequiredIfAnyValuesModel).Count().ShouldBe(1);
        }
    }
}
