using SoundSteps.DAL.Models;
using SoundSteps.Logic.Classes;

namespace SoundSteps.Test.UnitTests.Classes
{
    [TestClass]
    public class CommentTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            //arrange
            var commentDto = new CommentDto
            {
                CommentId = 1,
                ExerciseId = 1,
                Content = "content",
                User = new UserDto(),
            };

            var comment = new Comment(commentDto);

            Assert.AreEqual(commentDto.CommentId, comment.CommentId);
            Assert.AreEqual(commentDto.ExerciseId, comment.ExerciseId);
            Assert.AreEqual(commentDto.Content, comment.Content);
            Assert.AreEqual(commentDto.User.UserId, comment.User.UserId);
        }

        [TestMethod]
        public void ShouldConvertToDto()
        {
            //arrange
            var commentDto = new CommentDto
            {
                CommentId = 1,
                ExerciseId = 1,
                Content = "content",
                User = new UserDto(),
            };

            var comment = new Comment(commentDto)
            {
                CommentId = 1,
                ExerciseId = 1,
                Content = "content",
                User = new User(new UserDto()),
            };

            //act
            var resultDto = comment.ToDto();


            //assert
            Assert.AreEqual(comment.CommentId, resultDto.CommentId);
            Assert.AreEqual(comment.ExerciseId, resultDto.ExerciseId);
            Assert.AreEqual(comment.Content, resultDto.Content);
            Assert.AreEqual(comment.User.UserId, resultDto.User.UserId);
        }
    }
}
