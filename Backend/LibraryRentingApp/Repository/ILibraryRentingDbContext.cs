namespace LibraryRentingApp.Repository
{
    public interface ILibraryRentingDbContext
    {
        DbSet<Book> books { get; set; }
        DbSet<Customer> customers { get; set; }
    }
}