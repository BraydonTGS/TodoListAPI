using AlabasterTodo.DataAccess.Models;
using AlabasterTodo.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

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
            SeedDbWithMockTodoItems(_context);
            _repository = new TodoItemRepository(_context);

        }

        [TestMethod]
        public async Task ReturnAllTodoItemsInCollectionAsync()
        {
            var test = await _repository.GetAllTodoItemsAsync();
            Assert.IsNotNull(test);

        }

        #region Mock Data
        private static void SeedDbWithMockTodoItems(AlabasterTodoDbContext context)
        {
            var dataToSeed = GenertateMockTodoItems();
            foreach (var todo in dataToSeed)
            {
                context.Add(todo);
            }
            context.SaveChanges();
        }

        private static List<TodoItem> GenertateMockTodoItems()
        {
            var newTodoCollection = new List<TodoItem>()
            {
                new TodoItem()
                {

                    DateCreated= DateTime.Now,
                    DateCompleted = null,
                    Description = "Take out the trash",
                    IsCompleted= false,
                    IsDeleted= false,
                    UserId= 1,
                },
                     new TodoItem()
                {

                    DateCreated= DateTime.Now,
                    DateCompleted = null,
                    Description = "Wash the Sheets",
                    IsCompleted= false,
                    IsDeleted= false,
                    UserId= 1,
                },
                          new TodoItem()
                {

                    DateCreated= DateTime.Now,
                    DateCompleted = null,
                    Description = "Make Dinner",
                    IsCompleted= false,
                    IsDeleted= false,
                    UserId= 1,
                }
            };

            return newTodoCollection;

        }
        #endregion

    }
}
