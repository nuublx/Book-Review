using BookReviewApp.Data;
using BookReviewApp.Dto;
using BookReviewApp.Interfaces;
using BookReviewApp.Models;
using Microsoft.IdentityModel.Tokens;

namespace BookReviewApp.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;
        public AuthorRepository(DataContext context)
        {
            _context = context;
        }

        //Create
        public Author AddAuthor(AuthorCreationDto author)
        {
            var AuthorObject = new Author()
            {
                Name = author.Name,
                Biography = author.Biography,
            };
            _context.Authors.Add(AuthorObject);
            _context.SaveChanges();
            return AuthorObject;
        }

        //Read
        public bool AuthorExist(Guid AuthorId) => _context.Authors.Any(a => a.Id.Equals(AuthorId));
        public bool AuthorExist(string AuthorName) => _context.Authors.Any(a => a.Name.Equals(AuthorName));

        public Author GetAuthor(Guid AuthorId) => _context.Authors.First(au => au.Id.Equals(AuthorId));

        public ICollection<Book> GetAuthorBooks(Guid AuthorId) => _context.Books.Where(b => b.AuthorID.Equals(AuthorId)).ToList();

        public ICollection<Author> GetAuthors() => _context.Authors.OrderBy(au => au.Name).ToList();

        //Update
        public Author UpdateAuthor(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
            return author;
        }
        //Delete
        public void DeleteAuthor(Author author)
        {
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}
