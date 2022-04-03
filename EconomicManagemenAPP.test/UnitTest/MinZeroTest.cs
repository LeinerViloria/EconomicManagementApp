using EconomicManagementAPP.Validations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;

namespace EconomicManagementAPP.test
{
    [TestClass]
    public class MinZeroTest
    {
        [TestMethod]
        public void NegaviteNumber_ReturnError()
        {
            var minZero = new MinZero();
            var data = -9;

            var context = new ValidationContext(new { Money = data });

            var testResult = minZero.GetValidationResult(data, context);

            Assert.AreEqual("The balance must be equals or greater than zero", testResult?.ErrorMessage);
        }

        [TestMethod]
        public void InsertLetters_ReturnError()
        {
            var minZero = new MinZero();
            var data = "4pokv78";

            var context = new ValidationContext(new { Money = data });

            var testResult = minZero.GetValidationResult(data, context);

            Assert.AreEqual("The balance must be a decimal", testResult?.ErrorMessage);
        }

        [TestMethod]
        public void InsertNull_ReturnSuccess()
        {
            var minZero = new MinZero();
            var data = "";

            var context = new ValidationContext(new { Money = data });

            var testResult = minZero.GetValidationResult(data, context);

            Assert.AreEqual("The balance must be a decimal", testResult?.ErrorMessage);
        }
    }
}
