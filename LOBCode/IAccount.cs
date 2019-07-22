using System;
using System.Collections.Generic;
using System.Text;

namespace LOBCode
{
    public interface IAccount
    {
        void Deposit(decimal transferAmount);
        void Withdraw(decimal transferAmount);
    }
}
