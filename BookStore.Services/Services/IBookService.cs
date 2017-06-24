using BookStore.Model;
using BookStore.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using BookStore.Model.Generated;

namespace BookStore.Services.Services
{
    public interface IBookService : IRepository<Book>
    {

    }
}
