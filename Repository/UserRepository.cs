using System.Text.Json;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        
        MyStorContext _dbcontext;

        public UserRepository(MyStorContext myStorContext)
        {
            _dbcontext = myStorContext;
        }

        public async Task<User> GetUserById(int id)
        {
            User user = await _dbcontext.Users.FindAsync(id);
            if (user == null)
                return null;
            return user;
        }

        public User AddUser(User user)
        {
            _dbcontext.Users.Add(user);
            _dbcontext.SaveChanges();
            return user;
        }

        public async Task<User> Login(LoginUser loginUser)
        {
            User user = await _dbcontext.Users.Where(u => u.Password == loginUser.Password && u.Email == loginUser.Email).FirstOrDefaultAsync();
            if (user == null)
                return null;
            return user;
        }

        public async Task<User> UpdateUser(int id, User userToUpdate)
        {
            User user = await _dbcontext.Users.FindAsync(id);
            if (user == null)
                return null;
            _dbcontext.Entry(user).CurrentValues.SetValues(userToUpdate);
            await _dbcontext.SaveChangesAsync();
            return userToUpdate;
        }
    }
}
