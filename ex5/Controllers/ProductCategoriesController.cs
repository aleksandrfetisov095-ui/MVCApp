using Microsoft.AspNetCore.Mvc;
using ProductAp.DTOs;
using ProductAp.Models;
using ProductAp.Repositories.Interfaces;

namespace ProductAp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductCategoriesController : ControllerBase
{
    private readonly ICategoryRepository _repository;

    public ProductCategoriesController(ICategoryRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductCategory>>> GetAll()
    {
        var categories = await _repository.GetAllAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductCategory>> GetById(int id)
    {
        var category = await _repository.GetByIdAsync(id);
        if (category == null)
            return NotFound(new { message = $"Категория с Id={id} не найдена" });

        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<ProductCategory>> Create([FromBody] CreateCategoryDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var category = new ProductCategory
        {
            Name = dto.Name,
            Description = dto.Description
        };

        var created = await _repository.AddAsync(category);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var category = new ProductCategory
        {
            Id = id,
            Name = dto.Name,
            Description = dto.Description
        };

        var updated = await _repository.UpdateAsync(id, category);
        if (updated == null)
            return NotFound(new { message = $"Категория с Id={id} не найдена" });

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _repository.DeleteAsync(id);
        if (!deleted)
            return NotFound(new { message = $"Категория с Id={id} не найдена" });

        return NoContent();
    }
}