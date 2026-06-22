using Microsoft.AspNetCore.Mvc;
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
        if (category == null) return NotFound();
        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<ProductCategory>> Create(ProductCategory category)
    {
        var createdCategory = await _repository.AddAsync(category);
        return CreatedAtAction(nameof(GetById), new { id = createdCategory.Id }, createdCategory);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProductCategory category)
    {
        if (id != category.Id) return BadRequest();

        var result = await _repository.UpdateAsync(category);
        if (result == null) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _repository.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}