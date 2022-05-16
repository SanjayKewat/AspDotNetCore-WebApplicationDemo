using AutoMapper;
using Book.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Book.API.Filters
{
    public class BookWithCoversResultFilterAttribute : ResultFilterAttribute
    {
        //using this action filter we are validating state of model
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            //context.HttpContext.Response.StatusCode  //here you also get the response
            var resultFromAction = context.Result as ObjectResult;
            if (resultFromAction?.Value == null || resultFromAction.StatusCode < 200 || resultFromAction.StatusCode >= 300)
            {
                await next();
                return;
            }

            //here creating tuple response with book,bookCovers property
            var (book,bookCovers) = ((Entities.AuthorBook authorBook,IEnumerable<ExternalModels.BookCover> bookCovers))resultFromAction.Value;
            //mapped the class
            var mapper = context.HttpContext.RequestServices.GetRequiredService<IMapper>();
            var mappedBook = mapper.Map<BookWithCovers>(book);
            resultFromAction.Value = mapper.Map(bookCovers,mappedBook);
            await next();
        }
    }
}
