using Library.FilipVujeva.Contracts.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.FilipVujeva.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly IPeopleService peopleService;

        public ExampleController(IPeopleService peopleService)
        {
            this.peopleService = peopleService;
        }

        [Authorize]
        [HttpGet("example")]
        public async Task<IActionResult> GetAllPeople()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var allPeople = await this.peopleService.GetAllPeople();
            return this.Ok(allPeople);
        }
    }
}
