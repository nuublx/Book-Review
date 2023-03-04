using BookReviewApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookReviewApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> BookReviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Review>()
                .HasKey(o => new { o.ReviewId, o.BookId, o.ReviewerId });
            modelBuilder.Entity<Author>()
                .HasKey(o => new { o.Id, o.Name });
            modelBuilder.Entity<Category>()
                .HasKey(o => new {o.CategoryId, o.CategoryName});
            modelBuilder.Entity<Reviewer>()
                .HasKey(o => new { o.Id });
            modelBuilder.Entity<Book>()
                .HasKey(o => new {o.Id, o.Name});
        }
    }
}
