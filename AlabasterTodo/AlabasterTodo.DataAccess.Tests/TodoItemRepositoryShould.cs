using AlabasterTodo.DataAccess.Models;
using AlabasterTodo.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AlabasterTodo.DataAccess.Tests
{
    [TestClass]
    public class TodoItemRepositoryShould
    {
        private AlabasterTodoDbContext _context;
        private TodoItemRepository _repository;

        [TestInitialize]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<AlabasterTodoDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _context = new AlabasterTodoDbContext(options);
            SeedDbWithMockTodoItems(_context);
            _repository = new TodoItemRepository(_context);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _context.Database.EnsureDeleted(); // Remove from memory
            _context.Dispose();
        }

        [TestMethod]
        public async Task ReturnTodoItemsInCollectionNotNullAsync()
        {
            var sut = await _repository.GetAllTodoItemsAsync();
            Assert.IsNotNull(sut);

        }

        [TestMethod]
        public async Task ReturnAllTodoItemsInCollectionAsync()
        {
            var sut = await _repository.GetAllTodoItemsAsync();

            Assert.AreEqual(3, sut?.Count());
        }
        [TestMethod]
        public async Task GetTodoItemByIdandNotReturnNull()
        {
            TodoItem sut = await _repository.GetTodoItemByIdAsync(1);
            Assert.IsNotNull(sut);
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
