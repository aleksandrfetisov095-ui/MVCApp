namespace ex2.Models
{
    public class Textbook
    {
        public required int Id { get; set; }
        public required string Title { get; set; }   
        public required string Subject { get; set; }    
        public required string Author { get; set; }    
        public required int Year { get; set; }        
        public required int Pages { get; set; }          
        public required string Description { get; set; } 
        public required string CoverUrl { get; set; }    
        public required decimal Price { get; set; }
    }
}
