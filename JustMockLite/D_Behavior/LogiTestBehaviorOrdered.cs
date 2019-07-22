using LOBCode;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Telerik.JustMock;

namespace JustMockLite.D_Behavior
{
    [TestFixture]
    public class LogiTestBehaviorOrdered
    {
        string _userName = "Bob";
        string _password = "qwerty";

        [Test]
        public void Login_MethodGetsCalledInOrder_ShouldReturnTrue()
        {
            // Arrange
            var validationService = Mock.Create<IUserValidation>();
            var repo = Mock.Create<ICartRepo>();

            // The logic in Login2.VerifyUser() needs to execute in the order that the following lines of code are placed
            // (Reversing the either the logic or these two lines of code will raise an error)
            Mock.Arrange(() => validationService.ValidateUser(_userName, _password)).Returns(true).InOrder().Occurs(1);
            Mock.Arrange(() => repo.LoadCart(_userName)).Returns(new List<string> { "1", "2", "3", "4" }).InOrder().OccursOnce();

            // Act
            var sut = new Login2(validationService, repo);
            var result = sut.VerifyUser(_userName, _password);

            // Assert
            Mock.Assert(() => validationService.ValidateUser(_userName, _password));
            Mock.Assert(() => repo.LoadCart(_userName));
        }
    }
}
