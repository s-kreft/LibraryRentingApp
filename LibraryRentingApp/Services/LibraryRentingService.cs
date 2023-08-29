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

        public async void AddBookToDb(Book book)
        {
            _dbContext.Add(book);
            _dbContext.SaveChanges();
        }

        public async IAsyncEnumerable<string>GetBookFromDb(string bookTitle)
        {

            var bookFromDb = _dbContext.books.FirstOrDefault(b => b.Title == bookTitle);
            var json = JsonConvert.SerializeObject(bookFromDb);
            yield return json;
        }

        public void UpdateBookInDb(Book book) 
        {

        }

        public async void DeleteBookFromDb(string bookTitle)
        {
            var bookToDelete = _dbContext.books.FirstOrDefault(b => b.Title == bookTitle);
            _dbContext.Remove(bookToDelete);
            _dbContext.SaveChanges();
        }

    }
}
