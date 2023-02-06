using LibraryRentingApp.Models;
using LibraryRentingApp.Repository;

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
        }

    }
}
