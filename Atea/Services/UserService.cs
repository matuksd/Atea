using Atea.Models;

namespace Atea.Services
{
    public class UserService : IUserService
    {
        private List<User> _users = new()
        {
            new User { Id = 1, Username = "atea", Password = "password" }
        };

        public User Authenticate(string username, string password)
        {
            return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
        public bool IsValidUser(int userId)
        {
            return _users.Any(u => u.Id == userId);
        }
    }
}
