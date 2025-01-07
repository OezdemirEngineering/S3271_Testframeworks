// Copyright (c) OEENG 2025 - All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFrameworks.Geometries;
internal class Path : IGeometry
{
    private readonly List<IGeometry> _geometries = [];
    public void AddGeometry(List<IGeometry> geometries)
        => _geometries.AddRange(geometries);
    public double GetLength()
    {
        double length = 0;
        foreach (var geometry in _geometries)
        {
            length += geometry.GetLength();
        }
        return length;
    }
}
