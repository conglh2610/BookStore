using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public class Deletgates
    {
        public delegate void AddItemDelegate(string strValue);
        public delegate void UserResitryDelegate(string strEmail, string strPassword);
    }
}
