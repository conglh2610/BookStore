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
    public class RoleService : Repository<Role>, IRoleService, IDisposable
    {
        BookStoreDB _dbContext = null;
        public RoleService(BookStoreDB dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// get Role Id By Role Type
        /// </summary>
        /// <param name="strRoleType"></param>
        /// <returns>
        /// </returns>
        public int GetRoleIdByRoleType(string strRoleType)
        {
            var response = 0;
            var role = _dbContext.Role.FirstOrDefault(t => t.RoleType == strRoleType);
            if (role != null)
            {
                response = role.Id;
            }
            return response;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
