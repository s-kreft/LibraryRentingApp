using Microsoft.EntityFrameworkCore;

namespace LibraryRentingApp.Repository
{
    public class LibraryRentingDbContext : DbContext
    {
        public LibraryRentingDbContext(DbContextOptions<LibraryRentingDbContext> options) : base(options)
        {

        }
    }
}
