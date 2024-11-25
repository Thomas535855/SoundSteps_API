using SoundSteps.DAL.Models;
using SoundSteps.Logic.Classes;

namespace SoundSteps.Test.UnitTests.Classes
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            //arrange
            var userDto = new UserDTO
            {
                UserId = 1,
                Username = "username",
                Email = "email",
                Password = "password",
                SkillLevel = 1,
                Comments = new List<CommentDTO>(),
                Instruments = new List<InstrumentDTO>(),
            };

            var user = new User(userDto);

            Assert.AreEqual(userDto.UserId, user.UserId);
            Assert.AreEqual(userDto.Username, user.Username);
            Assert.AreEqual(userDto.Email, user.Email);
            Assert.AreEqual(userDto.Password, user.Password);
            Assert.AreEqual(userDto.SkillLevel, user.SkillLevel);
            Assert.AreEqual(userDto.Comments.Count, user.Comments.Count);
            Assert.AreEqual(userDto.Instruments.Count, user.Instruments.Count);
        }

        [TestMethod]
        public void ShouldConvertToDTO()
        {
            //arrange
            var user = new User(new UserDTO())
            {
                UserId = 1,
                Username = "username",
                Email = "email",
                Password = "password",
                SkillLevel = 1,
                Comments = new List<Comment>(),
                Instruments = new List<Instrument>(),
            };

            var userDto = user.ToDTO();

            Assert.AreEqual(user.UserId, userDto.UserId);
            Assert.AreEqual(user.Username, userDto.Username);
            Assert.AreEqual(user.Email, userDto.Email);
            Assert.AreEqual(user.Password, userDto.Password);
            Assert.AreEqual(user.SkillLevel, userDto.SkillLevel);
            Assert.AreEqual(user.Comments.Count, userDto.Comments.Count);
            Assert.AreEqual(user.Instruments.Count, userDto.Instruments.Count);
        }
    }
}
