using Book.API.Entities;
using Book.API.ExternalModels;

namespace Book.API.Services
{
    public interface IBookRepository
    {
        //here task keyword represent Async
        Task<IEnumerable<AuthorBook>> GetAuthorBooksAsync();

        Task<AuthorBook> GetAuthorBookAsync(Guid id);

        Task<IEnumerable<AuthorBook>> GetAuthorBooksAsync(IEnumerable<Guid> bookIds);

        void AddBook(AuthorBook authorBook);
        void AddBooks(IEnumerable<AuthorBook> authorBookToAdds);

        Task<BookCover> GetBookCoverAsync(string converId);
        Task<IEnumerable<BookCover>> GetBookCoversAsync(Guid bookIds);
        Task<bool> SaveChangesAsync();
    }
}
