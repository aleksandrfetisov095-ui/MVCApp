namespace ex_4.Models;

public class Car
{
    public int Id { get; set; }
    public required string Model { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }

    public int BrandId { get; set; }
    public Brand? Brand { get; set; }
}