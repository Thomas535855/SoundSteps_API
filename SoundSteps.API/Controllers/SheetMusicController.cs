using Microsoft.AspNetCore.Mvc;

namespace SoundSteps.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SheetMusicController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<SheetMusic> GetSheetMusic()
        {
            List<SheetMusic> sheetMusic = new List<SheetMusic>
            {
                new SheetMusic { Id = 1, Title = "Title1", Composer = "Composer1"},
                new SheetMusic { Id = 2, Title = "Title2", Composer = "Composer2"},
            };

            return sheetMusic;
        }
    }
}
