using System;
using System.Collections.Generic;
using System.Text;

namespace LOBCode
{
    public interface IShoppingCart
    {
        IList<string> Items { get; set; }
    }
}
