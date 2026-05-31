namespace ex3.Models
{

    public class Cat
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required int Age { get; set; }
        public required string PhotoSrc { get; set; }

        public int BreedId { get; set; }
        public Breed? Breed { get; set; }
    }
}
