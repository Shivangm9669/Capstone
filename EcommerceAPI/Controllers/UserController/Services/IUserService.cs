using EcommerceAPI.Models;

namespace EcommerceAPI.Controllers.UserController.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User?> GetUser(Guid id);
        Task<User> CreateUser(User user);
        Task<bool> UpdateUser(Guid id, User user);
        Task<bool> DeleteUser(Guid id);
    }
}
