using Microsoft.EntityFrameworkCore;
using SoundSteps.DAL.Models;
using SoundSteps.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundSteps.DAL.DALs
{
    public class InstrumentDAL(SoundStepsDbContext context) : IInstrumentDAL
    {
        public async Task AddInstrument(InstrumentDTO instrumentDTO)
        {
            context.Instruments.Add(instrumentDTO);
            await context.SaveChangesAsync();
        }

        public async Task DeleteInstrument(int id)
        {
            var instrument = await context.Instruments.FindAsync(id);
            context.Instruments.Remove(instrument);
            await context.SaveChangesAsync();
        }

        public async Task<List<InstrumentDTO>> GetAllInstruments()
        {
            return await context.Instruments.ToListAsync();
        }

        public async Task<InstrumentDTO?> GetInstrumentById(int id)
        {
            var instrument = await context.Instruments.FindAsync(id);
            if (instrument == null)
            {
                throw new Exception("Instrument not found");
            }
            return instrument;
        }

        public async Task UpdateInstrument(InstrumentDTO instrumentDTO)
        {
            var existingInstrument = context.Instruments.FirstOrDefaultAsync(instrument => instrument.InstrumentId == instrumentDTO.InstrumentId);

            if (existingInstrument.Result != null)
            {
                existingInstrument.Result.Name = instrumentDTO.Name;
            }
            await context.SaveChangesAsync();
        }
    }

}
