using BookReviewApp.Interfaces;
using BookReviewApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthorController: Controller
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorController(IAuthorRepository authorRepository) 
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Author>))]
        public IActionResult GetAuthors()
        {
            var Authors = _authorRepository.GetAuthors();
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Authors);
        }
    }
}
