using Microsoft.EntityFrameworkCore;
using LibraryRentingApp.Models;

namespace LibraryRentingApp.Repository
{
    public class LibraryRentingDbContext : DbContext
    {
        public DbSet<Book> books { get; set; } = null!;
        public DbSet<Customer> customers { get; set; } = null!;
        
        public LibraryRentingDbContext(DbContextOptions<LibraryRentingDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=library_renting; Integrated Security=true");
        //}
    }
}
