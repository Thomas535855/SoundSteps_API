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

        public async Task Delete(int id)
        {
            await _userDAL.DeleteUser(id);
        }

        public async Task Update(UserDTO dto)
        {
            await _userDAL.UpdateUser(dto);
        }

        public async Task<List<UserDTO>> GetAll()
        {
            return await _userDAL.GetAllUsers();
        }

        public async Task<UserDTO?> GetById(int id)
        {
            return await _userDAL.GetUserById(id);
        }
    }
}
