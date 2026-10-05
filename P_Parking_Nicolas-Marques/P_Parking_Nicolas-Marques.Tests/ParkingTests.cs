using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using P_Parking_Nicolas_Marques;
using System.Collections.Generic;

namespace P_Parking_Nicolas_Marques.Tests
{
    [TestClass]
    public class ParkingTests
    {
        [TestMethod]
        public void CheckParkingSpot_IsFree_Result_L()
        {
            // Arrange
            int spotNumber = 0;
            char actual = ' ';
            char excepted = 'L';

            // Act
            actual = Parking.CheckParkingSpot(spotNumber);

            // Assert
            Assert.AreEqual(excepted, actual, "La place du parking n'est pas libre!");
        }

        [TestMethod]
        public void GetTotalPaidPrice_Is0_Result_0()
        {
            // Arrange
            List<Voiture> carList = Parking.carList;
            int actual = 1;
            int excepted = 0;

            // Act
            actual = Parking.GetTotalPaidPrice(carList);

            // Assert
            Assert.AreEqual(excepted, actual, "Des voitures ont quitté le parking!");
        }
    }
}
