using Microsoft.EntityFrameworkCore;
using SoundSteps.DAL;
using SoundSteps.DAL.DALs;
using SoundSteps.Interface.Interfaces;
using SoundSteps.Logic.Containers;
using Moq;
using SoundSteps.DAL.Models;

namespace SoundSteps.Test.UnitTests.Containers
{
    [TestClass]
    public class UserContainerTest
    {
        private Mock<IUserDAL> _userDAL;
        private UserContainer _userContainer;

        [TestInitialize]
        public void Setup()
        {
            _userDAL = new Mock<IUserDAL>();
            _userContainer = new UserContainer(_userDAL.Object);
        }

        [TestMethod]
        public async Task Add_ShouldCallAddUserOnce()
        {
            // Arrange
            var userDto = new UserDTO { UserId = 1, Username = "Test User" };

            // Act
            await _userContainer.Add(userDto);

            // Assert
            _userDAL.Verify(dal => dal.AddUser(userDto), Times.Once, "AddUser should be called once with the given DTO.");
        }

        [TestMethod]
        public async Task Delete_ShouldCallDeleteUserOnce()
        {
            // Arrange
            int userId = 1;

            // Act
            await _userContainer.Delete(userId);

            // Assert
            _userDAL.Verify(dal => dal.DeleteUser(userId), Times.Once, "DeleteUser should be called once with the given user ID.");
        }

        [TestMethod]
        public async Task Update_ShouldCallUpdateUserOnce()
        {
            // Arrange
            var userDto = new UserDTO { UserId = 1, Username = "Updated User" };

            // Act
            await _userContainer.Update(userDto);

            // Assert
            _userDAL.Verify(dal => dal.UpdateUser(userDto), Times.Once, "UpdateUser should be called once with the given DTO.");
        }

        [TestMethod]
        public async Task GetAll_ShouldReturnListOfUserDTOs()
        {
            // Arrange
            var users = new List<UserDTO>
            {
                new UserDTO { UserId = 1, Username = "User 1" },
                new UserDTO { UserId = 2, Username = "User 2" }
            };
            _userDAL.Setup(dal => dal.GetAllUsers()).ReturnsAsync(users);

            // Act
            var result = await _userContainer.GetAll();

            // Assert
            Assert.AreEqual(users, result, "GetAll should return the list of users provided by the DAL.");
            _userDAL.Verify(dal => dal.GetAllUsers(), Times.Once, "GetAllUsers should be called once.");
        }

        [TestMethod]
        public async Task GetById_ShouldReturnCorrectUserDTO()
        {
            // Arrange
            int userId = 1;
            var user = new UserDTO { UserId = userId, Username = "Test User" };
            _userDAL.Setup(dal => dal.GetUserById(userId)).ReturnsAsync(user);

            // Act
            var result = await _userContainer.GetById(userId);

            // Assert
            Assert.AreEqual(user, result, "GetById should return the user DTO provided by the DAL.");
            _userDAL.Verify(dal => dal.GetUserById(userId), Times.Once, "GetUserById should be called once with the given user ID.");
        }

        [TestMethod]
        public async Task GetById_ShouldReturnNullIfUserNotFound()
        {
            // Arrange
            int userId = 1;
            _userDAL.Setup(dal => dal.GetUserById(userId)).ReturnsAsync((UserDTO?)null);

            // Act
            var result = await _userContainer.GetById(userId);

            // Assert
            Assert.IsNull(result, "GetById should return null if the user is not found.");
            _userDAL.Verify(dal => dal.GetUserById(userId), Times.Once, "GetUserById should be called once with the given user ID.");
        }

    }
}
