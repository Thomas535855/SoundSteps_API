using SoundSteps.DAL.Models;

namespace SoundSteps.Interface.Interfaces
{
    public interface IUserDal
    {
        public Task<bool> UserExists(string username, string email);
        public Task AddInstrumentToUser(int userId, int instrumentId);
        public Task<List<UserDto>> GetAllUsers();
        public Task<UserDto?> GetUserById(int id);
        public Task AddUser(UserDto userDto);
        public Task UpdateUser(UserDto userDto);
        public Task DeleteUser(int id);
        public Task DeleteUserByEmail(string email);
    }
}
