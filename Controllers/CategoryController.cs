using DigitusCase.Dtos.Book;
using DigitusCase.Dtos.Category;
using DigitusCase.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DigitusCase.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IStringLocalizer<Messages> _localizer;


        public CategoryController(ICategoryService categoryService, IStringLocalizer<Messages> localizer)
        {
            _categoryService = categoryService;
            _localizer = localizer;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> Get()
        {
            return Ok(_categoryService.Get());
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryDto> GetById(int id)
        {
            var book = _categoryService.GetById(id);

            if (book == null)
            {
                return NotFound(_localizer["NotFoundMessage"].Value);
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryDto request)
        {
            _categoryService.Create(request);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryDto request)
        {

            if (!_categoryService.EntityExists(id))
            {
                return NotFound(_localizer["NotFoundMessage"].Value);
            }

            _categoryService.Update(id, request);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {

            if (!_categoryService.EntityExists(id))
            {
                return NotFound(_localizer["NotFoundMessage"].Value);
            }

            _categoryService.DeleteById(id);

            return Ok();
        }
    }
}
