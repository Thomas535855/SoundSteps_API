using SoundSteps.DAL.Models;

namespace SoundSteps.Interface.Interfaces
{
    public interface IInstrumentDAL
    {
        public Task<List<InstrumentDTO>> GetAllInstruments();
        public Task<InstrumentDTO?> GetInstrumentById(int id);
        public Task AddInstrument(InstrumentDTO instrumentDTO);
        public Task UpdateInstrument(InstrumentDTO instrumentDTO);
        public Task DeleteInstrument(int id);
    }
}
