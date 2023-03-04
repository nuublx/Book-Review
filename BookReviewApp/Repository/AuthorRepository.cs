using BookReviewApp.Data;
using BookReviewApp.Interfaces;
using BookReviewApp.Models;

namespace BookReviewApp.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;
        public AuthorRepository(DataContext context)
        {
            _context= context;
        }
        public Author GetAuthor(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Author> GetAuthors() => _context.Authors.OrderBy(au => au.Name).ToList();

        public ICollection<Author> GetAuthors(string Name)
        {
            throw new NotImplementedException();
        }
    }
}
