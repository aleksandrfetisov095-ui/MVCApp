using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ex3.Models;

public class CatCreateViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Имя обязательно")]
    [StringLength(50, MinimumLength = 2)]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Описание обязательно")]
    [StringLength(500, MinimumLength = 10)]
    public required string Description { get; set; }

    [Required(ErrorMessage = "Возраст обязателен")]
    [Range(0, 30)]
    public required int Age { get; set; }

    [Display(Name = "Фотография кота")]
    public IFormFile? PhotoFile { get; set; }

    public string? CurrentPhotoUrl { get; set; }

    public int BreedId { get; set; }
}