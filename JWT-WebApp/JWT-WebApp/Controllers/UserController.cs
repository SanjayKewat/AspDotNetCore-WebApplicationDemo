using JWT_WebApp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace JWT_WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("Public")]
        public IActionResult Public()
        {
            return Ok("Hi,you're on public property");
        }

        [HttpGet("Admins")]
        [Authorize(Roles = "Administrator")]  // by put authorise attribute,become secure & Roles pass for specific users role
        public IActionResult AdminsEndpoint()
        {
            var currentuser = GetCurrentUser();
            return Ok($"Hi {currentuser.GivenName}, you are an {currentuser.Role}");
        }

        [HttpGet("Sellers")]
        [Authorize(Roles = "Seller")]  // by put authorise attribute,become secure & Roles pass for specific users role
        public IActionResult SellersEndpoint()
        {
            var currentuser = GetCurrentUser();
            return Ok($"Hi {currentuser.GivenName}, you are an {currentuser.Role}");
        }

        [HttpGet("AdminsAndSellers")]
        [Authorize(Roles = "Administrator,Seller")]  // Multiple Roles will be pass, so that it avaible for given list of roles
        public IActionResult AdminsAndSellersEndpoint()
        {
            var currentuser = GetCurrentUser();
            return Ok($"Hi {currentuser.GivenName}, you are an {currentuser.Role}");
        }

        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if(identity != null)
            {
                var userClaims = identity.Claims;
                return new UserModel
                {
                    UserName = userClaims.FirstOrDefault(x=>x.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmaildAddress = userClaims.FirstOrDefault(x=>x.Type == ClaimTypes.Email)?.Value,
                    GivenName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value,
                    SurName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Surname)?.Value,
                    Role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value,
                };
            }
            return null;
        }
    }
}
