using LibraryRentingApp.Models;
using LibraryRentingApp.Repository;

namespace LibraryRentingApp.Services
{
    public class LibraryRentingService
    {
        private readonly LibraryRentingDbContext _dbContext;
        public LibraryRentingService(LibraryRentingDbContext dbContext)
        {
            _dbContext= dbContext;
        }


    }
}
