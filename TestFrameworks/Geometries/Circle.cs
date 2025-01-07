// Copyright (c) OEENG 2025 - All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFrameworks.Geometries;
public class Circle(double radius) : IGeometry
{
    public double Radius => radius;
    public double GetLength()
        => 2 * Math.PI* radius;
}
