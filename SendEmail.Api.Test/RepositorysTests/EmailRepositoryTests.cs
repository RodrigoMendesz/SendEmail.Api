using Xunit;
using Moq;
using System.Threading.Tasks;
using SendEmail.Api.Data.Repository;
using SendEmail.Api.Data.Context;
using SendEmail.Api.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class EmailRepositoryTests
{
    private readonly Mock<AppDbContext> _dbContextMock;
    private readonly EmailRepository _emailRepository;

    public EmailRepositoryTests()
    {
        _dbContextMock = new Mock<AppDbContext>();
        _emailRepository = new EmailRepository(_dbContextMock.Object);
    }

    [Fact]
    public async Task GetEmailByIdAsync_ReturnsEmail_WhenEmailExists()
    {
        // Arrange
        var emailId = 1;
        var email = new EmailModel { Id = emailId, Recipient = "test@example.com" };
        var dbSetMock = new Mock<DbSet<EmailModel>>();
        dbSetMock.As<IQueryable<EmailModel>>().Setup(m => m.GetEnumerator()).Returns(new List<EmailModel> { email }.GetEnumerator());
        _dbContextMock.Setup(c => c.Emails).Returns(dbSetMock.Object);

        // Act
        var result = await _emailRepository.GetEmailByIdAsync(emailId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(emailId, result.Id);
    }

    [Fact]
    public async Task DeleteEmailAsync_DeletesEmail_WhenEmailExists()
    {
        // Arrange
        var emailId = 1;
        var email = new EmailModel { Id = emailId };
        var dbSetMock = new Mock<DbSet<EmailModel>>();
        dbSetMock.As<IQueryable<EmailModel>>().Setup(m => m.GetEnumerator()).Returns(new List<EmailModel> { email }.GetEnumerator());
        _dbContextMock.Setup(c => c.Emails).Returns(dbSetMock.Object);

        // Act
        await _emailRepository.DeleteEmailAsync(emailId);

        // Assert
        dbSetMock.Verify(m => m.Remove(It.IsAny<EmailModel>()), Times.Once);
        _dbContextMock.Verify(c => c.SaveChanges(), Times.Once);
    }
}
