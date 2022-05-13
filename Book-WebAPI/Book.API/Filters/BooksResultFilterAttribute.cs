using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Book.API.Filters
{
    //this attribute map for mulitple books object
    public class BooksResultFilterAttribute : ResultFilterAttribute
    {
        //private readonly IMapper _mapper;
        //public BookResultFilterAttribute(IMapper mapper)
        //{
        //    _mapper = mapper;
        //}

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

            //here map the result into the books object using IEnumerable
            var mapper = context.HttpContext.RequestServices.GetRequiredService<IMapper>();
            resultFromAction.Value = mapper.Map<IEnumerable<Models.Book>>(resultFromAction.Value);
            await next();
        }
    }
}
