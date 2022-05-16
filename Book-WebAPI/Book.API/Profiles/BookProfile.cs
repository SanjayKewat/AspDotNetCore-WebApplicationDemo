using AutoMapper;

namespace Book.API.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            //add mapping, first paramter source & second is destinations
            //ForMember() set Author name on Book(model) by concatinating entities Author.FirstName & LastName
            CreateMap<Entities.AuthorBook, Book.API.Models.Book>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}"));

            CreateMap<Book.API.Models.BookForCreation, Entities.AuthorBook>();

            CreateMap<Entities.AuthorBook, Models.BookWithCovers>()
               .ForMember(dest => dest.Author, opt => opt.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}"));

            CreateMap<IEnumerable<ExternalModels.BookCover>, Models.BookWithCovers>()
              .ForMember(dest => dest.BookCovers, opt => opt.MapFrom(src => src));

            CreateMap<ExternalModels.BookCover, Models.BookCover>();
        }
    }
}
