using Microsoft.EntityFrameworkCore;
using SoundSteps.DAL.Models;
using SoundSteps.Interface.Interfaces;
using System.Threading.Tasks.Dataflow;

namespace SoundSteps.DAL.DALs
{
    public class UserDal(SoundStepsDbContext context) : IUserDal
    {
        public async Task<bool> UserExists(string username, string email)
        {
            return await context.Users.AnyAsync(u => u.Username == username || u.Email == email);
        }
        
        public async Task AddInstrumentToUser(int userId, string instrumentName)
        {
            var user = await context.Users.FindAsync(userId);
            var instrument = await context.Instruments.FirstOrDefaultAsync(i => i.Name == instrumentName);
            user.Instruments.Add(instrument);
            
            await context.SaveChangesAsync();
        }
        
        public async Task AddUser(UserDto user)
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
        
        public async Task DeleteUserByEmail(string email)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }
        
        public async Task<List<UserDto>> GetAllUsers()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<UserDto?> GetUserById(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        public async Task UpdateUser(UserDto userDto)
        {
            var existingUser = await context.Users
                .FirstOrDefaultAsync(user => user.UserId == userDto.UserId);

            
            if (existingUser != null)
            {
                if (userDto.SkillLevel != null)
                {
                    existingUser.SkillLevel = userDto.SkillLevel;
                }

                if (!string.IsNullOrEmpty(userDto.Username))
                {
                    existingUser.Username = userDto.Username;
                }

                if (!string.IsNullOrEmpty(userDto.Email))
                {
                    existingUser.Email = userDto.Email;
                }

                
                existingUser.Password = userDto.Password;
                

                await context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("User not found");
            }
        }

    }
}
