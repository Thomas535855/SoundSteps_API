using SoundSteps.Interface.Interfaces;
using SoundSteps.Logic.Containers;
using Moq;
using SoundSteps.DAL.Models;

namespace SoundSteps.Test.UnitTests.Containers
{
    [TestClass]
    public class UserContainerTest
    {
        private Mock<IUserDal> _userDal;
        private UserContainer _userContainer;

        [TestInitialize]
        public void Setup()
        {
            _userDal = new Mock<IUserDal>();
            _userContainer = new UserContainer(_userDal.Object);
        }

        [TestMethod]
        public async Task Add_ShouldAddUser()
        {
            // Arrange
            var userDto = new UserDto { UserId = 1, Username = "Test User" };

            // Act
            await _userContainer.Add(userDto);

            // Assert
            _userDal.Verify(dal => dal.AddUser(userDto), Times.Once, "AddUser should be called once with the given DTO.");
        }

        [TestMethod]
        public async Task Delete_ShouldDeleteUser()
        {
            // Arrange
            int userId = 1;

            // Act
            await _userContainer.Delete(userId);

            // Assert
            _userDal.Verify(dal => dal.DeleteUser(userId), Times.Once, "DeleteUser should be called once with the given user ID.");
        }

        [TestMethod]
        public async Task Update_ShouldUpdateUser()
        {
            // Arrange
            var userDto = new UserDto { UserId = 1, Username = "Updated User" };

            // Act
            await _userContainer.Update(userDto);

            // Assert
            _userDal.Verify(dal => dal.UpdateUser(userDto), Times.Once, "UpdateUser should be called once with the given DTO.");
        }

        [TestMethod]
        public async Task GetAll_ShouldReturnAllUsers()
        {
            // Arrange
            var users = new List<UserDto>
            {
                new UserDto { UserId = 1, Username = "User 1" },
                new UserDto { UserId = 2, Username = "User 2" }
            };
            _userDal.Setup(dal => dal.GetAllUsers()).ReturnsAsync(users);

            // Act
            var result = await _userContainer.GetAll();

            // Assert
            Assert.AreEqual(users, result, "GetAll should return the list of users provided by the DAL.");
            _userDal.Verify(dal => dal.GetAllUsers(), Times.Once, "GetAllUsers should be called once.");
        }

        [TestMethod]
        public async Task GetById_ShouldReturnCorrectUser()
        {
            // Arrange
            int userId = 1;
            var user = new UserDto { UserId = userId, Username = "Test User" };
            _userDal.Setup(dal => dal.GetUserById(userId)).ReturnsAsync(user);

            // Act
            var result = await _userContainer.GetById(userId);

            // Assert
            Assert.AreEqual(user, result, "GetById should return the user DTO provided by the DAL.");
            _userDal.Verify(dal => dal.GetUserById(userId), Times.Once, "GetUserById should be called once with the given user ID.");
        }

        [TestMethod]
        public async Task GetById_UserNotFound()
        {
            // Arrange
            int userId = 1;
            _userDal.Setup(dal => dal.GetUserById(userId)).ReturnsAsync((UserDto?)null);

            // Act
            var result = await _userContainer.GetById(userId);

            // Assert
            Assert.IsNull(result, "GetById should return null if the user is not found.");
            _userDal.Verify(dal => dal.GetUserById(userId), Times.Once, "GetUserById should be called once with the given user ID.");
        }

    }
}
