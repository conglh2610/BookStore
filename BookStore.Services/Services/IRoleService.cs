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
    public interface IRoleService : IRepository<Role>
    {
        int GetRoleIdByRoleType(string strRoleType);
    }
}
