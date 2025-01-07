// Copyright (c) OEENG 2025 - All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFrameworks.Contracts;

namespace TestFrameworks.RegistrationService;
public class RegistrationService
{
    private readonly IEmailService _emailService;
    private readonly ILoggerService _loggerService;

    private string _address = "info@oeeng.de";

    public RegistrationService(IEmailService emailService, ILoggerService loggerService)
    {
        _emailService = emailService;
        _loggerService = loggerService;
    }

    public void RegisterUser(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("E-Mail-Adresse darf nicht leer sein.");
            _loggerService.LogError("E-Mail-Adresse darf nicht leer sein.");
        }

        _emailService.SendEmail(email, "Willkommen!", "Bitte bestätigen Sie Ihre E-Mail-Adresse.");
        _loggerService.LogInfo($"E-Mail an {email} gesendet.");
    }
}

