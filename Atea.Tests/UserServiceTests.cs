using Atea.Services;

namespace Atea.Tests;

public class UserServiceTests
{
    [Fact]
    public void Authenticate_ValidCredentials_ReturnsUser()
    {
        var userService = new UserService();
        var user = userService.Authenticate("atea", "password");

        Assert.NotNull(user);
        Assert.Equal("atea", user.Username);
    }

    [Fact]
    public void Authenticate_InvalidCredentials_ReturnsNull()
    {
        var userService = new UserService();
        var user = userService.Authenticate("atea", "qwerty");

        Assert.Null(user);
    }
}
