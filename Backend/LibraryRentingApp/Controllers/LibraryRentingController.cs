

using LibraryRentingApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryRentingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryRentingController : Controller
    {
        private ILibraryRentingService _libraryRentingService;

        public LibraryRentingController(ILibraryRentingService libraryRentingService)
        {
            _libraryRentingService = libraryRentingService;
        }

        [HttpPost]
        [Route("librarian/book")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostBookToDb(Book inputBook)
        {
            if(inputBook.Title == null || inputBook.Author == null || inputBook.Description == null)
            {
                return BadRequest("Title, author name and description are mandatory");
            }
            _libraryRentingService.AddBookToDb(inputBook);

           return  CreatedAtAction(nameof(PostBookToDb), new { name = inputBook.Title }, inputBook);
        }

        [HttpGet]
        [Route("librarian/book")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Book))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBookFromDb(int bookId)
        {
            var book = _libraryRentingService.GetBookFromDb(bookId);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPut]
        [Route("librarian/book")]
        public async Task<IActionResult> PutBookInDb(int bookId, Book inputBook)
        {
            _libraryRentingService.UpdateBookInDb(bookId, inputBook);
            return CreatedAtAction(nameof(PutBookInDb), new { name = inputBook.Title }, inputBook);
        }

        [HttpDelete]
        [Route("librarian/book")]
        public async Task<IActionResult> DeleteBookFromDb(int bookId)
        {
            var bookFromDb = _libraryRentingService.GetBookFromDb(bookId);

            try
            {
                if(bookFromDb == null) 
                {
                    return NotFound();
                }
                _libraryRentingService.DeleteBookFromDb(bookId);

                return NoContent();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        [Route("librarian/customer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostLibraryCustomerToDb(Customer inputCustomer)
        {
            if(inputCustomer.Name == null || inputCustomer.Address == null || inputCustomer.City == null)
            {
                return BadRequest("Customer name, city of living and adress are mandatory");
            }
            else
            {
                _libraryRentingService.AddNewLibraryCustomer(inputCustomer);

                return CreatedAtAction(nameof(PostLibraryCustomerToDb), new { name = inputCustomer.Name }, inputCustomer);
            }          
        }
        [HttpGet]
        [Route("librarian/customer")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customer))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLibraryCustomerFromDb(int customerId)
        {
            var customerFromDb = _libraryRentingService.GetCustomerFromDb(customerId);

            return customerFromDb == null ? NotFound() : Ok(customerFromDb);
        }

        [HttpDelete]
        [Route("librarian/customer")]
        public async Task<IActionResult> DeleteCustomerFromDb(int customerId)
        {
            var customerFromDb = _libraryRentingService.GetCustomerFromDb(customerId);
            
            try
            {
                if(customerFromDb == null)
                {
                    return NotFound();
                }
                _libraryRentingService.DeleteCustomerFromDb(customerId);

                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("librarian/rent")]
        public async Task<IActionResult> PostBookIntoCustomerRentedBooks(int customerId, int bookId)
        {
            _libraryRentingService.AddBookToLibraryCustomer(customerId, bookId);

            return CreatedAtAction(nameof(PostBookIntoCustomerRentedBooks), new { name = customerId });
        }

        [HttpGet]
        public async Task<IAsyncEnumerable<List<Book>>> GetCustomerRentedBooks(int customerId)
        {
           var rentedBooks = _libraryRentingService.GetBooksRentedByCustomer(customerId);
            
            return rentedBooks;
        }
    }
}
