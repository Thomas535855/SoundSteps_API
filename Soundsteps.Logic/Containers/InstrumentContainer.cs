using SoundSteps.DAL.Models;
using SoundSteps.Interface.Interfaces;

namespace SoundSteps.Logic.Containers
{
    public class InstrumentContainer
    {
        private readonly IInstrumentDAL _instrumentDAL;

        public InstrumentContainer(IInstrumentDAL instrumentDAL)
        {
            _instrumentDAL = instrumentDAL;
        }

        public async Task Add(InstrumentDTO dto)
        {
            await _instrumentDAL.AddInstrument(dto);
        }

        public async Task Delete(int id)
        {
            await _instrumentDAL.DeleteInstrument(id);
        }

        public async Task Update(InstrumentDTO dto)
        {
            await _instrumentDAL.UpdateInstrument(dto);
        }

        public async Task<List<InstrumentDTO>> GetAll()
        {
            return await _instrumentDAL.GetAllInstruments();
        }

        public async Task<InstrumentDTO?> GetById(int id)
        {
            return await _instrumentDAL.GetInstrumentById(id);
        }
    }
}
