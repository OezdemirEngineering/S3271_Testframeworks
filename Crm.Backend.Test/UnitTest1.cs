using CRM.Backend;
using CRM.Common.DBContexts;
using CRM.Common.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;
using Xunit;
using CRM.Common.Contracts;

namespace Crm.Backend.Test;

public class DbServiceTests :IDisposable
{
    private readonly ServiceProvider _serviceProvider;

    public DbServiceTests()
    {
        var services = new ServiceCollection();
        services.AddDbContext<CRMDbContext>(options => options.UseInMemoryDatabase("TestDb"));
        services.AddTransient<IDbService, DbService>();
        _serviceProvider = services.BuildServiceProvider();
    }

    [Fact]
    public void AddUser_ShouldAddUser()
    {
        // Arrange
        var dbService = _serviceProvider.GetService<IDbService>();
        var user = new UserDto { Id = 1, FirstName = "John", FamilyName = "Doe", Email = "john.doe@example.com" };

        // Act
        dbService.AddUser(user);
        var addedUser = dbService.GetUser(1);

        // Assert
        addedUser.Should().NotBeNull();
        addedUser.FirstName.Should().Be("John");
        addedUser.FamilyName.Should().Be("Doe");
        addedUser.Email.Should().Be("john.doe@example.com");
    }

    [Fact]
    public void AddUser_User_UserAddedIsCalled()
    {
        // Arrange
        var dbService = _serviceProvider.GetService<IDbService>();
        var user = new UserDto { FirstName = "John", FamilyName = "Doe", Email = "john.doe@example.com" };
        UserDto addedUser = null;

        dbService.UserAdded += (user) => addedUser = user;

        // Act
        dbService.AddUser(user);


        // Assert
        addedUser.Should().NotBeNull();
        addedUser.FirstName.Should().Be("John");
        addedUser.FamilyName.Should().Be("Doe");
        addedUser.Email.Should().Be("john.doe@example.com");
    }

    [Fact]
    public void DeleteUser_User_RemovedUserIsCalled()
    {
        // Arrange
        var dbService = _serviceProvider.GetService<IDbService>();
        var context = _serviceProvider.GetService<CRMDbContext>();
        var user = new UserDto { Id = 6, FirstName = "John", FamilyName = "Doe", Email = "john.doe@example.com" };
        context.Users.Add(user);
        context.SaveChanges();

        UserDto removedUser = null;
        dbService.UserRemoved += (usr) => removedUser = usr;

        // Act
        dbService.DeleteUser(6);


        // Assert
        removedUser.Should().NotBeNull();
        removedUser.FirstName.Should().Be("John");
        removedUser.FamilyName.Should().Be("Doe");
        removedUser.Email.Should().Be("john.doe@example.com");
    }

    [Fact]
    public void GetUser_ShouldReturnUser()
    {
        // Arrange
        var dbService = _serviceProvider.GetService<IDbService>();
        var context = _serviceProvider.GetService<CRMDbContext>();
        var user = new UserDto { Id = 2, FirstName = "John", FamilyName = "Doe", Email = "john.doe@example.com" };
        context.Users.Add(user);
        context.SaveChanges();

        // Act
        var retrievedUser = dbService.GetUser(2);

        // Assert
        retrievedUser.Should().NotBeNull();
        retrievedUser.FirstName.Should().Be("John");
        retrievedUser.FamilyName.Should().Be("Doe");
        retrievedUser.Email.Should().Be("john.doe@example.com");
    }

    [Fact]
    public void GetUsers_ShouldReturnAllUsers()
    {
        // Arrange
        var dbService = _serviceProvider.GetService<IDbService>();
        var context = _serviceProvider.GetService<CRMDbContext>();
        var user1 = new UserDto { Id = 3, FirstName = "John", FamilyName = "Doe", Email = "john.doe@example.com" };
        var user2 = new UserDto { Id = 4, FirstName = "Jane", FamilyName = "Doe", Email = "jane.doe@example.com" };
        context.Users.AddRange(user1, user2);
        context.SaveChanges();

        // Act
        var users = dbService.GetUsers();

        // Assert
        users.Should().NotBeEmpty();
    }

    [Fact]
    public void UpdateUser_ShouldUpdateUser()
    {
        // Arrange
        var dbService = _serviceProvider.GetService<IDbService>();
        var context = _serviceProvider.GetService<CRMDbContext>();
        var user = new UserDto { Id = 5, FirstName = "John", FamilyName = "Doe", Email = "john.doe@example.com" };
        context.Users.Add(user);
        context.SaveChanges();

        // Act
        user.FirstName = "Johnny";
        dbService.UpdateUser(user);
        var updatedUser = dbService.GetUser(5);

        // Assert
        updatedUser.Should().NotBeNull();
        updatedUser.FirstName.Should().Be("Johnny");
    }

    [Fact]
    public void DeleteUser_ShouldRemoveUser()
    {
        // Arrange
        var dbService = _serviceProvider.GetService<IDbService>();
        var context = _serviceProvider.GetService<CRMDbContext>();
        var user = new UserDto { Id = 6, FirstName = "John", FamilyName = "Doe", Email = "john.doe@example.com" };
        context.Users.Add(user);
        context.SaveChanges();

        // Act
        dbService.DeleteUser(6);
        var deletedUser = dbService.GetUser(6);

        // Assert
        deletedUser.Should().BeNull();
    }

    public void Dispose()
    {
        _serviceProvider.GetService<CRMDbContext>().Dispose();
    }
}
