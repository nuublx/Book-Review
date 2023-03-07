using AutoMapper;
using BookReviewApp.Dto;
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
        private readonly IMapper _mapper;

        public AuthorController(IAuthorRepository authorRepository, IMapper mapper) 
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<AuthorDto>))]
        public IActionResult GetAuthors()
        {
            var Authors = _mapper.Map<List<AuthorDto>>(_authorRepository.GetAuthors());
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Authors);
        }

        [HttpGet("{AuthorId}")]
        [ProducesResponseType(200, Type = typeof(AuthorDto))]
        [ProducesResponseType(400)]
        public IActionResult GetAuthor(Guid AuthorId)
        {
            if(!_authorRepository.AuthorExist(AuthorId))
                return NotFound(AuthorId);

            var Author = _mapper.Map<AuthorDto>(_authorRepository.GetAuthor(AuthorId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Author);
        }

        [HttpGet("{AuthorId}/Books")]
        [ProducesResponseType(200, Type = typeof(ICollection<BookDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetAuthorBooks(Guid AuthorId)
        {
            if (!_authorRepository.AuthorExist(AuthorId))
                return NotFound(AuthorId);

            var Books = _mapper.Map<List<BookDto>>(_authorRepository.GetAuthorBooks(AuthorId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Books);
        }
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(AuthorDto))]
        [ProducesResponseType(400)]
        public IActionResult AddAuthor(AuthorCreationDto Author)
        {
            var authorDto = _mapper.Map<AuthorDto>(_authorRepository.AddAuthor(Author));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(authorDto);
        }
    }

}
