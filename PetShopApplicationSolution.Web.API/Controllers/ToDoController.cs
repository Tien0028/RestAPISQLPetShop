using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopApplication.Core.Entities;
using PetShopApplicationSolution.Infrastructure.Data.Repositories;

namespace PetShopApplicationSolutionRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class ToDoController : Controller
    {
        private readonly ToDoRepository _todoRepo;

        public ToDoController(ToDoRepository todoRepo)
        {
            _todoRepo = todoRepo;
        }

        // GET: api/Todo
        [Authorize]
        [HttpGet]
        public IEnumerable<ToDoItem> GetAll()
        {
            return _todoRepo.GetAll();
        }

        // GET: api/Todo/5
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            var item = _todoRepo.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST: api/Todo
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Post([FromBody] ToDoItem toDo)
        {
            if(toDo == null)
            {
                return BadRequest();
            }
            _todoRepo.Add(toDo);
            return CreatedAtRoute("Get", new { id = toDo.ID }, toDo);
        }

        // PUT: api/Todo/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] ToDoItem toDo)
        {

            if (toDo == null || toDo.ID != id)
            {
                return BadRequest();
            }

            var todo = _todoRepo.Get(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.IsComplete = toDo.IsComplete;
            todo.Name = toDo.Name;

            _todoRepo.Edit(todo);
            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _todoRepo.Get(id);
            if(todo == null)
            {
                return NotFound();
            }
            _todoRepo.Remove(id);
            return new NoContentResult();
        }

    }
}
