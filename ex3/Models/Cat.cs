using System.ComponentModel.DataAnnotations;

namespace ex3.Models;

public class Cat
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Имя обязательно для заполнения")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно содержать от 2 до 50 символов")]
    [Display(Name = "Имя кота")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Описание обязательно")]
    [StringLength(500, MinimumLength = 10, ErrorMessage = "Описание должно содержать от 10 до 500 символов")]
    [Display(Name = "Описание")]
    public required string Description { get; set; }

    [Required(ErrorMessage = "Возраст обязателен")]
    [Range(0, 30, ErrorMessage = "Возраст должен быть от 0 до 30 лет")]
    [Display(Name = "Возраст")]
    public required int Age { get; set; }

    [Required(ErrorMessage = "Ссылка на фото обязательна")]
    [StringLength(500, ErrorMessage = "Ссылка не должна превышать 500 символов")]
    [Url(ErrorMessage = "Введите корректный URL")]
    [Display(Name = "Ссылка на фото")]
    public required string PhotoSrc { get; set; }

    [Display(Name = "Порода")]
    public int BreedId { get; set; }
    public Breed? Breed { get; set; }
}