using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            if (categories == null) return NotFound("Categories not found");

            return Ok(categories);
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null) return NotFound("Category not found");

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto == null) return BadRequest("Invalid data");

            await _categoryService.AddAsync(categoryDto);
            return new CreatedAtRouteResult("GetCategory",
                new { id = categoryDto.Id }, categoryDto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDto)
        {
            if (id != categoryDto.Id) return BadRequest();
            if (categoryDto == null) return BadRequest();

            var category = _categoryService.GetByIdAsync(id);
            if (category == null) NotFound("Category not found");

            await _categoryService.UpdateAsync(categoryDto);

            return Ok(categoryDto);
        }

        [HttpDelete]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var category = _categoryService.GetByIdAsync(id);
            if (category == null) return NotFound("Category not found");

            await _categoryService.RemoveAsync(id);

            return Ok(category);
        }
    }
}