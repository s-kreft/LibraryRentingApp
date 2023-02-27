using LibraryRentingApp.Models;
using LibraryRentingApp.Repository;
using Microsoft.AspNetCore.Mvc;

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

        public Book GetBookFromDb(string bookTitle)
        {
            var bookFromDb = _dbContext.books.FirstOrDefault(b => b.Title == bookTitle);
            return bookFromDb;
        }

        public void DeleteBookFromDb(string bookTitle)
        {
            var bookToDelete = _dbContext.books.FirstOrDefault(b => b.Title == bookTitle);
            _dbContext.Remove(bookToDelete);
            _dbContext.SaveChanges();
        }

    }
}
