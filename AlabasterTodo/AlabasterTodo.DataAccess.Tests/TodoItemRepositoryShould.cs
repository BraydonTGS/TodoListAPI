using AlabasterTodo.DataAccess.Tests.Helpers;

namespace AlabasterTodo.DataAccess.Tests
{
    [TestClass]
    public class TodoItemRepositoryShould : InMemoryTestBase
    {

        [TestMethod]
        public async Task ReturnTodoItemsInCollectionNotNullAsync()
        {
            var sut = await repository.GetAllTodoItemsAsync();

            Assert.IsNotNull(sut);
        }

        [TestMethod]
        public async Task ReturnAllTodoItemsInCollectionAsync()
        {
            var sut = await repository.GetAllTodoItemsAsync();

            Assert.AreEqual(3, sut?.Count());
        }

        [TestMethod]
        public async Task GetTodoItemByIdandNotReturnNull()
        {
            var sut = await repository.GetTodoItemByIdAsync(1);
            Assert.IsNotNull(sut);
        }

        [TestMethod]
        public async Task GetTodoItemByIdReturnsCorrectTodoItem()
        {
            var sut = await repository.GetTodoItemByIdAsync(1);

            Assert.AreEqual(sut.Id, 1);
            Assert.AreEqual(sut.Description, "Take out the trash");
            Assert.AreEqual(sut.IsCompleted, false);
            Assert.AreEqual(sut.IsDeleted, false);

        }

        [TestMethod]
        public async Task CreateNewTodoItemandNotReturnNull()
        {
            var todo = GenerateMockSingleTodoItem();

            var sut = await repository.CreateNewTodoItemAsync(todo);

            Assert.IsNotNull(sut);
        }

        [TestMethod]
        public async Task CreateNewTodoItemandReturnsTodoItem()
        {
            var todo = GenerateMockSingleTodoItem();

            var sut = await repository.CreateNewTodoItemAsync(todo);

            Assert.AreEqual(sut.Id, 4);
            Assert.AreEqual(sut.Description, "Organize the Garage");
            Assert.AreEqual(sut.IsCompleted, false);
            Assert.AreEqual(sut.IsDeleted, false);
        }

        [TestMethod]
        public async Task UpdateTodoItemAndNotReturnNull()
        {
            var todo = GenerateMockSingleTodoItemToUpdate();
            var sut = await repository.UpdateTodoItemAsync(1, todo);

            Assert.IsNotNull(sut);
        }

        [TestMethod]
        public async Task UpdateTodoItemAndReturnUpdatedValues()
        {
            var todo = GenerateMockSingleTodoItemToUpdate();
            var sut = await repository.UpdateTodoItemAsync(1, todo);
            Assert.AreEqual(sut.Id, 1);
            Assert.AreEqual(sut.Description, "Mop the Floors");
            Assert.AreEqual(sut.IsCompleted, true);
            Assert.AreEqual(sut.IsDeleted, true);
        }

        [TestMethod]
        public async Task DeleteTodoItemByIdAndNotReturnFalse()
        {
            var sut = await repository.DeleteTodoItemAsync(1);
            Assert.IsTrue(sut);
        }

        [TestMethod]
        public async Task DeleteTodoItemWithWrongIdReturnsFalse()
        {
            var sut = await repository.DeleteTodoItemAsync(7);
            Assert.IsFalse(sut);
        }

    }
}
