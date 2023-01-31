using AlabasterTodo.DataAccess.Interfaces;
using AlabasterTodo.DataAccess.Models;
using AlabasterTodo.Domain.Models.Request;
using AlabasterTodo.Domain.Models.Response;
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
        public async Task<IActionResult> Get()
        {
            var todoItemResponseCollection = new List<TodoItemResponse>();
            var todoItems = await _repository.GetAllTodoItemsAsync();
            foreach (var todoItem in todoItems)
            {
               var todoItemResponse = new TodoItemResponse()
                {
                    Description = todoItem.Description,
                    DateCreated = todoItem.DateCreated,
                    DateCompleted = todoItem.DateCompleted,
                    IsDeleted = todoItem.IsDeleted,
                    IsCompleted = todoItem.IsCompleted,
                    UserId = todoItem.UserId
                };
                todoItemResponseCollection.Add(todoItemResponse);
            }
            return Ok(todoItemResponseCollection);
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

            var newTodo = new TodoItem()
            {
                Description = todoRequest.Description,
                DateCreated = todoRequest.DateCreated,
                DateCompleted = todoRequest.DateCompleted,
                IsDeleted = todoRequest.IsDeleted,
                IsCompleted = todoRequest.IsCompleted,
                UserId = todoRequest.UserId,
            };

            var response = _repository.CreateNewTodoItemAsync(newTodo).Result;

            var todoResponse = new TodoItemResponse()
            {
                Description = response.Description,
                DateCreated = response.DateCreated,
                DateCompleted = response.DateCompleted,
                IsDeleted = response.IsDeleted,
                IsCompleted = response.IsCompleted,
                UserId =    response.UserId,
            };

            return Ok(todoResponse);

        }


        [HttpPut("{id}")]
        public TodoItem Put([FromRoute] int id, [FromBody] TodoItem todo)
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
