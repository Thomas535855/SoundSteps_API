using SoundSteps.DAL.Models;
using SoundSteps.Interface.Interfaces;

namespace SoundSteps.Logic.Containers
{
    public class InstrumentContainer
    {
        private readonly IInstrumentDal _instrumentDal;

        public InstrumentContainer(IInstrumentDal instrumentDal)
        {
            _instrumentDal = instrumentDal;
        }

        public async Task Add(InstrumentDto dto)
        {
            await _instrumentDal.AddInstrument(dto);
        }

        public async Task Delete(int id)
        {
            await _instrumentDal.DeleteInstrument(id);
        }

        public async Task Update(InstrumentDto dto)
        {
            await _instrumentDal.UpdateInstrument(dto);
        }

        public async Task<List<InstrumentDto>> GetAll()
        {
            return await _instrumentDal.GetAllInstruments();
        }

        public async Task<InstrumentDto?> GetById(int id)
        {
            return await _instrumentDal.GetInstrumentById(id);
        }
    }
}
