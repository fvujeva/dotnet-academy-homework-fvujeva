using Library.FilipVujeva.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.FilipVujeva.API.Controllers
{
    [Route("host/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public BooksController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetMyBooks()
        {
            var myBooks = await this._libraryService.GetMyBooks(GetCurrentUserId());
            return this.Ok(myBooks);
        }

        [HttpPost]
        public async Task<IActionResult> GetAllBooks()
        {
            var allBooks = await this._libraryService.GetAllBooks();
            return this.Ok(allBooks);
        }

        [HttpPut("{bookId}")]
        public async Task<IActionResult> RentABook([FromRoute] int bookId)
        {
            int personId = GetCurrentUserId();
            await _libraryService.RentBook(personId, bookId);
            return this.Ok();
        }

        [HttpDelete("{bookId}")]
        public async Task<IActionResult> ReturnABook([FromRoute] int bookId)
        {
            int personId = GetCurrentUserId();
            await _libraryService.ReturnBook(personId, bookId);
            return this.Ok();
        }

        private int GetCurrentUserId()
        {
            var idClaim = this.User.Claims.First(claim => claim.Type == "Id");
            return int.Parse(idClaim.Value);
        }
    }
}
