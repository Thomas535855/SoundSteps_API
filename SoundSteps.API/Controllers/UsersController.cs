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
        private readonly InstrumentContainer _instrumentContainer;

        public UsersController(UserContainer userContainer, InstrumentContainer instrumentContainer)
        {
            _userContainer = userContainer;
            _instrumentContainer = instrumentContainer;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<UserDto>> PostUser(UserDto user)
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
        
        [HttpPost]
        [Route("AddInstrumentToUser")]
        public async Task<ActionResult<UserDto>> AddInstrumentToUser(int userId, string instrumentName)
        {
            try
            {
                await _userContainer.AddInstrumentToUser(userId, instrumentName);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
        

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<UserDto>> DeleteUser(int id)
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
        
        [HttpDelete]
        [Route("DeleteByEmail")]
        public async Task<ActionResult<UserDto>> DeleteUserByEmail(string email)
        {
            try
            {
                await _userContainer.DeleteByEmail(email);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<UserDto>> UpdateUser([FromBody] UserDto user)
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
        public async Task<ActionResult<UserDto>> GetUserById(int id)
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
