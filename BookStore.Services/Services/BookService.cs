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
    public class BookService : Repository<Book>, IBookService
    {
        BookStoreDB _dbContext = null;
        public BookService(BookStoreDB dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
