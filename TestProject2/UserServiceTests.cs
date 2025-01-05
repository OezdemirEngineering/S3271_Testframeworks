using Microsoft.EntityFrameworkCore;
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

public class UserServiceTests : IDisposable
{
    //setup
    public UserServiceTests()
    {
        var options = new DbContextOptionsBuilder<TestDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options;

        var userService = new UserService(new TestDbContext(options));


    }

    public void Dispose()
    {
        // Clean up

    }




}
