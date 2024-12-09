using SoundSteps.DAL.Models;

namespace SoundSteps.Interface.Interfaces
{
    public interface IInstrumentDal
    {
        public Task<List<InstrumentDto>> GetAllInstruments();
        public Task<InstrumentDto?> GetInstrumentById(int id);
        public Task AddInstrument(InstrumentDto instrumentDto);
        public Task UpdateInstrument(InstrumentDto instrumentDto);
        public Task DeleteInstrument(int id);
    }
}
