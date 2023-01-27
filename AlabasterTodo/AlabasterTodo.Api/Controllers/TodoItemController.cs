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
       
        [HttpGet]
        public IEnumerable<TodoItem> Get()
        {
            return _repository.GetAllTodoItemsAsync().Result;
        }

        
        [HttpGet("{id}")]
        public TodoItem Get(int id)
        {
            return _repository.GetTodoItemByIdAsync(id).Result;
        }

        
        [HttpPost]
        public TodoItem Post([FromBody] TodoItem todo)
        {
            return _repository.CreateNewTodoItemAsync(todo).Result;
        }

        
        [HttpPut("{id}")]
        public TodoItem Put(int id, [FromBody] TodoItem todo)
        {
            return _repository.UpdateTodoItemAsync(id, todo).Result;    
        }

        
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _repository.DeleteTodoItemAsync(id).Result;  
        }
    }
}
