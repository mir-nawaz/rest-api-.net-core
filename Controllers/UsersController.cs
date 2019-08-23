using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using restCore.Models;
using Microsoft.EntityFrameworkCore;

namespace restCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DB dbContext;

        public UsersController(DB context)
        {
            dbContext = context;
        }

        //GET:      api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> List()
        {
            return dbContext.User;
        }
        
        //GET:      api/users/n
        [HttpGet("{id}")]
        
        public ActionResult<User> Get(int id)
        {
            var user = dbContext.User.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        //POST:     api/users
        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            dbContext.User.Add(user);
            dbContext.SaveChanges();

            return CreatedAtAction("Get", new User{Id = user.Id}, user);
        }

        //PUT:      api/users/n
        [HttpPut("{id}")]
        public ActionResult Update(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            dbContext.Entry(user).State = EntityState.Modified;
            dbContext.SaveChanges();

            return NoContent();
        }

        //DELETE:   api/users/n
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            var user = dbContext.User.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            dbContext.User.Remove(user);
            dbContext.SaveChanges();

            return user;
        }
    }
}