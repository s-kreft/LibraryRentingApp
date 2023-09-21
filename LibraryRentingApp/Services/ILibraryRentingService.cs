using LibraryRentingApp.Models;

namespace LibraryRentingApp.Services
{
    public interface ILibraryRentingService
    {
        void AddBookToDb(Book book);
        void AddBookToLibraryCustomer(string customerName, string bookTitle);
        void AddNewLibraryCustomer(Customer customer);
        void DeleteBookFromDb(string bookTitle);
        void DeleteCustomerFromDb(string customerName);
        IAsyncEnumerable<string> GetBookFromDb(string bookTitle);
        IAsyncEnumerable<List<Book>> GetBooksRentedByCustomer(int customerId);
        IAsyncEnumerable<Customer> GetCustomerFromDb(string customerName);
    }
}