using AlabasterTodo.DataAccess.Models;
using AlabasterTodo.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace AlabasterTodo.DataAccess.Tests.Helpers
{
    public class InMemoryTestBase
    {
        protected AlabasterTodoDbContext context;
        protected TodoItemRepository repository;


        [TestInitialize]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<AlabasterTodoDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            context = new AlabasterTodoDbContext(options);
            SeedDbWithMockTodoItems(context);
            repository = new TodoItemRepository(context);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            context.Database.EnsureDeleted(); // Remove from memory

            context.Dispose();
        }

        // Seed DB Methods //
        #region Mock Data
        protected static void SeedDbWithMockTodoItems(AlabasterTodoDbContext context)
        {
            var dataToSeed = GenertateMockTodoItems();
            var userToSeed = GenerateMockUser();
            context.Users.Add(userToSeed);
            foreach (var todo in dataToSeed)
            {
                context.TodoItems.Add(todo);
            }
            context.SaveChanges();
        }

        protected static User GenerateMockUser()
        {
            var user = new User()
            {
                FirstName = "Braydon",
                LastName = "Sutherland",
                Birthday = new DateTime(1990 / 03 / 30),
                Email = "BraydonSutherland@gmail.com",
                Password = "123456",
            };
            return user;

        }

        protected static TodoItem GenerateMockSingleTodoItem()
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

        protected static TodoItem GenerateMockSingleTodoItemToUpdate()
        {
            var todoItem = new TodoItem()
            {
                DateCreated = DateTime.Now,
                DateCompleted = null,
                Description = "Mop the Floors",
                IsCompleted = true,
                IsDeleted = true,
                UserId = 1,
            };
            return todoItem;
        }

        protected static List<TodoItem> GenertateMockTodoItems()
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
