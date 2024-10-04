using SoundSteps.DAL.Models;

namespace SoundSteps.Interface.Interfaces
{
    public interface IUserDAL
    {
        public List<UserDTO> GetAll();
        public UserDTO GetById(int id);
        public Task AddUser(UserDTO userDTO);
        public Task UpdateUser(UserDTO userDTO);
        public Task DeleteUser(int id);
    }
}
