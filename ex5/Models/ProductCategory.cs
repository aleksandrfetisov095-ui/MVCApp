using System.ComponentModel.DataAnnotations;

namespace ProductAp.Models;

public class ProductCategory
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Название категории обязательно")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Название должно содержать от 3 до 100 символов")]
    public required string Name { get; set; }

    [StringLength(500, ErrorMessage = "Описание не должно превышать 500 символов")]
    public string? Description { get; set; }
}