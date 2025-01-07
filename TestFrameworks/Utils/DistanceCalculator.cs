// Copyright (c) OEENG 2025 - All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFrameworks.Utils;
public static class DistanceCalculator
{
    private static readonly double _velocity= 9.81;
    public static double GetDistance(double v) 
    { 
        return v* v/ (2 * _velocity); 
    }

    public static bool IsColliding(double speed,double distanceObject)
        => GetDistance(speed) > distanceObject;
}
