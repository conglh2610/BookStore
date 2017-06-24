using BookStore.Model;
using BookStore.Model.Generated;
using BookStore.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Services
{
    public interface IUserService : IRepository<User>
    {
        User GetLogin(string strUserName, string strPassword);
        User GetUserByEmail(string strEmail);
    }
}
