using MVC.Domain.Entities;

namespace MVC.Infrastructure.Repositories.UserRepositories;
public interface IUserRepository
{
    Task<User> GetUserById(string userId);
    Task<User> GetUserByUserName(string userName);
    Task<List<User>> GetUsers(string userName);
    Task<bool> DeleteUser(string userId);
    Task<bool> UpdateUser(User user);
    Task<bool> AddUser(User user);
}
