using Xunit;
using Moq;
using System.Threading.Tasks;
using SendEmail.Api.Data.Repository;
using SendEmail.Api.Data.Context;
using SendEmail.Api.Data.Model;
using Microsoft.EntityFrameworkCore;
using SendEmail.Api.Data.Repository.Interfaces;

public class UserRepositoryTests
{
    private readonly Mock<AppDbContext> _dbContextMock;
    private readonly UserRepository _userRepository;

    public UserRepositoryTests()
    {
        _dbContextMock = new Mock<AppDbContext>();
        _userRepository = new UserRepository(_dbContextMock.Object);
    }

    [Fact]
    public async Task CriaUsuario_CreatesUser()
    {
        // Arrange
        var user = new UserModel { Id = 1, Username = "Test User" };

        // Act
        var result = await _userRepository.CriaUsuario(user);

        // Assert
        _dbContextMock.Verify(c => c.Add(It.IsAny<UserModel>()), Times.Once);
        _dbContextMock.Verify(c => c.SaveChanges(), Times.Once);
        Assert.Equal(user, result);
    }

    [Fact]
    public async Task DeletaUsuario_DeletesUser_WhenUserExists()
    {
        // Arrange
        var userId = 1;
        var user = new UserModel { Id = userId };
        _dbContextMock.Setup(c => c.Users.FindAsync(userId)).ReturnsAsync(user);

        // Act
        var result = await _userRepository.DeletaUsuario(userId);

        // Assert
        Assert.Equal(userId, result.Id);
        _dbContextMock.Verify(c => c.Remove(It.IsAny<UserModel>()), Times.Once);
        _dbContextMock.Verify(c => c.SaveChanges(), Times.Once);
    }
}
