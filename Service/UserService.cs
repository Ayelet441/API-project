using Repository;
using System.Text.Json;
using Entities;

namespace Service
{
    public class UserService : IUserService
    {
        private IUserRepository repository;

        public UserService(IUserRepository userRepository)
        {
            this.repository = userRepository;
        }

        public User GetUserById(int id)
        {
            return repository.GetUserById(id);
        }

        public User AddUser(User User)
        {
            return repository.AddUser(User);
        }

        public User Login(LoginUser loginUser)
        {
            return repository.Login(loginUser);
        }

        public User UpdateUser(int id, User userToUpdate)
        {
            return repository.UpdateUser(id, userToUpdate);
        }
    }
}
