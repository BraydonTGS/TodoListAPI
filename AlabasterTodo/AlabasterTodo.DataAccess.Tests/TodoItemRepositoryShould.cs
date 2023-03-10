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
            var sut = await _repository.GetTodoItemByIdAsync(1);
            Assert.IsNotNull(sut);
        }

        [TestMethod]
        public async Task GetTodoItemByIdReturnsCorrectTodoItem()
        {
            var sut = await _repository.GetTodoItemByIdAsync(1);

            Assert.AreEqual(sut.Id, 1);
            Assert.AreEqual(sut.Description, "Take out the trash");
            Assert.AreEqual(sut.IsCompleted, false);
            Assert.AreEqual(sut.IsDeleted, false);

        }

        [TestMethod]
        public async Task CreateNewTodoItemandNotReturnNull()
        {
            var todo = GenerateSingleTodoItem();

            var sut = await _repository.CreateNewTodoItemAsync(todo);

            Assert.IsNotNull(sut);
        }

        [TestMethod]
        public async Task CreateNewTodoItemandReturnsTodoItem()
        {
            var todo = GenerateSingleTodoItem();

            var sut = await _repository.CreateNewTodoItemAsync(todo); 

            Assert.AreEqual(sut.Id, 4);
            Assert.AreEqual(sut.Description, "Organize the Garage");
            Assert.AreEqual(sut.IsCompleted, false);
            Assert.AreEqual(sut.IsDeleted, false); 
        }

        [TestMethod]
        public async Task UpdateTodoItemAndNotReturnNull()
        {
            var todo = GenerateSingleTodoItemToUpdate();  
            var sut = await _repository.UpdateTodoItemAsync(todo); 

            Assert.IsNotNull(sut);  
        }

        [TestMethod]
        public async Task UpdateTodoItemAndReturnUpdatedValues()
        {
            var todo = GenerateSingleTodoItemToUpdate();
            var sut = await _repository.UpdateTodoItemAsync(todo);
            Assert.AreEqual(sut.Id, 1);
            Assert.AreEqual(sut.Description, "Mop the Floors");
            Assert.AreEqual(sut.IsCompleted, true);
            Assert.AreEqual(sut.IsDeleted, true);
        }

        [TestMethod]
        public async Task DeleteTodoItemByIdAndNotReturnFalse()
        {
            var sut = await _repository.DeleteTodoItemAsync(1); 
            Assert.IsTrue(sut);
        }

        [TestMethod]
        public async Task DeleteTodoItemWithWrongIdReturnsFalse()
        {
            var sut = await _repository.DeleteTodoItemAsync(7);
            Assert.IsFalse(sut); 
        }

        // Seed DB Methods //
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

        private static TodoItem GenerateSingleTodoItem()
        {
            var todoItem = new TodoItem()
            {
                DateCreated = DateTime.Now,
                DateCompleted = null,
                Description = "Organize the Garage", 
                IsCompleted = false,
                IsDeleted = false,
                UserId = 1, 
            };
            return todoItem;
        }

        private static TodoItem GenerateSingleTodoItemToUpdate()
        {
            var todoItem = new TodoItem()
            {
                Id= 1,
                DateCreated = DateTime.Now,
                DateCompleted = null,
                Description = "Mop the Floors",
                IsCompleted = true,
                IsDeleted = true,
                UserId = 1,
            };
            return todoItem;
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
