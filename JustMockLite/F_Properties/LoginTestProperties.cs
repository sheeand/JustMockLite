using LOBCode;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace JustMockLite.F_Properties
{
    class LoginTestProperties
    {
        string server = "myserver";

        [Test]
        public void Login_GettingTheProperty_ShouldPass()
        {
            var service = Mock.Create<IUserValidation>();

            // Arrange
            service.Arrange(x => x.Server).Returns(server);
            var sut = new Login(service);

            // Act
            var result = sut.GetServer();

            // Assert
            Assert.AreEqual(server, result);
        }

        [Test]
        public void Login_SettingTheProperty_ShouldPass()
        {
            var service = Mock.Create<IUserValidation>();

            // Arrange
            service.ArrangeSet(x => x.Server = server).MustBeCalled(server);
            var sut = new Login(service);

            // Act
            sut.SetServer(server);

            // Assert
            service.Assert();
        }

        [Test]
        public void Login_SettingThePropertyWithStrickMock_ShouldPass()
        {
            var service = Mock.Create<IUserValidation>(Behavior.Strict);

            // Arrange
            service.ArrangeSet(x => x.Server = server);
            var sut = new Login(service);

            // Act
            sut.SetServer(server);

            // Assert
            service.Assert();
        }

    }
}
