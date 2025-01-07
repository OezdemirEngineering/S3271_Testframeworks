using TestFrameworks.Utils;

namespace TestProject1;

public class Tests
{
    /// <summary>
    /// Tests the GetDistance method of the DistanceCalculator class.
    /// Verifies that the method returns the expected distance for a given speed.
    /// </summary>
    [Test, Category("UnitTest")]
    public void GetDistance_Speed_ExpectedDistance()
    {
        // Arrange
        double speed = 10;
        double expectedDistance = 5.09;

        // Act
        double actualDistance = DistanceCalculator.GetDistance(speed);

        // Assert
        Assert.That(actualDistance, Is.EqualTo(expectedDistance).Within(0.01));
    }

    /// <summary>
    /// This test is ignored because it is not implemented yet.
    /// </summary>
    [Test, Category("UnitTest")]
    public void IsColliding_SpeedDistanceObject_CollisionStatus()
    {
        // Arrange
        double speed = 10;
        double distanceObject = 5.09;
        bool expectedCollisionStatus = true;

        // Act
        bool actualCollisionStatus = DistanceCalculator.IsColliding(speed, distanceObject);

        // Assert
        Assert.Equals(expectedCollisionStatus, actualCollisionStatus);
    }
}
