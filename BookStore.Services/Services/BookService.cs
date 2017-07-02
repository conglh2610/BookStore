using BookStore.Model.Generated;
using BookStore.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Services.Services
{
    public class BookService : Repository<Book>, IBookService
    {
        private readonly BookStoreDB _dbContext;
        public BookService(BookStoreDB dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Book> SearchBook(string strFilter, string strYear, int intAuthorId, int intCategoryId)
        {
            return _dbContext.Book.Where(t => (t.Title.Contains(strFilter)
                                               || t.Description.Contains(strFilter))
                                              && (string.IsNullOrEmpty(strYear)
                                                  || t.Year.ToString() == strYear)
                                              && (intAuthorId < 1
                                                  || t.AuthorId == intAuthorId)
                                              && (intCategoryId < 1
                                                  || t.CategoryId == intCategoryId)).ToList();
        }
   
    }
}
