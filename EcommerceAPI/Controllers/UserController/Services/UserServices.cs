using EcommerceAPI.Data;
using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Controllers.UserController.Services
{
    public class UserService : IUserService
    {
        private readonly EcommerceDbContext _context;

        public UserService(EcommerceDbContext context) => _context = context;

        public async Task<IEnumerable<User>> GetUsers()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here
                throw new Exception("An error occurred while retrieving users.", ex);
            }
        }

        public async Task<User?> GetUser(Guid id)
        {
            try
            {
                return await _context.Users.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here
                throw new Exception($"An error occurred while retrieving the user with ID {id}.", ex);
            }
        }

        public async Task<User> CreateUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here
                throw new Exception("An error occurred while creating the user.", ex);
            }
        }

        public async Task<bool> UpdateUser(Guid id, User user)
        {
            try
            {
                var existingUser = await _context.Users.FindAsync(id);
                if (existingUser == null) return false;

                existingUser.Username = user.Username;
                existingUser.Email = user.Email;
                existingUser.Role = user.Role;
                existingUser.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here
                throw new Exception($"An error occurred while updating the user with ID {id}.", ex);
            }
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null) return false;

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here
                throw new Exception($"An error occurred while deleting the user with ID {id}.", ex);
            }
        }
    }
}
