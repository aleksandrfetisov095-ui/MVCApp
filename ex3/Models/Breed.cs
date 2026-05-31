namespace ex3.Models
{
    public class Breed
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Cat>? Cats { get; set; }
    }
}
