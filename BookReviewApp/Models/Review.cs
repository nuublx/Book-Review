
namespace BookReviewApp.Models
{
    public class Review
    {
        public Review()
        {
            ReviewId= Guid.NewGuid();
        }
        public Guid ReviewId { get; set; }
        public Guid BookId { get; set; }
        public Guid ReviewerId { get; set;}
        public String BookName { get; set; }
        public string Title { get; set; }
        public string ReviewDescription { get; set; }
    }
}
