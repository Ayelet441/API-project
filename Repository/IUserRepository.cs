using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        User AddUser(User user);
        Task<User> GetUserById(int id);
        Task<User> Login(LoginUser loginUser);
        Task<User> UpdateUser(int id, User userToUpdate);
    }
}