using Microsoft.AspNetCore.Mvc;
using restCore.Models;
using restCore.ViewModels;
using System.Linq;

namespace restCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DB dbContext;

        public AuthController(DB context)
        {
            dbContext = context;
        }

        //POST:      api/auth/register
        [HttpPost("register")]

        public ActionResult<User> Register([FromBody] RegisterViewModel model)
        {
            User userExists = dbContext.User.FirstOrDefault(x => x.Email == model.Email);
            if (userExists != null)
            {
                //return StatusCode(409, new { title = "Bad Request", status = 409 });
                return Conflict();
            }

            User user = new User
            {
                Email = model.Email,
                Name = model.Name,
                Password = model.Password
            };

            dbContext.User.Add(user);
            dbContext.SaveChanges();
            return dbContext.User.Find(user.Id);
        }

        //POST:      api/auth/login
        [HttpPost("login")]

        public ActionResult Login([FromBody] LoginViewModel model)
        {
            User userEmail = dbContext.User.FirstOrDefault(x => x.Email == model.Email);

            if (userEmail == null)
            {
                return BadRequest(new { token = "token", expiration = "time" });
            }

            User userPwd = dbContext.User.FirstOrDefault(x => x.Password == model.Password);

            if (userPwd == null)
            {
                return BadRequest();
            }

            JwtToken jwtToken = new JwtToken
            {
                Issuer = "adasdasd",
                Expires = 12,
                Token = "Asasd",
                User = userPwd
            };
            
            return Ok(new { token = "token", expiration = "time" });
        }
    }
}