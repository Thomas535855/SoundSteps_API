using SoundSteps.DAL.Models;

namespace SoundSteps.Interface.Interfaces
{
    public interface IUserDAL
    {
        public Task<List<UserDTO>> GetAllUsers();
        public Task<UserDTO?> GetUserById(int id);
        public Task AddUser(UserDTO userDTO);
        public Task UpdateUser(UserDTO userDTO);
        public Task DeleteUser(int id);
    }
}
