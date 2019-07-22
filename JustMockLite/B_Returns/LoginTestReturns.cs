using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Telerik.JustMock;
using JustMockLite.A_Creation;
using LOBCode;

namespace JustMockLite.B_Returns
{
    [TestFixture]
    class LoginTestReturns
    {
        string _userName = "Bob";
        string _password = "goflyakite";

        [Test]
        public void Login_ShouldReturnSingleValue_IsTrue()
        {
            var service = Mock.Create<IUserValidation>();

            Mock.Arrange(() =>
                service.ValidateUser(_userName, _password))
                .Returns(true);
            var sut = new Login(service);
            var result = sut.VerifyUser(_userName, _password);
            Assert.IsTrue(result);
        }

        [Test]
        public void Login_ShouldValuesBasedOnArguments_IsTrue()
        {
            var service = Mock.Create<IUserValidation>();
            Mock.Arrange(() => service.GetFullName(_userName, _password)).Returns((string arg1, string arg2) => arg1 + arg2);
            var sut = new Login(service);
            var result = sut.GetUserName(_userName, _password);
            Assert.AreEqual(_userName + _password, result);
        }

        [Test]
        public void Login_ShouldReturnAList_IsTrue()
        {
            var service = Mock.Create<IUserValidation>();
            var intsList = new List<int> { 1, 2, 3, 4 };
            Mock.Arrange(() => service.GetAccounts(_userName, _password)).Returns(intsList);
            var sut = new Login(service);
            IList<int> result = sut.GetUserAccounts(_userName, _password);
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(intsList[2], result[2]);
        }

    }
}
