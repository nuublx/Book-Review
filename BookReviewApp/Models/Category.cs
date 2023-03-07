using System.ComponentModel.DataAnnotations;

namespace BookReviewApp.Models
{
    public class Category
    {
        public Category()
        {
            CategoryId= Guid.NewGuid();
        }
        public Guid CategoryId { get; }
        public string CategoryName { get; set; }
        public ICollection<Book> BooksCategory { get; set; }

    }
}