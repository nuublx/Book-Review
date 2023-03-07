using BookReviewApp.Models;

namespace BookReviewApp.Dto
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
    }
}
