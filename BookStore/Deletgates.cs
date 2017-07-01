using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public class Deletgates
    {
        public delegate void AddUpdateItemDelegate();
        public delegate void UserResitryDelegate(string strEmail, string strPassword);
    }
}
