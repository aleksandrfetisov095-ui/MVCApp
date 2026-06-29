using System.ComponentModel.DataAnnotations;

namespace ProductAp.DTOs;

public class CreateCategoryDto
{
    [Required(ErrorMessage = "обязательн название")]
    [StringLength(100, MinimumLength = 3)]
    public required string Name { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }
}

public class UpdateCategoryDto
{
    [Required(ErrorMessage = "обязатльно название")]
    [StringLength(100, MinimumLength = 3)]
    public required string Name { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }
}