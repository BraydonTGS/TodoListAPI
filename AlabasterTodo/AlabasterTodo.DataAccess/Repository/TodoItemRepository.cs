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
        public async Task<TodoItem> CreateNewTodoItemAsync(TodoItem item)
        {
          await  _dbContext.AddAsync(item);
           await _dbContext.SaveChangesAsync(); 
            return item;
            
        }

        public async Task<bool> DeleteTodoItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TodoItem>> GetAllTodoItemsAsync()
        {
            var todoItemList = await _dbContext.TodoItems.ToListAsync();
            if (todoItemList.Any())
            {
                return todoItemList;
            }
            return null;
        }

        public async Task<TodoItem> GetTodoItemByIdAsync(int Id)
        {
            var todoItem = await _dbContext.TodoItems.FirstOrDefaultAsync(x => x.Id == Id);

            if (todoItem != null)
            {
                return todoItem;

            }
            return null;
        }

        public async Task<TodoItem> UpdateTodoItemAsync(TodoItem item)
        {
            var todoItemToUpdate = await _dbContext.TodoItems.FirstOrDefaultAsync(x =>x.Id == item.Id);
            if (todoItemToUpdate != null)
            {
                todoItemToUpdate.Description = item.Description;
                todoItemToUpdate.IsCompleted = item.IsCompleted; 
                todoItemToUpdate.IsDeleted= item.IsDeleted;
                todoItemToUpdate.IsDeleted= item.IsDeleted;

                return todoItemToUpdate;
            }
            return null; 

        }
    }
}
