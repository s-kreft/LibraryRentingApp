using LibraryRentingApp.Models;

namespace LibraryRentingApp.Services
{
    public interface ILibraryRentingService
    {
        void AddBookToDb(Book book);
    }
}