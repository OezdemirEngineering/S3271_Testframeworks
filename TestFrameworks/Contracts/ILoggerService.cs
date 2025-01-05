// Copyright (c) OEENG 2025 - All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFrameworks.Contracts;
public interface ILoggerService
{
    void LogError(string message);
    void LogInfo(string message);
    void LogWarning(string message);
}
