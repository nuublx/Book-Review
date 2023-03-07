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
            _context= context;
        }

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

        public bool AuthorExist(Guid AuthorId) => _context.Authors.Any(a => a.Id.Equals(AuthorId));

        public Author? GetAuthor(Guid AuthorId) => _context.Authors.FirstOrDefault(au => au.Id.Equals(AuthorId));

        public ICollection<Book> GetAuthorBooks(Guid AuthorId) => _context.Books.Where(b => b.AuthorID.Equals(AuthorId)).ToList();

        public ICollection<Author> GetAuthors() => _context.Authors.OrderBy(au => au.Name).ToList();

    }
}
