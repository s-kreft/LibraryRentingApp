using LibraryRentingApp.Models;

namespace LibraryRentingApp.Services
{
    public interface ILibraryRentingService
    {
        void AddBookToDb(Book book);
        void AddBookToLibraryCustomer(int customerId, int bookId);
        void AddNewLibraryCustomer(Customer customer);
        void DeleteBookFromDb(int bookId);
        void DeleteCustomerFromDb(int customerId);
        IAsyncEnumerable<string> GetBookFromDb(int bookId);
        IAsyncEnumerable<List<Book>> GetBooksRentedByCustomer(int customerId);
        IAsyncEnumerable<Customer> GetCustomerFromDb(int customerId);
    }
}