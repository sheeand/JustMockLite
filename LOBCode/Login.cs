using LOBCode;
using System;
using System.Collections.Generic;

namespace LOBCode
{
    public class Login
    {
        private IUserValidation _service;
        private string server;

        // Constructor
        public Login(IUserValidation service)  // Dependency injection
        {
            // Every instance of Login() will have IUserValidation at its disposal
            _service = service;
        }

        public bool LoginUser(string username, string password)
        {
            return _service.ValidateUser(username, password);
        }

        public IList<int> GetUserAccounts(string userName, string password)
        {
            return _service.GetAccounts(userName, password);
        }

        public string GetServer()
        {
            return _service.Server;
        }

        public string GetUserName(string userName, string password)
        {
            return _service.GetFullName(userName, password);
        }

        public void SetServer(string server)
        {
            _service.Server = server;
        }

        public bool VerifyUser(string username, string password)
        {
            var result = _service.ValidateUser(username, password);
            return result;
        }

    }
}