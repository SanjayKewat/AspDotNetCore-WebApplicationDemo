using AutoMapper;
using Book.API.Filters;
using Book.API.Models;
using Book.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers
{
    [ApiController]  // add this attribute for denoting controller
    [Route("api/books")] //define some custom route url
    public class BooksController : ControllerBase  //here inherit ControllerBase class
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BooksController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [BooksResultFilter]  //here apply the filter that convert the response into mulitiple book(model) object
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookRepository.GetAuthorBooksAsync();
            return Ok(books);
        }

        [HttpGet]
        [Route("{id}", Name = "GetBook")]
        [BookResultFilter] //here apply the filter that convert the response into single book(model) object
        public async Task<IActionResult> GetBook(Guid id)
        {
            var book = await _bookRepository.GetAuthorBookAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        [BookResultFilter] //here apply the filter that convert the response into single book(model) object
        public async Task<IActionResult> CreateBook(BookForCreation bookForCreation)
        {
            var authorBookEntity = _mapper.Map<Entities.AuthorBook>(bookForCreation); //map BookForCreation to AuthorBook Entity
            _bookRepository.AddBook(authorBookEntity);
            await _bookRepository.SaveChangesAsync();
            await _bookRepository.GetAuthorBookAsync(authorBookEntity.Id);// this line fetch the detail of book with author details
            return CreatedAtRoute("GetBook", new { id = authorBookEntity.Id }, authorBookEntity);  //here return the response with Id & mapped
        }
    }
}
