namespace BookStore.Models
{
    public class UpdateBookRequest
    {
        public string BookTitle { get; set; } //Book Title
        public string BookDescription { get; set; } //Book Description
        public string BookAuthor { get; set; } //Book Author
    }
}
