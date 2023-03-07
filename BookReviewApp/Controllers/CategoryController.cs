using AutoMapper;
using BookReviewApp.Dto;
using BookReviewApp.Interfaces;
using BookReviewApp.Repository;
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
        //Create
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CategoryDto))]
        [ProducesResponseType(400)]
        public IActionResult AddCategory(CategoryCreationDto categoryCD)
        {
            if (_categoryRepository.CategoryExist(categoryCD.CategoryName))
                return StatusCode(409); //already exists

            var category = _mapper.Map<CategoryDto>( _categoryRepository.AddCategory(categoryCD) );
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(category);
        }

        //Read
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<CategoryDto>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(AuthorDto))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(Guid categoryId)
        {
            if (!_categoryRepository.CategoryExist(categoryId))
                return NotFound(categoryId);

            var category = _mapper.Map<CategoryDto>(_categoryRepository.GetCategory(categoryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }

        [HttpGet("{categoryName}/Books")]
        [ProducesResponseType(200, Type = typeof(ICollection<BookDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetCategoryBooks(string categoryName)
        {
            if (!_categoryRepository.CategoryExist(categoryName))
                return NotFound(categoryName);

            var Books = _mapper.Map<List<BookDto>>(_categoryRepository.GetCategoryBooks(categoryName));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Books);
        }

        //Update
        [HttpPut("{categoryId}/Edit")]
        [ProducesResponseType(200, Type = typeof(CategoryDto))]
        [ProducesResponseType(400)]
        public IActionResult UpdateCategory(CategoryDto categoryD)
        {
            if (!_categoryRepository.CategoryExist(categoryD.CategoryId))
                return NotFound(categoryD);

            var category = _categoryRepository.GetCategory(categoryD.CategoryId);
            category = _categoryRepository.UpdateCategory(category);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }
        //Delete
        [HttpDelete("{categoryId}/Delete")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult DeleteCategory(CategoryDto categoryD)
        {
            if (!_categoryRepository.CategoryExist(categoryD.CategoryId))
                return NotFound(categoryD);

            var category = _categoryRepository.GetCategory(categoryD.CategoryId);
            _categoryRepository.DeleteCategory(category);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }
    }
}
