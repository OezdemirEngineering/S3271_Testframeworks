using Xunit;
using TestFrameworks.Utils;
using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestProject2;

public class CaclulatorTests : IDisposable
{

    public CaclulatorTests()
    {

    }


    [Fact]
    public void Add_TwoIntegers_CorrectSum()
    {
        //Arrange
        int a = 1;
        int b = 2;
        int expected = 3;

        //Act
        int actual = Calculator.Add(a, b);


        //Assert
        Assert.Equal(expected, actual);


    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(2, 2, 4)]
    [InlineData(3, 2, 5)]
    public void Add_TwoIntegers_ReturnCorrectSum(int a, int b, int expected)
    {

        //Act
        int actual = Calculator.Add(a, b);
        //Assert
        Assert.Equal(expected, actual);
    }

    public void Dispose()
    {
        // Cleanup
    }
}
