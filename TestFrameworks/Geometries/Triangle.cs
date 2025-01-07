// Copyright (c) OEENG 2025 - All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFrameworks.Geometries;
internal class Triangle(double a, double b, double c) : IGeometry
{
    public double A => a;
    public double B => b;
    public double C => c;
    public double GetLength()
        => a + b + c;
}
