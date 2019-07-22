using LOBCode;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Telerik.JustMock;

namespace JustMockLite.D_Behavior
{
    [TestFixture]
    class LoginTestBehaviorInAssertion
    {
        string _userName = "Bob";
        string _password = "qwerty";
        [Test]
        public void Login_MethodGetsCalledOnce_ShouldReturnTrue()
        {
            // Arrange
            var validationService = Mock.Create<IUserValidation>();
            var repo = Mock.Create<ICartRepo>();
            Mock.Arrange(() => validationService.ValidateUser(_userName, _password)).Returns(true);
            Mock.Arrange(() => repo.LoadCart(_userName)).Returns(new List<string> { "1", "2", "3", "4" });

            // Act
            var sut = new Login2(validationService, repo);
            var result = sut.VerifyUser(_userName, _password);

            // Assert
            Mock.Assert(() => validationService.ValidateUser(_userName, _password), Occurs.Once());
            Mock.Assert(() => repo.LoadCart(_userName), Occurs.Exactly(1));
        }

        [Test]
        public void Login_MethodDoesntGetCalledOnce_ShouldReturnFalse()
        {
            // Arrange
            var validationService = Mock.Create<IUserValidation>();
            var repo = Mock.Create<ICartRepo>();
            Mock.Arrange(() => validationService.ValidateUser(_userName, _password)).Returns(false);
            Mock.Arrange(() => repo.LoadCart(_userName)).Returns(new List<string> { "1", "2", "3", "4" });

            // Act
            var sut = new Login2(validationService, repo);
            var result = sut.VerifyUser(_userName, _password);

            // Assert
            Mock.Assert(() => validationService.ValidateUser(_userName, _password), Occurs.Once());
            Mock.Assert(() => repo.LoadCart(_userName), Occurs.Exactly(0));
        }

    }
}
