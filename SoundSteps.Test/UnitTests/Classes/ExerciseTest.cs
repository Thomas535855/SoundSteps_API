using SoundSteps.DAL.Models;
using SoundSteps.Logic.Classes;

namespace SoundSteps.Test.UnitTests.Classes
{
    [TestClass]
    public class ExerciseTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            //arrange
            var exerciseDto = new ExerciseDto
            {
                ExerciseId = 1,
                InstrumentId = 1,
                SkillLevel = 1,
                Likes = 1,
                Comments = new List<CommentDto>(),
                Instrument = new InstrumentDto(),
                Users = new List<UserDto>(),
            };

            var exercise = new Exercise(exerciseDto);

            Assert.AreEqual(exerciseDto.ExerciseId, exercise.ExerciseId);
            Assert.AreEqual(exerciseDto.InstrumentId, exercise.InstrumentId);
            Assert.AreEqual(exerciseDto.SkillLevel, exercise.SkillLevel);
            Assert.AreEqual(exerciseDto.Likes, exercise.Likes);
            Assert.AreEqual(exerciseDto.Comments.Count, exercise.Comments.Count);
            Assert.AreEqual(exerciseDto.Instrument.InstrumentId, exercise.Instrument.InstrumentId);
            Assert.AreEqual(exerciseDto.Users.Count, exercise.Users.Count);
        }

        [TestMethod]
        public void ShouldConvertToDto()
        {
            //arrange
            var exerciseDto = new ExerciseDto
            {
                ExerciseId = 1,
                InstrumentId = 1,
                SkillLevel = 1,
                Likes = 1,
                Comments = new List<CommentDto>(),
                Instrument = new InstrumentDto(),
                Users = new List<UserDto>(),
            };

            var exercise = new Exercise(exerciseDto)
            {
                ExerciseId = 1,
                InstrumentId = 1,
                SkillLevel = 1,
                Likes = 1,
                Comments = new List<Comment>(),
                Instrument = new Instrument(new InstrumentDto()),
                Users = new List<User>(),
            };

            //act
            var resultDto = exercise.ToDto();

            Assert.AreEqual(exercise.ExerciseId, resultDto.ExerciseId);
            Assert.AreEqual(exercise.InstrumentId, resultDto.InstrumentId);
            Assert.AreEqual(exercise.SkillLevel, resultDto.SkillLevel);
            Assert.AreEqual(exercise.Likes, resultDto.Likes);
            Assert.AreEqual(exercise.Comments.Count, resultDto.Comments.Count);
            Assert.AreEqual(exercise.Instrument.InstrumentId, resultDto.Instrument.InstrumentId);
            Assert.AreEqual(exercise.Users.Count, resultDto.Users.Count);
        }

    }
}
