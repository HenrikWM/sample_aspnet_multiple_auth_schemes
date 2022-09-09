using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "MaualTokenValidation")]
    [Route("[controller]")]
    public class TokenValidationController : ControllerBase
    {
        [HttpGet(Name = "Validate")]
        public IEnumerable<string> ValidateToken()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            // Gets list of claims.
            IEnumerable<Claim> claims = identity.Claims;

            //return Ok(string.Join(",", claims));

            foreach (var item in claims)
            {
                yield return item.Type + ":" + item.Value;
            }
        }
    }
}
