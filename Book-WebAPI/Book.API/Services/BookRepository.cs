using Book.API.Contexts;
using Book.API.Entities;
using Book.API.ExternalModels;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Book.API.Services
{
    //this repositry dealing with database for fetching the data
    //IDisposable interface preventing from leakage & used for dispose the object
    public class BookRepository : IBookRepository, IDisposable
    {
        private BookContext _bookContext;
        private IHttpClientFactory _httpClientFactory;
        public BookRepository(BookContext bookContext, IHttpClientFactory httpClientFactory)
        {
            _bookContext = bookContext;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<AuthorBook> GetAuthorBookAsync(Guid id)
        {
            return await _bookContext.AuthorBooks.Include(x => x.Author).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<AuthorBook>> GetAuthorBooksAsync(IEnumerable<Guid> bookIds)
        {
            return await _bookContext.AuthorBooks.Where(x => bookIds.Contains(x.Id)).Include(x => x.Author).ToListAsync();
        }

        public async Task<IEnumerable<AuthorBook>> GetAuthorBooksAsync()
        {
            //here Author object also
            return await _bookContext.AuthorBooks.Include(b => b.Author).ToListAsync();
        }

        public void AddBook(AuthorBook authorBookToAdd)
        {
            if (authorBookToAdd == null)
            {
                throw new ArgumentNullException(nameof(authorBookToAdd));
            }

            _bookContext.AuthorBooks.Add(authorBookToAdd);
        }

        public void AddBooks(IEnumerable<AuthorBook> authorBookToAdds)
        {
            if (authorBookToAdds == null)
            {
                throw new ArgumentNullException(nameof(authorBookToAdds));
            }

            _bookContext.AuthorBooks.AddRange(authorBookToAdds);
        }

        public async Task<BookCover> GetBookCoverAsync(string converId)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync($"https://localhost:7125/api/bookcovers/{converId}");
            if (response.IsSuccessStatusCode)
            {
                //if response is success deserialize the output & return it
                return JsonSerializer.Deserialize<BookCover>(await response.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true, //this property ignore the Case sensitive
                    });
            }

            return null;
        }
        public async Task<BookCover> DownloadBookCoverAsync(HttpClient httpClient,string bookCoverUrl)
        {
            var response = await httpClient.GetAsync(bookCoverUrl);
            if (response.IsSuccessStatusCode)
            {
                //if response is success deserialize the output & return it
                return JsonSerializer.Deserialize<BookCover>(await response.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true, //this property ignore the Case sensitive
                    });
            }

            return null;
        }

        public async Task<IEnumerable<BookCover>> GetBookCoversAsync(Guid bookId)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var bookCovers = new List<BookCover>();

            //create a list of fake bookcovers
            var bookCoverUrls = new[]
            {
                $"https://localhost:7125/api/bookcovers/{bookId}-dummycover1",
                $"https://localhost:7125/api/bookcovers/{bookId}-dummycover2",
                $"https://localhost:7125/api/bookcovers/{bookId}-dummycover3",
                $"https://localhost:7125/api/bookcovers/{bookId}-dummycover4",
                $"https://localhost:7125/api/bookcovers/{bookId}-dummycover5"
            };

            //create the tasks & call the service parallely
            //DownloadBookCoverAsync() is the method created above
            var downloadBookCoverTasksQuery = from bookCoverUrl in bookCoverUrls
                                              select DownloadBookCoverAsync(httpClient, bookCoverUrl);

            //start the task & completed one by one
            var downloadBookCoverTasks = downloadBookCoverTasksQuery.ToList();

            //wait for all the task complete & then send the response
            return await Task.WhenAll(downloadBookCoverTasks);

            //no need this part when above code apply
            //foreach (var bookCoverUrl in bookCoverUrls)
            //{
            //    var response = await httpClient.GetAsync(bookCoverUrl);
            //    if (response.IsSuccessStatusCode)
            //    {
            //        bookCovers.Add(JsonSerializer.Deserialize<BookCover>(await response.Content.ReadAsStringAsync(),
            //    new JsonSerializerOptions
            //    {
            //        PropertyNameCaseInsensitive = true, //this property ignore the Case sensitive
            //    }));
            //    }
            //}
            //return bookCovers;
        }

        public async Task<bool> SaveChangesAsync()
        {
            //return true if 1 or more entities were changed
            return (await _bookContext.SaveChangesAsync() > 0);
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
