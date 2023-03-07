using AutoMapper;
using BookReviewApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

    }
}
