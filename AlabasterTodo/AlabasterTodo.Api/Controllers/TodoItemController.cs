using AlabasterTodo.DataAccess.Interfaces;
using AlabasterTodo.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlabasterTodo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoItemRepository _repository;

        public TodoItemController(ITodoItemRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<TodoItemController>
        [HttpGet]
        public IEnumerable<TodoItem> Get()
        {
            return _repository.GetAllTodoItemsAsync().Result;
        }

        // GET api/<TodoItemController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TodoItemController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TodoItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TodoItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
