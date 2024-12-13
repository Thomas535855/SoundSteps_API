using SoundSteps.DAL.Models;
using SoundSteps.Logic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundSteps.Test.UnitTests.Classes
{
    [TestClass]
    public class InstrumentTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            //arrange
            var instrumentDto = new InstrumentDto
            {
                InstrumentId = 1,
                Name = "name",
               // Users = new List<UserDto>(),
                Exercises = new List<ExerciseDto>(),
            };

            var instrument = new Instrument(instrumentDto);

            Assert.AreEqual(instrumentDto.InstrumentId, instrument.InstrumentId);
            Assert.AreEqual(instrumentDto.Name, instrument.Name);
           // Assert.AreEqual(instrumentDto.Users.Count, instrument.Users.Count);
            Assert.AreEqual(instrumentDto.Exercises.Count, instrument.Exercises.Count);
        }

        [TestMethod]
        public void ShouldConvertToDto()
        {
            //arrange
            var instrument = new Instrument(new InstrumentDto())
            {
                InstrumentId = 1,
                Name = "name",
             //   Users = new List<User>(),
                Exercises = new List<Exercise>(),
            };

            var instrumentDto = instrument.ToDto();

            Assert.AreEqual(instrument.InstrumentId, instrumentDto.InstrumentId);
            Assert.AreEqual(instrument.Name, instrumentDto.Name);
           // Assert.AreEqual(instrument.Users.Count, instrumentDto.Users.Count);
            Assert.AreEqual(instrument.Exercises.Count, instrumentDto.Exercises.Count);
        }
    }
}
