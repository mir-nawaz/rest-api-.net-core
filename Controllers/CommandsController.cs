using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using restCore.Models;
using Microsoft.EntityFrameworkCore;

namespace restCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly DB dbContext;

        public CommandsController(DB context)
        {
            dbContext = context;
        }

        //GET:      api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetCommandItems()
        {
            return dbContext.Command;
        }
        
        //GET:      api/commands/n
        [HttpGet("{id}")]
        
        public ActionResult<Command> GetCommandItem(int id)
        {
            var commandItem = dbContext.Command.Find(id);

            if (commandItem == null)
            {
                return NotFound();
            }

            return commandItem;
        }
        
        //POST:     api/commands
        [HttpPost]
        public ActionResult<Command> PostCommandItem(Command command)
        {
            dbContext.Command.Add(command);
            dbContext.SaveChanges();

            return CreatedAtAction("GetCommandItem", new Command{Id = command.Id}, command);
        }

        //PUT:      api/commands/n
        [HttpPut("{id}")]
        public ActionResult PutCommandItem(int id, Command command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            dbContext.Entry(command).State = EntityState.Modified;
            dbContext.SaveChanges();

            return NoContent();
        }

        //DELETE:   api/commands/n
        [HttpDelete("{id}")]
        public ActionResult<Command> DeleteCommandItem(int id)
        {
            var commandItem = dbContext.Command.Find(id);

            if (commandItem == null)
            {
                return NotFound();
            }

            dbContext.Command.Remove(commandItem);
            dbContext.SaveChanges();

            return commandItem;
        }
    }
}