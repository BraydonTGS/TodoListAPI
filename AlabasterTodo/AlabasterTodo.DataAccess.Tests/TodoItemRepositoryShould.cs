using AlabasterTodo.DataAccess.Models;
using AlabasterTodo.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.EntityFrameworkCore.Storage;

namespace AlabasterTodo.DataAccess.Tests
{
    [TestClass]
    public class TodoItemRepositoryShould
    {
        private AlabasterTodoDbContext _context;
        private TodoItemRepository _repository;

        public TodoItemRepositoryShould()
        {
            var options = new DbContextOptionsBuilder<AlabasterTodoDbContext>().UseInMemoryDatabase(databaseName: "AlabasterTodo").Options;
            _context = new AlabasterTodoDbContext(options);
            _repository = new TodoItemRepository(_context);
        }


        [TestMethod]
        public async Task ReturnAllTodoItemsInCollectionAsync()
        {
            var test = await _repository.GetAllTodoItemsAsync();
            Assert.IsNotNull(test); 

        }
    }
}
