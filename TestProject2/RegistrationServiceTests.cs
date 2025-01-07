using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFrameworks.Contracts;
using TestFrameworks.RegistrationService;

namespace TestProject2;

public  class RegistrationServiceTests
{
    private readonly IEmailService _mailsService;
    private readonly ILoggerService _loggerService;

    public RegistrationServiceTests()
    {
        _mailsService = Substitute.For<IEmailService>();
        _loggerService = Substitute.For<ILoggerService>();
    }

    [Fact]
    public void RegisterUser_WhenUserDtoIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        var registrationService = new RegistrationService(_mailsService,_loggerService);

        // Act
        registrationService.RegisterUser("info@oeeng.de");

        var privateMailServoce = registrationService.GetPrivateField<IEmailService>("_emailService");

        var adress = registrationService.GetPrivateField<string>("_address");

        registrationService.SetPrivateField("_address","blabla");

        adress = registrationService.GetPrivateField<string>("_address");

        // Assert
        _mailsService.Received().SendEmail(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
        _loggerService.Received().LogInfo(Arg.Any<string>());
    }

}
