

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
            _libraryRentingService.AddBookToDb(inputBook) ;
        }
        [HttpGet]
        public async Task GetBookFromDb(string bookTitle)
        {
            _libraryRentingService.GetBookFromDb(bookTitle);
        }
    }
}
