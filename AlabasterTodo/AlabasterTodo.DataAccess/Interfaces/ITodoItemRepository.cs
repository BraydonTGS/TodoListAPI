using AlabasterTodo.DataAccess.Models;

namespace AlabasterTodo.DataAccess.Interfaces
{
    public interface ITodoItemRepository
    {
        public Task<IEnumerable<TodoItem>> GetAllTodoItemsAsync();
        public Task<TodoItem> GetTodoItemByIdAsync(int Id); 
        public Task<TodoItem> CreateNewTodoItemAsync(TodoItem item);
        public Task<TodoItem> UpdateTodoItemAsync(int id, TodoItem item);
        public Task<bool> DeleteTodoItemAsync(int id);

    }
}
