using AutoMapper;
using BookReviewApp.Dto;
using BookReviewApp.Models;

namespace BookReviewApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<Book, BookDto>();
            CreateMap<Category, CategoryDto>();
        }
    }
}
