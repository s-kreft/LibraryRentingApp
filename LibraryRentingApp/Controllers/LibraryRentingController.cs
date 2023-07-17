

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
        public async Task PostBookToDb(Book inputBook)
        {
            _libraryRentingService.AddBookToDb(inputBook);
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
