using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookReviewApp.Models
{
    public class Book
    {
        public Book()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        [ForeignKey(nameof(Author.Id))]
        public Guid AuthorID { get; set; }
        public DateTime PublishDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(Category.CategoryName))]
        public String category { get; set; }

        public List<Review> Reviews;
    }
}
