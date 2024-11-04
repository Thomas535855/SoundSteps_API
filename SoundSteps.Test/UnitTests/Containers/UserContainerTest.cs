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
        public async Task AddUserTest()
        {
            UserDTO userDTO = new UserDTO
            {
                UserId = 1,
                Username = "TestUser",
                Email = "TestEmail",
                Password = "TestPassword",
                SkillLevel = 1
            };

            _userDAL.Setup(dal => dal.AddUser(userDTO)).Returns(Task.CompletedTask);

            // Act
            await _userContainer.Add(userDTO);

            // Assert
            _userDAL.Verify(dal => dal.AddUser(It.Is<UserDTO>(u =>
                u.UserId == 1 &&
                u.Username == "TestUser" &&
                u.Email == "TestEmail" &&
                u.Password == "TestPassword" &&
                u.SkillLevel == 1)),
                Times.Once,
                "Expected AddUser to be called once with the correct UserDTO.");
        }
    }
}
