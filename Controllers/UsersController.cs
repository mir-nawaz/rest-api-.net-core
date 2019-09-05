using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using restCore.Models;
using restCore.Repository;

namespace restCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersRepository userRepository;
        public UsersController(DB context)
        {
            userRepository = new UsersRepository(context);
        }

        //GET:      api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> List()
        {
            IEnumerable<User> users = userRepository.GetAll();
            return Ok(users);
        }
        
        //GET:      api/users/n
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            User user = userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //POST:     api/users
        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            User newUser = userRepository.Insert(user);
            return Ok(newUser);
        }

        //PUT:      api/users/n
        [HttpPut("{id}")]
        public ActionResult Update(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            userRepository.Update(user);

            return NoContent();
        }

        //DELETE:   api/users/n
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            User user = userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            userRepository.Delete(user);
            return user;
        }
    }
}