using LOBCode;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace JustMockLite.I_Exceptions
{
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void Transfer_Failed_ShouldThrowException()
        {
            decimal transferAmount = 100M;
            var fromAccount = Mock.Create<IAccount>();
            var toAccount = Mock.Create<IAccount>();

            // The exception will not get thrown unless the arrangement gets executed
            fromAccount.Arrange(x => x.Withdraw(transferAmount)).Throws<ArgumentException>();

            var sut = new AccountTransaction(fromAccount, toAccount);
            Assert.Throws<ArgumentException>(() => sut.TransferFunds(transferAmount));
        }
    }
}
