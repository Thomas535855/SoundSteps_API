using Microsoft.AspNetCore.Mvc;
using SoundSteps.DAL.Models;
using SoundSteps.Logic.Containers;

namespace SoundSteps.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContainer _userContainer;

        public UsersController(UserContainer userContainer)
        {
            _userContainer = userContainer;
        }

        [HttpPost]
        [Route("/Register")]
        public async Task<ActionResult<UserDTO>> PostUser(UserDTO user)
        {
            try
            {
                await _userContainer.Add(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
