using AutoMapper;
using Book.API.Filters;
using Book.API.ModelBinders;
using Book.API.Models;
using Book.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers
{
    [Route("api/bookcollections")] //define some custom route url
    [ApiController]  // add this attribute for denoting controller
    [BooksResultFilter]  //here adding this filter automatic apply for all action respose
    public class BookCollectionsController : ControllerBase  //here inherit ControllerBase class
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookCollectionsController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        // api/bookcollections/(id1,id2..) //receive the Id's comma seperated
        [HttpGet("({bookIds})", Name = "GetBookCollection")]
        public async Task<IActionResult> GetBookCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> bookIds)
        {
            var bookEntities = await _bookRepository.GetAuthorBooksAsync(bookIds);
            if (bookEntities.Count() != bookIds.Count())
            {
                return NotFound();
            }
            return Ok(bookEntities);
        }


        [HttpPost]
        public async Task<IActionResult> CreateBookCollection(IEnumerable<BookForCreation> bookForCreation)
        {
            var bookEntities = _mapper.Map<IEnumerable<Entities.AuthorBook>>(bookForCreation);
            _bookRepository.AddBooks(bookEntities);
            await _bookRepository.SaveChangesAsync();

            var booksToReturn = await _bookRepository.GetAuthorBooksAsync(bookEntities.Select(x => x.Id).ToList());
            var bookIds = string.Join(",", booksToReturn.Select(x => x.Id));
            return CreatedAtRoute("GetBookCollection", new { bookIds }, booksToReturn);
        }
    }
}
