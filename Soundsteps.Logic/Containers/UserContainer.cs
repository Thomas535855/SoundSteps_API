using SoundSteps.DAL.Models;
using SoundSteps.Interface.Interfaces;
using SoundSteps.Logic.Classes;

namespace SoundSteps.Logic.Containers
{
    public class UserContainer
    {
        private readonly IUserDAL _userDAL;

        public UserContainer(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public async Task Add(UserDTO dto)
        {
            await _userDAL.AddUser(dto);
        }
    }
}
