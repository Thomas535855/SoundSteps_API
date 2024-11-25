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
            var exerciseDto = new ExerciseDTO
            {
                ExerciseId = 1,
                InstrumentId = 1,
                SkillLevel = 1,
                Likes = 1,
                Comments = new List<CommentDTO>(),
                Instrument = new InstrumentDTO(),
                Users = new List<UserDTO>(),
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
        public void ShouldConvertToDTO()
        {
            //arrange
            var exerciseDTO = new ExerciseDTO
            {
                ExerciseId = 1,
                InstrumentId = 1,
                SkillLevel = 1,
                Likes = 1,
                Comments = new List<CommentDTO>(),
                Instrument = new InstrumentDTO(),
                Users = new List<UserDTO>(),
            };

            var exercise = new Exercise(exerciseDTO)
            {
                ExerciseId = 1,
                InstrumentId = 1,
                SkillLevel = 1,
                Likes = 1,
                Comments = new List<Comment>(),
                Instrument = new Instrument(new InstrumentDTO()),
                Users = new List<User>(),
            };

            //act
            var resultDTO = exercise.ToDTO();

            Assert.AreEqual(exercise.ExerciseId, resultDTO.ExerciseId);
            Assert.AreEqual(exercise.InstrumentId, resultDTO.InstrumentId);
            Assert.AreEqual(exercise.SkillLevel, resultDTO.SkillLevel);
            Assert.AreEqual(exercise.Likes, resultDTO.Likes);
            Assert.AreEqual(exercise.Comments.Count, resultDTO.Comments.Count);
            Assert.AreEqual(exercise.Instrument.InstrumentId, resultDTO.Instrument.InstrumentId);
            Assert.AreEqual(exercise.Users.Count, resultDTO.Users.Count);
        }

    }
}
