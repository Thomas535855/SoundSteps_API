using Moq;
using SoundSteps.DAL.Models;
using SoundSteps.Interface.Interfaces;
using SoundSteps.Logic.Containers;

namespace SoundSteps.Test.UnitTests.Containers
{
    [TestClass]
    public class InstrumentContainerTest
    {
        private Mock<IInstrumentDAL> _instrumentDAL;
        private InstrumentContainer _instrumentContainer;

        [TestInitialize]
        public void Setup()
        {
            _instrumentDAL = new Mock<IInstrumentDAL>();
            _instrumentContainer = new InstrumentContainer(_instrumentDAL.Object);
        }

        [TestMethod]
        public async Task Add_ShouldAddInstrument()
        {
            // Arrange
            var instrumentDTO = new InstrumentDTO { InstrumentId = 1, Name = "Guitar" };

            // Act
            await _instrumentContainer.Add(instrumentDTO);

            // Assert
            _instrumentDAL.Verify(dal => dal.AddInstrument(instrumentDTO), Times.Once);
        }

        [TestMethod]
        public async Task Delete_ShouldDeleteInstrument()
        {
            // Arrange
            int id = 1;

            // Act
            await _instrumentContainer.Delete(id);

            // Assert
            _instrumentDAL.Verify(dal => dal.DeleteInstrument(id), Times.Once);
        }

        [TestMethod]
        public async Task Update_ShouldUpdateInstrument()
        {
            // Arrange
            var instrumentDTO = new InstrumentDTO { InstrumentId = 1, Name = "Drums" };

            // Act
            await _instrumentContainer.Update(instrumentDTO);

            // Assert
            _instrumentDAL.Verify(dal => dal.UpdateInstrument(instrumentDTO), Times.Once);
        }

        [TestMethod]
        public async Task GetAll_ShouldReturnAllInstruments()
        {
            // Arrange
            var expectedInstruments = new List<InstrumentDTO>
            {
                new InstrumentDTO { InstrumentId = 1, Name = "Piano" },
                new InstrumentDTO { InstrumentId = 2, Name = "Violin" }
            };
            _instrumentDAL.Setup(dal => dal.GetAllInstruments()).ReturnsAsync(expectedInstruments);

            // Act
            var result = await _instrumentContainer.GetAll();

            // Assert
            _instrumentDAL.Verify(dal => dal.GetAllInstruments(), Times.Once);
            CollectionAssert.AreEqual(expectedInstruments, result);
        }

        [TestMethod]
        public async Task GetById_ShouldReturnCorrectInstrument()
        {
            // Arrange
            int id = 1;
            var expectedInstrument = new InstrumentDTO { InstrumentId = id, Name = "Flute" };
            _instrumentDAL.Setup(dal => dal.GetInstrumentById(id)).ReturnsAsync(expectedInstrument);

            // Act
            var result = await _instrumentContainer.GetById(id);

            // Assert
            _instrumentDAL.Verify(dal => dal.GetInstrumentById(id), Times.Once);
            Assert.AreEqual(expectedInstrument, result);
        }

        [TestMethod]
        public async Task GetById_InstrumentNotFound()
        {
            // Arrange
            int id = 0;
            _instrumentDAL.Setup(dal => dal.GetInstrumentById(id)).ReturnsAsync((InstrumentDTO?)null);

            // Act
            var result = await _instrumentContainer.GetById(id);

            // Assert
            _instrumentDAL.Verify(dal => dal.GetInstrumentById(id), Times.Once);
            Assert.IsNull(result);
        }
    }
}
