using BookReviewApp.Dto;
using BookReviewApp.Models;

namespace BookReviewApp.Interfaces
{
    public interface IAuthorRepository
    {
        //Create
        Author AddAuthor(AuthorCreationDto author);
        //Read
        ICollection<Author> GetAuthors();
        Author GetAuthor(Guid Id);
        bool AuthorExist(Guid Id);
        bool AuthorExist(string AuthorName);
        ICollection<Book> GetAuthorBooks(Guid AuthorId);
        //Update
        public Author UpdateAuthor(Author author);
        //Delete
        public void DeleteAuthor(Author author);
    }
}
