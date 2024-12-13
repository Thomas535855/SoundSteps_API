using SoundSteps.DAL.Models;
using SoundSteps.Interface.Interfaces;
using SoundSteps.Logic.Classes;

namespace SoundSteps.Logic.Containers
{
    public class UserContainer
    {
        private readonly IUserDal _userDal;

        public UserContainer(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<bool> UserExists(string username, string email)
        {
            return await _userDal.UserExists(username, email);
        }
        
        public async Task AddInstrumentToUser(int userId, string instrumentName)
        {
            await _userDal.AddInstrumentToUser(userId, instrumentName);
        }
        
        public async Task Add(UserDto dto)
        {
            await _userDal.AddUser(dto);
        }

        public async Task Delete(int id)
        {
            await _userDal.DeleteUser(id);
        }
        
        public async Task DeleteByEmail(string email)
        {
            await _userDal.DeleteUserByEmail(email);
        }
        
        public async Task Update(UserDto dto)
        {
            await _userDal.UpdateUser(dto);
        }

        public async Task<List<UserDto>> GetAll()
        {
            return await _userDal.GetAllUsers();
        }

        public async Task<UserDto?> GetById(int id)
        {
            return await _userDal.GetUserById(id);
        }
    }
}
