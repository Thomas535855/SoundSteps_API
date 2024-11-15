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
        [Route("Register")]
        public async Task<ActionResult<UserDTO>> PostUser(UserDTO user)
        {
            try
            {
                if (await _userContainer.UserExists(user.Username, user.Email))
                {
                    return Conflict(new { Message = "Username or Email already exists." });
                }

                await _userContainer.Add(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Error = ex.Message });
            }
        }


        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<UserDTO>> DeleteUser(int id)
        {
            try
            {
                await _userContainer.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<UserDTO>> UpdateUser(UserDTO user)
        {
            try
            {
                await _userContainer.Update(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userContainer.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            try
            {
                var user = await _userContainer.GetById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
