
using AutoMapper;
using BookReviewApp.Data;
using BookReviewApp.Dto;
using BookReviewApp.Interfaces;
using BookReviewApp.Models;

namespace BookReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        //Create
        public Category AddCategory(CategoryCreationDto category)
        {
            var CategoryObject = new Category() { CategoryName = category.CategoryName };
            _context.Categories.Add(CategoryObject);
            _context.SaveChanges();
            return CategoryObject;
        }

        //Read
        public bool CategoryExist(Guid Id) => _context.Categories.Any(ct => ct.CategoryId.Equals(Id));
        public ICollection<Category> GetCategories() => _context.Categories.OrderBy(ct => ct.CategoryName).ToList();
        public Category GetCategory(Guid Id) => _context.Categories.First(ct => ct.CategoryId.Equals(Id));
        public ICollection<Book> GetCategoryBooks(string CategoryName) => _context.Books.Where(bk => bk.category.Equals(CategoryName)).ToList();

        //Update
        public Category UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return category;
        }

        //Delete
        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
