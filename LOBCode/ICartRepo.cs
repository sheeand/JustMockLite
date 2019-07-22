using System;
using System.Collections.Generic;
using System.Text;

namespace LOBCode
{
    public interface ICartRepo
    {
        IList<T> GetCartItems<T>(T userID);
        IList<string> LoadCart(string userName);
        void AddItem(string s);
    }
}
