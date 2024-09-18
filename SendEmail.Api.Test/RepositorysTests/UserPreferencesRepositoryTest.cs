using Xunit;
using Moq;
using System.Threading.Tasks;
using SendEmail.Api.Data.Repository;
using SendEmail.Api.Data.Context;
using SendEmail.Api.Data.Model;
using Microsoft.EntityFrameworkCore;

public class UserPreferencesRepositoryTests
{
    private readonly Mock<AppDbContext> _dbContextMock;
    private readonly UserPreferencesRepository _userPreferencesRepository;

    public UserPreferencesRepositoryTests()
    {
        _dbContextMock = new Mock<AppDbContext>();
        _userPreferencesRepository = new UserPreferencesRepository(_dbContextMock.Object);
    }

    [Fact]
    public async Task GetUserPreferences_ReturnsPreferences_WhenPreferencesExist()
    {
        // Arrange
        var userId = 1;
        var preferences = new UserPreferencesModel { UserId = userId, Theme = "Dark" };
        _dbContextMock.Setup(c => c.UserPreferences.FindAsync(userId)).ReturnsAsync(preferences);

        // Act
        var result = await _userPreferencesRepository.GetUserPreferences(userId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(userId, result.UserId);
        Assert.Equal("Dark", result.Theme);
    }

    [Fact]
    public async Task UpdateUserPreferences_UpdatesExistingPreferences()
    {
        // Arrange
        var userId = 1;
        var preferences = new UserPreferencesModel { UserId = userId, Theme = "Light" };
        _dbContextMock.Setup(c => c.UserPreferences.FindAsync(userId)).ReturnsAsync(preferences);

        // Act
        await _userPreferencesRepository.UpdateUserPreferences(preferences);

        // Assert
        _dbContextMock.Verify(c => c.SaveChangesAsync(default), Times.Once);
    }
}
