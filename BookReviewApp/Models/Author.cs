using System.ComponentModel.DataAnnotations;

namespace BookReviewApp.Models
{
    public class Author
    {
        public Author()
        {
            Id= Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
