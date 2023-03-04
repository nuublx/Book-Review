using BookReviewApp.Models;

namespace BookReviewApp.Interfaces
{
    public interface IAuthorRepository
    {
        ICollection<Author> GetAuthors();
        ICollection<Author> GetAuthors(String Name);
        Author GetAuthor(Guid id);

    }
}
