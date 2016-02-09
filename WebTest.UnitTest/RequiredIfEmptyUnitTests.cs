using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using WebTest.Factory;

namespace WebTest.UnitTest
{
    [TestClass]
    public class RequiredIfEmptyUnitTests
    {
        [TestMethod]
        public void RequiredIfEmptyShouldBeValidIfWhitespace()
        {
            ValidationHelper.ValidateModel(ModelFactory.RequiredIfEmptyModels.ValidWhitespaceModel).Any().ShouldBeFalse();
        }

        [TestMethod]
        public void RequiredIfEmptyShouldBeValidIfEmpty()
        {
            ValidationHelper.ValidateModel(ModelFactory.RequiredIfEmptyModels.ValidEmptyStringModel).Any().ShouldBeFalse();
        }

        [TestMethod]
        public void RequiredIfEmptyShouldBeValidIfNull()
        {
            ValidationHelper.ValidateModel(ModelFactory.RequiredIfEmptyModels.ValidNullModel).Any().ShouldBeFalse();
        }

        [TestMethod]
        public void RequiredIfEmptyShouldBeInvalidIfWhitespace()
        {
            ValidationHelper.ValidateModel(ModelFactory.RequiredIfEmptyModels.InvalidWhitespaceModel).Count().ShouldBe(1);
        }

        [TestMethod]
        public void RequiredIfEmptyShouldBeInvalidIfEmpty()
        {
            ValidationHelper.ValidateModel(ModelFactory.RequiredIfEmptyModels.InvalidEmptyStringModel).Count().ShouldBe(1);
        }

        [TestMethod]
        public void RequiredIfEmptyShouldBeInvalidIfNull()
        {
            ValidationHelper.ValidateModel(ModelFactory.RequiredIfEmptyModels.InvalidNullModel).Count().ShouldBe(1);
        }
    }
}
