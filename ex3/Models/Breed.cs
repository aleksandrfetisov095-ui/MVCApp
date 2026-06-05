using System.ComponentModel.DataAnnotations;

namespace ex3.Models;

public class Breed
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Название породы обязательно")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Название должно содержать от 3 до 100 символов")]
    [Display(Name = "Название породы")]
    public required string Name { get; set; }

    [StringLength(500, ErrorMessage = "Описание не должно превышать 500 символов")]
    [Display(Name = "Описание породы")]
    public string? Description { get; set; }

    public ICollection<Cat>? Cats { get; set; }
}