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

        public async Task<User> GetUserById(int id)
        {
            return await repository.GetUserById(id);
        }

        public User AddUser(User User)
        {
            return repository.AddUser(User);
        }

        public async Task<User> Login(LoginUser loginUser)
        {
            return await repository.Login(loginUser);
        }

        public async Task<User> UpdateUser(int id, User userToUpdate)
        {
            return await repository.UpdateUser(id, userToUpdate);
        }
    }
}
