using System.ComponentModel.DataAnnotations;

namespace BookReviewApp.Models
{
    public class Reviewer
    {
        public Reviewer()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
