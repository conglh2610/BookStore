using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookStore.Model.Generated;
using BookStore.Services.Services;

namespace BookStore.UnitTest
{
   
    [TestClass]
    public class BookServiceTest
    {
        private static List<Book> _booksTest;
        private static BookStoreDB _db;
        private static BookService _bookService;
        private static AuthorService _authorService;
        private static CategoryService _categoryService;

        private Book _bookForAdd1;

        [ClassInitialize]
        public static void BookUnitTest(TestContext context)
        {
            _db = new BookStoreDB();
            _booksTest = new List<Book>();
            _bookService = new BookService(_db);
            _authorService = new AuthorService(_db);
            _categoryService = new CategoryService(_db);
        }

        [TestMethod]
        public void BookService_CRUD_Should_Ok()
        {
            var categories = _categoryService.Query();
            var authors = _authorService.Query();
            _bookForAdd1 = new Book
            {
                Title = "Test Title Add",
                Description = "Test Description Add",
                CategoryId = categories[new Random().Next(0, categories.Count)].Id,
                AuthorId = authors[new Random().Next(0, authors.Count)].Id,
                CreateTime = DateTime.Now,
                Publisher = "Test Publisher Add",
                Year = 1992
            };
            // Test add book.
            Assert.IsTrue(_bookService.Upsert(_bookForAdd1), "Fail to add a Book");
            _booksTest.Add(_bookForAdd1);

            // Test GetById
            Assert.IsNotNull(_bookService.GetById(_bookForAdd1.Id), "Cannot find a Book after adding");

            // Test Update
            _bookForAdd1.Title = "Test Title Update";
            _bookForAdd1.Description = "Test Description Update";
            _bookForAdd1.CategoryId = categories[new Random().Next(0, categories.Count)].Id;
            _bookForAdd1.AuthorId = authors[new Random().Next(0, authors.Count)].Id;
            _bookForAdd1.CreateTime = DateTime.Now;
            _bookForAdd1.Publisher = "Test Publisher Update";
            _bookForAdd1.Year = 1995;
            Assert.IsTrue(_bookService.Upsert(_bookForAdd1), "Fail to update a Book");

            // Test Delete
            Assert.IsTrue(_bookService.Delete(_bookForAdd1), "Cannot delete a Book");
        }

        [ClassCleanup]
        public static void CleanupTestData()
        {
            foreach (var bookTest in _booksTest)
            {
                if (_bookService.GetById(bookTest.Id) != null)
                {
                    _bookService.Delete(bookTest);
                }
               
            }
        }
    }
}
