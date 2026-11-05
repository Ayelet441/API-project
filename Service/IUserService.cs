using Entities;

namespace Service
{
    public interface IUserService
    {
        User AddUser(User User);
        User GetUserById(int id);
        User Login(LoginUser loginUser);
        User UpdateUser(int id, User userToUpdate);
    }
}