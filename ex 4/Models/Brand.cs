namespace ex_4.Models;

public class Brand
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Country { get; set; }
    public ICollection<Car>? Cars { get; set; }
}