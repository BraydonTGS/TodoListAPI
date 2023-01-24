using AlabasterTodo.DataAccess.Interfaces;
using AlabasterTodo.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace AlabasterTodo.DataAccess.Repository
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly AlabasterTodoDbContext _dbContext;

        public TodoItemRepository(AlabasterTodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TodoItem>? CreateNewTodoItem(TodoItem item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool>? DeleteTodoItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TodoItem>?> GetAllTodoItemsAsync()
        {
            var todoItemList = await _dbContext.TodoItems.ToListAsync();
            if (todoItemList.Any())
            {
                return todoItemList;
            }
            return null;
        }

        public async Task<TodoItem>? GetTodoItemByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<TodoItem>? UpdateTodoItemAsync(TodoItem item)
        {
            throw new NotImplementedException();
        }
    }
}
