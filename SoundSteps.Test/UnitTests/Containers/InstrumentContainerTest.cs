using Moq;
using SoundSteps.DAL.Models;
using SoundSteps.Interface.Interfaces;
using SoundSteps.Logic.Containers;

namespace SoundSteps.Test.UnitTests.Containers
{
    [TestClass]
    public class InstrumentContainerTest
    {
        private Mock<IInstrumentDal> _instrumentDal;
        private InstrumentContainer _instrumentContainer;

        [TestInitialize]
        public void Setup()
        {
            _instrumentDal = new Mock<IInstrumentDal>();
            _instrumentContainer = new InstrumentContainer(_instrumentDal.Object);
        }

        [TestMethod]
        public async Task Add_ShouldAddInstrument()
        {
            // Arrange
            var instrumentDto = new InstrumentDto { InstrumentId = 1, Name = "Guitar" };

            // Act
            await _instrumentContainer.Add(instrumentDto);

            // Assert
            _instrumentDal.Verify(dal => dal.AddInstrument(instrumentDto), Times.Once);
        }

        [TestMethod]
        public async Task Delete_ShouldDeleteInstrument()
        {
            // Arrange
            int id = 1;

            // Act
            await _instrumentContainer.Delete(id);

            // Assert
            _instrumentDal.Verify(dal => dal.DeleteInstrument(id), Times.Once);
        }

        [TestMethod]
        public async Task Update_ShouldUpdateInstrument()
        {
            // Arrange
            var instrumentDto = new InstrumentDto { InstrumentId = 1, Name = "Drums" };

            // Act
            await _instrumentContainer.Update(instrumentDto);

            // Assert
            _instrumentDal.Verify(dal => dal.UpdateInstrument(instrumentDto), Times.Once);
        }

        [TestMethod]
        public async Task GetAll_ShouldReturnAllInstruments()
        {
            // Arrange
            var expectedInstruments = new List<InstrumentDto>
            {
                new InstrumentDto { InstrumentId = 1, Name = "Piano" },
                new InstrumentDto { InstrumentId = 2, Name = "Violin" }
            };
            _instrumentDal.Setup(dal => dal.GetAllInstruments()).ReturnsAsync(expectedInstruments);

            // Act
            var result = await _instrumentContainer.GetAll();

            // Assert
            _instrumentDal.Verify(dal => dal.GetAllInstruments(), Times.Once);
            CollectionAssert.AreEqual(expectedInstruments, result);
        }

        [TestMethod]
        public async Task GetById_ShouldReturnCorrectInstrument()
        {
            // Arrange
            int id = 1;
            var expectedInstrument = new InstrumentDto { InstrumentId = id, Name = "Flute" };
            _instrumentDal.Setup(dal => dal.GetInstrumentById(id)).ReturnsAsync(expectedInstrument);

            // Act
            var result = await _instrumentContainer.GetById(id);

            // Assert
            _instrumentDal.Verify(dal => dal.GetInstrumentById(id), Times.Once);
            Assert.AreEqual(expectedInstrument, result);
        }

        [TestMethod]
        public async Task GetById_InstrumentNotFound()
        {
            // Arrange
            int id = 0;
            _instrumentDal.Setup(dal => dal.GetInstrumentById(id)).ReturnsAsync((InstrumentDto?)null);

            // Act
            var result = await _instrumentContainer.GetById(id);

            // Assert
            _instrumentDal.Verify(dal => dal.GetInstrumentById(id), Times.Once);
            Assert.IsNull(result);
        }
    }
}
