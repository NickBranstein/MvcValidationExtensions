using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebTest.UnitTest.Factory;

namespace WebTest.UnitTest
{
    [TestClass]
    public class ValidationAttributeUnitTest
    {
        [TestMethod]
        public void CheckForValidModel()
        {
            Assert.IsTrue(!ValidateModel(ModelFactory.ValidTestModel).Any());
        }

        [TestMethod]
        public void GreaterThanIntValidationTest()
        {
            Assert.IsTrue(ValidateModel(ModelFactory.InvalidGreaterThanIntModel).Count() == 1);
        }

        [TestMethod]
        public void LessThanDateValidationTest()
        {
            Assert.IsTrue(ValidateModel(ModelFactory.InvalidLessThanDateModel).Count() == 1);
        }

        [TestMethod]
        public void LessThanEqualToDateValidationTest()
        {
            Assert.IsTrue(ValidateModel(ModelFactory.InvalidLessThanEqualToDateModel).Count() == 1);
        }

        [TestMethod]
        public void GreaterThanEqualToDateValidationTest()
        {
            Assert.IsTrue(ValidateModel(ModelFactory.InvalidGreaterThanEqualToDateModel).Count() == 1);
        }

        [TestMethod]
        public void ValidRequiredIfValidationTest()
        {
            Assert.IsTrue(!ValidateModel(ModelFactory.ValidRequiredIfModel).Any());
        }

        [TestMethod]
        public void InvalidRequiredIfValidationTest()
        {
            Assert.IsTrue(ValidateModel(ModelFactory.InvalidRequiredIfModel).Count() == 1);
        }

        [TestMethod]
        public void ValidRequiredIfValueValidationTest()
        {
            Assert.IsTrue(!ValidateModel(ModelFactory.ValidRequiredIfValueModel).Any());
        }

        [TestMethod]
        public void InvalidRequiredIfValueValidationTest()
        {
            Assert.IsTrue(ValidateModel(ModelFactory.InvalidRequiredIfValueModel).Count() == 1);
        }

        [TestMethod]
        public void ValidRequiredIfAnyValueValidationTest()
        {
            Assert.IsTrue(!ValidateModel(ModelFactory.ValidRequiredIfAnyValuesModel).Any());
        }

        [TestMethod]
        public void InvalidRequiredIfAnyValueValidationTest()
        {
            Assert.IsTrue(ValidateModel(ModelFactory.InvalidRequiredIfAnyValuesModel).Count() == 1);
        }

        private IEnumerable<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}
