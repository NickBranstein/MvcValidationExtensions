using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using WebTest.Factory;

namespace WebTest.UnitTest
{
    [TestClass]
    public class RequiredIfUnitTests
    {
        [TestMethod]
        public void RequiredIfModelShouldBeValid()
        {
            ValidationHelper.ValidateModel(ModelFactory.RequiredIfModels.ValidModel).Any().ShouldBeFalse();
        }

        [TestMethod]
        public void RequiredIfModelShouldBeInvalid()
        {
            ValidationHelper.ValidateModel(ModelFactory.RequiredIfModels.InvalidModel).Count().ShouldBe(1);
        }

        [TestMethod]
        public void RequiredIfModelShouldBeValidWithEmptyString()
        {
            ValidationHelper.ValidateModel(ModelFactory.RequiredIfModels.RequiredIfEmptyStringModel).Any().ShouldBeFalse();
        }

        [TestMethod]
        public void RequiredIfModelShouldBeValidWithWhitespaceString()
        {
            ValidationHelper.ValidateModel(ModelFactory.RequiredIfModels.RequiredIfWhitespaceModel).Any().ShouldBeFalse();
        }

        [TestMethod]
        public void RequiredIfModelShouldBeValidNullString()
        {
            ValidationHelper.ValidateModel(ModelFactory.RequiredIfModels.RequiredIfNullModel).Any().ShouldBeFalse();
        }
    }
}
