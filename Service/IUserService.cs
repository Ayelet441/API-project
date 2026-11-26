using Entities;

namespace Service
{
    public interface IUserService
    {
        User AddUser(User User);
        Task<User> GetUserById(int id);
        Task<User> Login(LoginUser loginUser);
        Task<User> UpdateUser(int id, User userToUpdate);
    }
}