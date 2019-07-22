using System;
using System.Collections.Generic;
using System.Text;

namespace LOBCode
{
    public class AccountTransaction
    {
        private IAccount _fromAccount;
        private IAccount _toAccount;

        public AccountTransaction(IAccount fromAccount, IAccount toAccount)
        {
            this._fromAccount = fromAccount;
            this._toAccount = toAccount;
        }

        public void TransferFunds(decimal transferAmount)
        {
            //TODO: Add logic here
            _fromAccount.Withdraw(transferAmount);
            _toAccount.Deposit(transferAmount);
        }
    }
}
