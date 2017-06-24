using BookStore.Model;
using BookStore.Model.Generated;
using BookStore.Services.Repository;
using BookStote.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Services
{
    public class UserService : Repository<User>, IUserService
    {
        BookStoreDB _dbContext = null;
        public UserService(BookStoreDB dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// get login by Email and Password
        /// </summary>
        /// <param name="strEmail"></param>
        /// <param name="strPassword"></param>
        /// <returns>
        /// null: Email or Password is not correct.
        /// User Info: Existing User. 
        /// </returns>
        public User GetLogin(string strEmail, string strPassword)
        {
            var pwHashed = StringHelpers.EncryptLoginPassword(strPassword, "SHA1");
            return _dbContext.User.FirstOrDefault(t => t.Email == strEmail && t.Password == pwHashed);
        }

        /// <summary>
        /// Get User by Email
        /// </summary>
        /// <param name="strEmail"></param>
        /// <returns></returns>
        public User GetUserByEmail(string strEmail)
        {
            return _dbContext.User.FirstOrDefault(t => t.Email == strEmail);
        }
    }
}
