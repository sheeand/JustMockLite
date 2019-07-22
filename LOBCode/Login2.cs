using LOBCode;
using System;
using System.Collections.Generic;

namespace LOBCode
{
    public class Login2
    {
        // UserValidationService _service;

        private IUserValidation _service;
        private ICartRepo _repo;

        public Login2(IUserValidation service,ICartRepo repo)
        {
            _service = service;
            _repo = repo;
        }

        public bool Login2User(string username, string password)
        {
            return _service.ValidateUser(username, password);
        }

        public IList<int> GetUserAccounts(string userName, string password)
        {
            return _service.GetAccounts(userName, password);
        }

        public string GetUserName(string userName, string password)
        {
            return _service.GetFullName(userName, password);
        }

        public IList<T> GetCartItems<T>(T param)
        {
            return _repo.GetCartItems<T>(param);
        }

        public bool VerifyUser(string username, string password)
        {
            var result = _service.ValidateUser(username, password);
            if (result)
            {
                if (_repo != null)
                {
                    var cart = _repo.LoadCart(username);
                }
            }
            return result;
        }
    }
}