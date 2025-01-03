using Microsoft.EntityFrameworkCore;
using SoundSteps.DAL.Models;
using SoundSteps.Interface.Interfaces;

namespace SoundSteps.DAL.DALs
{
    public class InstrumentDal(SoundStepsDbContext context) : IInstrumentDal
    {
        public async Task AddInstrument(InstrumentDto instrumentDto)
        {
            context.Instruments.Add(instrumentDto);
            await context.SaveChangesAsync();
        }

        public async Task DeleteInstrument(int id)
        {
            var instrument = await context.Instruments.FindAsync(id);
            if (instrument != null) context.Instruments.Remove(instrument);
            await context.SaveChangesAsync();
        }

        public async Task<List<InstrumentDto>> GetAllInstruments()
        {
            return await context.Instruments.ToListAsync();
        }

        public async Task<InstrumentDto?> GetInstrumentById(int id)
        {
            var instrument = await context.Instruments.FindAsync(id);
            if (instrument == null)
            {
                throw new Exception("Instrument not found");
            }
            return instrument;
        }

        public async Task UpdateInstrument(InstrumentDto instrumentDto)
        {
            var existingInstrument = context.Instruments.FirstOrDefaultAsync(instrument => instrument.InstrumentId == instrumentDto.InstrumentId);

            if (existingInstrument.Result != null)
            {
                existingInstrument.Result.Name = instrumentDto.Name;
            }
            await context.SaveChangesAsync();
        }
    }

}
