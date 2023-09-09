using Microsoft.EntityFrameworkCore;
using LibraryRentingApp.Models;

namespace LibraryRentingApp.Repository
{
    public class LibraryRentingDbContext : DbContext, ILibraryRentingDbContext
    {
        public DbSet<Book> books { get; set; } = null!;
        public DbSet<Customer> customers { get; set; } = null!;

        public LibraryRentingDbContext()
        {
        }

        public LibraryRentingDbContext(DbContextOptions<LibraryRentingDbContext> options) : base(options)
        {

        }
    }
}
