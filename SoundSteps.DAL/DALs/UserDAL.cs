using Microsoft.EntityFrameworkCore;
using SoundSteps.DAL.Models;
using SoundSteps.Interface.Interfaces;
using System.Threading.Tasks.Dataflow;

namespace SoundSteps.DAL.DALs
{
    public class UserDAL(SoundStepsDbContext context) : IUserDAL
    {
        public async Task<bool> UserExists(string username, string email)
        {
            return await context.Users.AnyAsync(u => u.Username == username || u.Email == email);
        }

        public async Task AddUser(UserDTO user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await context.Users.FindAsync(id);
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<UserDTO?> GetUserById(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        public async Task UpdateUser(UserDTO userDTO)
        {
            var existingUser = context.Users.FirstOrDefaultAsync(user => user.UserId == userDTO.UserId);

            if (existingUser.Result != null)
            {
                existingUser.Result.Username = userDTO.Username;
                existingUser.Result.Email = userDTO.Email;
                existingUser.Result.Password = userDTO.Password;
                existingUser.Result.SkillLevel = userDTO.SkillLevel;
            }
            await context.SaveChangesAsync();
        }
    }
}
