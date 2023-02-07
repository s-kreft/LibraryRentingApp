

using LibraryRentingApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryRentingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryRentingController : Controller
    {
        private LibraryRentingService _libraryRentingService;
        public LibraryRentingController(LibraryRentingService libraryRentingService)
        {
            _libraryRentingService= libraryRentingService;
        }

        [HttpPost]
        public async Task<IActionResult> PostBookToDb(Book inputBook)
        {
            return _libraryRentingService.AddBookToDb(inputBook) ;
        }
    }
}
