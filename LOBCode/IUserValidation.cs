using System;
using System.Collections.Generic;
using System.Text;

namespace LOBCode
{
    public interface IUserValidation
    {
        string Server { get; set; }
        IList<int> GetAccounts(string userName, string password);
        string GetFullName(string userName, string password);
        bool ValidateUser(string userName, string password);
    }
}
