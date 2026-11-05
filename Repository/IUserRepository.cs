using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        User AddUser(User user);
        User GetUserById(int id);
        User Login(LoginUser loginUser);
        User UpdateUser(int id, User userToUpdate);
    }
}