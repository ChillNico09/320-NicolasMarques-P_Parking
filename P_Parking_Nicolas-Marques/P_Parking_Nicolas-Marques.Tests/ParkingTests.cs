using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using P_Parking_Nicolas_Marques;

namespace P_Parking_Nicolas_Marques.Tests
{
    [TestClass]
    public class ParkingTests
    {
        [TestMethod]
        public void CheckParkingSpot_IsFree_Result_X()
        {
            // Arrange
            int spotNumber = 1;
            char actual = ' ';
            char excepted = 'L';

            // Act
            actual = Parking.CheckParkingSpot(spotNumber);

            // Assert
            Assert.AreEqual(excepted, actual, "La place du parking n'est pas libre!");
        }
    }
}
