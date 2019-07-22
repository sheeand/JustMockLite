using LOBCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustMockLite.A_Creation
{
    class FakeUserValidationService : IUserValidation
    {
        public string Server { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IList<int> GetAccounts(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public string GetFullName(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public bool ValidateUser(string username, string password)
        {
            return (username == "Bob" && password == "goflyakite");
        }

        public bool ValidateUserOutOfOrder(string username, string password)
        {
            return (username == "Bob" && password == "goflyakite");
        }
    }
}
