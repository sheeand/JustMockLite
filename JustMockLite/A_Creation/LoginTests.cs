using System;
using NUnit.Framework;
using JustMockLite.A_Creation;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;
using LOBCode;

namespace JustMockLite.A_Creation
{
    [TestFixture]
    public class LoginTests
    {

        [Test]
        public void ShouldVerifyUserCredentials()
        {
            var service = Mock.Create<IUserValidation>();
            string username = "Bob";
            string password = "goflyakite";
            bool result = false;
            Mock.Arrange(() =>
                service.ValidateUser(username, password))
                .Returns(true);
            var sut = new Login(service); // passsing the service in as DI
            result = sut.LoginUser(username, password);
            Assert.IsTrue(result);

        }
    }
}