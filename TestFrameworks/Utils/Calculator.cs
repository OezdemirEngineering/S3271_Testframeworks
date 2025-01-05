// Copyright (c) OEENG 2025 - All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFrameworks.Utils;
public static class Calculator
{
    public static int Add(int a, int b) 
        => a + b;

    public static int Subtract(int a, int b) 
        => a - b;

    public static int Multiply(int a, int b) 
        => a * b;

    public static double Divide(double a, double b)
    {
        if (b == 0) throw new DivideByZeroException("Division durch 0 ist nicht erlaubt.");
        return a / b;
    }

    public static int Square(int a) => a * a;

    public static int[] SetArrayAbsoluteValues(int[] values) 
        =>  [.. values.Select(Math.Abs)];
}

