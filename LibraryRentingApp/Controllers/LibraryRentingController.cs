

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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostBookToDb(Book inputBook)
        {
            if(inputBook.Title== null || inputBook.Author == null || inputBook.Description == null)
            {
                return BadRequest("Title, author name and description are mandatory");
            }
            _libraryRentingService.AddBookToDb(inputBook);

            return CreatedAtAction(nameof(GetBookFromDb), new { name = inputBook.Title }, inputBook);
        }

        [HttpGet("{bookTitle}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Book))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetBookFromDb(string bookTitle)
        {
            var book = _libraryRentingService.GetBookFromDb(bookTitle);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpDelete]
        public async Task DeleteBookFromDb(string bookTitle)
        {
            _libraryRentingService.DeleteBookFromDb(bookTitle);
        }
    }
}
