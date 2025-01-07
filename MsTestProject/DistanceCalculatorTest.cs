using TestFrameworks.Utils;

namespace MsTestProject
{
    /// <summary>
    /// Contains unit tests for the DistanceCalculator class.
    /// </summary>
    [TestClass]
    public sealed class DistanceCalculatorTest
    {
        /// <summary>
        /// Tests the GetDistance method of the DistanceCalculator class.
        /// Verifies that the method returns the expected distance for a given speed.
        /// </summary>
        [TestMethod, TestCategory("UnitTest")]
        public void GetDistance_Speed_ExpectedDistance()
        {
            // Arrange
            double speed = 10;
            double expectedDistance = 5.09;

            // Act
            double actualDistance = DistanceCalculator.GetDistance(speed);

            // Assert
            Assert.AreEqual(expectedDistance, actualDistance, 0.01);
        }

        [Ignore("This test is ignored because it is not implemented yet.")]
        [TestMethod, TestCategory("UnitTest")]
        
        public void IsColliding_SpeedDistanceObject_CollisionStatus()
        {
            // Arrange
            double speed = 10;
            double distanceObject = 5.09;
            bool expectedCollisionStatus = true;

            // Act
            bool actualCollisionStatus = DistanceCalculator.IsColliding(speed, distanceObject);

            // Assert
            Assert.AreEqual(expectedCollisionStatus, actualCollisionStatus);
        }
    }
}
