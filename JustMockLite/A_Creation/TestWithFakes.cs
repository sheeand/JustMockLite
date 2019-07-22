using LOBCode;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustMockLite.A_Creation
{
    [TestFixture]
    class TestWithFakes
    {
        [Test]
        public void ShouldLoginUser()
        {
            var username = "Bob";
            var password = "goflyakite";
            var sut = new Login(new FakeUserValidationService());

            var result = sut.VerifyUser(username, password);

            Assert.IsTrue(result);
        }
    }
}
