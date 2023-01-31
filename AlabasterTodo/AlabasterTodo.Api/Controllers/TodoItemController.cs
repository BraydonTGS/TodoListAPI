using AlabasterTodo.DataAccess.Interfaces;
using AlabasterTodo.DataAccess.Models;
using AlabasterTodo.Domain.Models.Request;
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
        public async Task<IActionResult> Post([FromBody] TodoItemRequest todoRequest)
        {
            if (todoRequest == null)
            {
                return BadRequest();
            }
            var todo = new TodoItem()
            {
                Description = todoRequest.Description,
                DateCreated = todoRequest.DateCreated,
                DateCompleted = todoRequest.DateCompleted,
                IsDeleted = todoRequest.IsDeleted,
                IsCompleted = todoRequest.IsCompleted,
                UserId = todoRequest.UserId,
                User = todoRequest.User

            };
            var todoResponse = _repository.CreateNewTodoItemAsync(todo).Result;

            return Ok(todoResponse);

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
