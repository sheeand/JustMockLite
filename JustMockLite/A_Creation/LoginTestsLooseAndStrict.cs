using LOBCode;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Telerik.JustMock;
using Telerik.JustMock.Core;

namespace JustMockLite.A_Creation
{
    [TestFixture]
    public class LoginTestsLooseAndStrict
    {
        [Test]
        public void ShouldCreateLooseMock()
        {
            // This is the more traditional approach
            // Typically referred to as "stubs"
            var service = Mock.Create<IUserValidation>();
            var sut = new Login(service);
            string password = "goflyakite";
            string username = "Bob";
            var result = sut.VerifyUser(username, password);
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldCreateStrictMock()
        {
            // Protects against side effect calls
            // Improves code readability
            // Could be considered "overkill" 
            var service = Mock.Create<IUserValidation>(Behavior.Strict);
            var sut = new Login(service);
            string password = "goflyakite";
            string username = "Bob";
            Assert.Throws<StrictMockException>(() => sut.VerifyUser(username, password));
        }
    }
}
