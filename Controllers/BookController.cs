using DigitusCase.Dtos.Book;
using DigitusCase.Dtos.User;
using DigitusCase.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace DigitusCase.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> Get()
        {
            return Ok(_bookService.Get());
        }

        [HttpGet("{id}")]
        public ActionResult<BookDto> GetById(int id) {
            var book = _bookService.GetById(id);

            if (book == null) 
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookDto request)
        {
            
            string userName = await GetUserName();
            request.LastUpdatedBy = userName;

            _bookService.Create(request);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BookDto request)
        {

            if (!_bookService.EntityExists(id))
            {
                return NotFound();
            }

            string userName = await GetUserName();
            request.LastUpdatedBy = userName;

            _bookService.Update(id, request);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id) {

            if (!_bookService.EntityExists(id))
            {
                return NotFound();
            }

            _bookService.DeleteById(id);

            return Ok();
        }


        private async Task<string> GetUserName()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var securityTokenHandler = new JwtSecurityTokenHandler();
            var nameClaimValue = "";
            if (securityTokenHandler.CanReadToken(accessToken))
            {
                var decriptedToken = securityTokenHandler.ReadJwtToken(accessToken);
                var claims = decriptedToken.Claims;
                nameClaimValue = claims.Where(c => c.Type == "name").FirstOrDefault().Value;
            }
            return nameClaimValue;
        }
    }
}
