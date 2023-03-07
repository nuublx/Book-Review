using BookReviewApp.Dto;
using BookReviewApp.Models;

namespace BookReviewApp.Interfaces
{
    public interface IAuthorRepository
    {
        ICollection<Author> GetAuthors();
        Author? GetAuthor(Guid Id);
        bool AuthorExist(Guid Id);

        ICollection<Book> GetAuthorBooks(Guid AuthorId);
        Author AddAuthor(AuthorCreationDto author);
    }
}
