using Microsoft.AspNetCore.Mvc;
using SoundSteps.DAL.Models;
using SoundSteps.Logic.Containers;

namespace SoundSteps.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentController : ControllerBase
    {
        private readonly InstrumentContainer _instrumentContainer;

        public InstrumentController(InstrumentContainer instrumentContainer)
        {
            _instrumentContainer = instrumentContainer;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<InstrumentDto>> CreateInstrument(InstrumentDto instrument)
        {
            try
            {
                await _instrumentContainer.Add(instrument);
                return Ok(instrument);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<InstrumentDto>> DeleteInstrument(int id)
        {
            try
            {
                await _instrumentContainer.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<InstrumentDto>> UpdateInstrument(InstrumentDto instrument)
        {
            try
            {
                await _instrumentContainer.Update(instrument);
                return Ok(instrument);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllInstruments()
        {
            try
            {
                var instruments = await _instrumentContainer.GetAll();
                return Ok(instruments);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<InstrumentDto>> GetInstrumentById(int id)
        {
            try
            {
                var instrument = await _instrumentContainer.GetById(id);
                return Ok(instrument);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
