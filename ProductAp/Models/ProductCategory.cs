using System.ComponentModel.DataAnnotations;

namespace ProductAp.Models;

public class ProductCategory
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Название обязательно")]
    [MaxLength(100)]
    public required string Name { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }
}