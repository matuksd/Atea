using Atea.Models;

namespace Atea.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        bool IsValidUser(int userId);
    }
}
