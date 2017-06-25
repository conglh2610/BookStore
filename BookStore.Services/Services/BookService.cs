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

        public IEnumerable<Book> SearchBook(string strFilter, string strYear, int intAuthorId, int intCategoryId)
        {
           return _dbContext.Book.Where(t => (t.Title.Contains(strFilter)
                                            || t.Description.Contains(strFilter))
                                    && (string.IsNullOrEmpty(strYear)
                                            || t.Year.ToString() == strYear)
                                    && (intAuthorId < 1
                                            || t.AuthorId == intAuthorId)
                                    && (intCategoryId < 1
                                            || t.CategoryId == intCategoryId));
        }
    }
}
