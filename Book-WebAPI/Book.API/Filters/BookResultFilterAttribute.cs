using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Book.API.Filters
{
    //this attribute map for single book object
    public class BookResultFilterAttribute : ResultFilterAttribute
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

            //here map the result into the book object
            var mapper = context.HttpContext.RequestServices.GetRequiredService<IMapper>();
            resultFromAction.Value = mapper.Map<Models.Book>(resultFromAction.Value);
            await next();
        }
    }
}
