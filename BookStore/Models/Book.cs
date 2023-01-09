namespace BookStore.Models
{
    public class Book
    {
        public Guid BookId { get; set; } //Global Unique Identifier
        public string BookTitle { get; set; } //Book Title
        public string BookDescription { get; set; } //Book Description
        public string BookAuthor { get; set; } //Book Author

        
    }
}
