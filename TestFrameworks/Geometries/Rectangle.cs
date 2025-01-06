// Copyright (c) OEENG 2025 - All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFrameworks.Geometries;
public  class Rectangle(double width, double heigth) : IGeometry
{
    public double Width => width;
    public double Heigth => heigth;

    public double GetLength()
        => 2 * (width);
}
