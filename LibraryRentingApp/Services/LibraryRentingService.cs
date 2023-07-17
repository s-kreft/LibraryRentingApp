using LibraryRentingApp.Models;
using LibraryRentingApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LibraryRentingApp.Services
{
    public class LibraryRentingService : ILibraryRentingService
    {
        private readonly LibraryRentingDbContext _dbContext;
        public LibraryRentingService()
        {

        }
        public LibraryRentingService(LibraryRentingDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.SaveChanges();
        }

        public void AddBookToDb(Book book)
        {
            _dbContext.Add(book);
            _dbContext.SaveChanges();
        }

        public String GetBookFromDb(string bookTitle)
        {

            var bookFromDb = _dbContext.books.FirstOrDefault(b => b.Title == bookTitle);
            var json = JsonConvert.SerializeObject(bookFromDb);
            return json;
            //string testVariable = "test";
            //return testVariable;

        }

        public void DeleteBookFromDb(string bookTitle)
        {
            var bookToDelete = _dbContext.books.FirstOrDefault(b => b.Title == bookTitle);
            _dbContext.Remove(bookToDelete);
            _dbContext.SaveChanges();
        }

    }
}
