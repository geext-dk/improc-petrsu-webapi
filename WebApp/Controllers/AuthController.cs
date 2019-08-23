using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public async Task Login(string email, string password)
        {
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task Logout()
        {
            await Request.HttpContext.SignOutAsync();
        }
    }
}