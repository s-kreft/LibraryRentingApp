using LibraryRentingApp.Models;

namespace LibraryRentingApp.Services
{
    public interface ILibraryRentingService
    {
        void AddBookToDb(Book book);
        void DeleteBookFromDb(string bookTitle);
        IAsyncEnumerable<string> GetBookFromDb(string bookTitle);
    }
}