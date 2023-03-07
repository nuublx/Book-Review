using BookReviewApp.Dto;
using BookReviewApp.Models;

namespace BookReviewApp.Interfaces
{
    public interface ICategoryRepository
    {
        //Create
        Category AddCategory(CategoryCreationDto category);
        //Read
        ICollection<Category> GetCategories();
        Category GetCategory(Guid Id);
        bool CategoryExist(Guid Id);
        ICollection<Book> GetCategoryBooks(string CategoryName);
        //Update
        public Category UpdateCategory(Category category);
        //Delete
        public void DeleteCategory(Category category);
    }
}