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
    public class CategoryService : Repository<Category>, ICategoryService, IDisposable
    {
        BookStoreDB _dbContext = null;
        public CategoryService(BookStoreDB dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Category> SearchCategory(string strText)
        {
            return _dbContext.Category.Where(t => t.Title.Contains(strText) || t.Description.Contains(strText)).AsEnumerable();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
