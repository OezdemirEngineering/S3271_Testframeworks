using FluentAssertions;
using System;
using System.Collections.Generic;

using TestFrameworks.Geometries;
using Path = TestFrameworks.Geometries.Path;

namespace TestProject2;

public class PathTests : IDisposable
{
    private readonly Path _path;
    public PathTests()
    {
        _path = new Path();
    }

    public void Dispose()
    {

    }

    [Fact]
    public void Test()
    {
        // Arrange
        var rect = new Rectangle(2, 3);
        var expectedRectLength = 10;
        var circle = new Circle(2);
        var expectedCircleLength = 2*2*Math.PI;
        _path.AddGeometry([rect, circle]);

        // Act
        var actualLength = _path.GetLength();

        // Assert
        actualLength.Should().BeApproximately(expectedRectLength + expectedCircleLength, 0.01);
    }




}
