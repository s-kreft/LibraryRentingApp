﻿

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
        public async Task<IActionResult> GetBookFromDb(string bookTitle)
        {
            var book = _libraryRentingService.GetBookFromDb(bookTitle);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpDelete]
        [Route("librarian/book")]
        public async Task<IActionResult> DeleteBookFromDb(string bookTitle)
        {
            var bookFromDb = _libraryRentingService.GetBookFromDb(bookTitle);

            try
            {
                if(bookFromDb == null) 
                {
                    return NotFound();
                }
                _libraryRentingService.DeleteBookFromDb(bookTitle);

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
        public async Task<IActionResult> GetLibraryCustomerFromDb(string customerName)
        {
            var customerFromDb = _libraryRentingService.GetCustomerFromDb(customerName);

            return customerFromDb == null ? NotFound() : Ok(customerFromDb);
        }

        [HttpDelete]
        [Route("librarian/customer")]
        public async Task<IActionResult> DeleteCustomerFromDb(string customerName)
        {
            var customerFromDb = _libraryRentingService.GetCustomerFromDb(customerName);
            
            try
            {
                if(customerFromDb == null)
                {
                    return NotFound();
                }
                _libraryRentingService.DeleteCustomerFromDb(customerName);

                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("librarian/rent")]
        public async Task<IActionResult> PostBookIntoCustomerRentedBooks(string customerName, string bookTitle)
        {
            _libraryRentingService.AddBookToLibraryCustomer(customerName, bookTitle);

            return CreatedAtAction(nameof(PostBookIntoCustomerRentedBooks), new { name = customerName });
        }

        [HttpGet]
        public async Task<IAsyncEnumerable<List<Book>>> GetCustomerRentedBooks(int customerId)
        {
           var rentedBooks = _libraryRentingService.GetBooksRentedByCustomer(customerId);
            
            return rentedBooks;
        }
    }
}