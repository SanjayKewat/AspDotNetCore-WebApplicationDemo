using Book.API.Entities;

namespace Book.API.Services
{
    public interface IBookRepository
    {
        //here task keyword represent Async
        Task<IEnumerable<AuthorBook>> GetAuthorBooksAsync();
        Task<AuthorBook> GetAuthorBookAsync(Guid id);

        void AddBook(AuthorBook authorBook);

        Task<bool> SaveChangesAsync();
    }
}
