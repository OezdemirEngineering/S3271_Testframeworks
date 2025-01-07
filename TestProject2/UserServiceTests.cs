using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFrameworks.Contracts;
using TestFrameworks.DatabaseService;
using TestFrameworks.RegistrationService;

namespace TestProject2;



public class UserServiceTests :  IDisposable
{
    private TestDbContext _dbContext;
    private UserService _userService;
    private ServiceProvider _serviceProvider;


    //setup
    public UserServiceTests()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddTransient<UserService>();
        serviceCollection.AddDbContext<TestDbContext>(options => options.UseInMemoryDatabase("TestDatabase"));
        //var emailService = Substitute.For<IEmailService>();
        //serviceCollection.AddSingleton<IEmailService>(emailService);
        _serviceProvider = serviceCollection.BuildServiceProvider();

        _userService = _serviceProvider.GetRequiredService<UserService>();
        _dbContext = _serviceProvider.GetRequiredService<TestDbContext>();
        

        //var service = _serviceProvider.GetRequiredService<IEmailService>();


    }

    [Fact]
    public void AddUser_SingleUser_ShouldAddUserToDatabase()
    {
        // Arrange
        var user = new UserDto { Id = 1, Name = "John" };



        // Act
        _userService.AddUser(user);


        // Assert
        var addedUser = _dbContext.Users.Single();
        addedUser.Should().Be(user);

    }


    public void Dispose()
    {
        // Clean up
        _dbContext.Dispose();
    }




}
