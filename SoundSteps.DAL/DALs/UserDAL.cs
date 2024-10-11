using Microsoft.EntityFrameworkCore;
using SoundSteps.DAL.Models;
using SoundSteps.Interface.Interfaces;
using System.Threading.Tasks.Dataflow;

namespace SoundSteps.DAL.DALs
{
    public class UserDAL(SoundStepsDbContext context) : IUserDAL
    {
        public async Task AddUser(UserDTO user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
        }

        public Task DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }
    }
}
