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
    public class AuthorService : Repository<Author>, IAuthorService
    {
        BookStoreDB _dbContext = null;
        public AuthorService(BookStoreDB dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
