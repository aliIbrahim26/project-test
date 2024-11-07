namespace PostLands_Domain
{
    public class Post
    {
        public Guid PostId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Summary { get; set; }
        public string? Author { get; set; }
        public Category? Category { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
