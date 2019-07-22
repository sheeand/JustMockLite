using LOBCode;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Telerik.JustMock;

namespace JustMockLite.C_Arguments
{
    [TestFixture]
    public class LoginTestsArguments
    {
        string _username = "Bob";
        string _password = "password";

        [Test]
        public void Login_HavingExactlyMatchedArgs_ShouldPass()
        {

            var service = Mock.Create<IUserValidation>();
            Mock.Arrange(() => service.ValidateUser(_username, _password)).Returns(true);
            var sut = new Login(service);
            var result = sut.VerifyUser(_username, _password);
            Assert.IsTrue(result);
        }

        [Test]
        public void Login_HavingMismatchingArgs_ShouldFail()
        {
            var service = Mock.Create<IUserValidation>();
            Mock.Arrange(() => service.ValidateUser(_username, _password)).Returns(true);
            var sut = new Login(service);
            var result = sut.VerifyUser(_username + "s", _password);
            Assert.IsFalse(result);
        }

        // Good placeholder (stub) test here!
        [Test]
        public void Login_IgnoringAllArgs_ShouldPass()
        {
            var service = Mock.Create<IUserValidation>();
            Mock.Arrange(() => service.ValidateUser("", ""))
                .IgnoreArguments()
                .Returns(true);
            var sut = new Login(service);
            var result = sut.VerifyUser(_username + "s", _password);
            Assert.IsTrue(result);
        }

        [Test]
        public void Login_IgnoringOneArg_ShouldPass()
        {
            var service = Mock.Create<IUserValidation>();
            //Mock.Arrange(() => service.ValidateUser(Arg.AnyString, ""))
            //    .IgnoreArguments()
            //    .Returns(true);
            Mock.Arrange(() => service.ValidateUser(Arg.IsAny<string>(), ""))
                .IgnoreArguments()
                .Returns(true);
            var sut = new Login(service);
            var result = sut.VerifyUser(_username + "s", _password);
            Assert.IsTrue(result);
        }

        [Test]
        public void Login_ArgsWithinAcceptedRange_ShouldPass()
        {
            var service = Mock.Create<IUserValidation>();
            Mock.Arrange(() => service
            .ValidateUser(
                Arg.IsInRange<string>("Bob","Larry", RangeKind.Inclusive), _password))
                .Returns(true);
            var sut = new Login(service);
            var result = sut.VerifyUser(_username + "s", _password);
            Assert.IsTrue(result);
        }

        [Test]
        public void Login_ArgLengthUsingLambda_ShouldPass()
        {
            var service = Mock.Create<IUserValidation>();
            Mock.Arrange(() => service.ValidateUser(Arg.Matches<string>(arg => arg.Length <= 4), _password)).Returns(true);
            var sut = new Login(service);
            var result = sut.VerifyUser(_username + "s", _password);
            Assert.IsTrue(result);
        }
        [Test]
        public void Login_ArgLengthUsingPredicate_ShouldPass()
        {
            var service = Mock.Create<IUserValidation>();
            Mock.Arrange(() => service.ValidateUser(Arg.Matches<string>(arg => CheckName(arg)), _password)).Returns(true);
            var sut = new Login(service);
            var result = sut.VerifyUser(_username + "s", _password);
            Assert.IsTrue(result);
        }

        private bool CheckName(string arg)
        {
            return (arg.Length <= 4);
        }
    }
}
