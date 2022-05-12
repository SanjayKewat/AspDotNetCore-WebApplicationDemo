using Book.API.Contexts;
using Book.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Book.API.Services
{
    //this repositry dealing with database for fetching the data
    //IDisposable interface preventing from leakage & used for dispose the object
    public class BookRepository : IBookRepository, IDisposable
    {
        private BookContext _bookContext;
        public BookRepository(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public async Task<AuthorBook> GetAuthorBookAsync(Guid id)
        {
            return await _bookContext.AuthorBooks.Include(x => x.Author).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<AuthorBook>> GetAuthorBooksAsync()
        {
            //here Author object also
            return await _bookContext.AuthorBooks.Include(b => b.Author).ToListAsync();
        }

        //here dispose method used by the garbage collector for releasing the resources
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_bookContext != null)
                {
                    _bookContext.Dispose();
                    _bookContext = null;
                }
            }
        }
    }
}
