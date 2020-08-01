using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MovieRental.Test
{
    [TestClass]
    public class AppTest
    {
        [TestMethod]
        [DataRow("Ruchit Suthar", 1, 6.5, 3)]
        [DataRow("Ruchit Suthar", 2, 9.5, 4)]
        [DataRow("Ruchit Suthar", 3, 14, 4)]
        public void App_GetStatement_ShouldBeValid(string customerName, int daysRented, double amount, int reward)
        {
            // Arrange
            var rentals = new List<IRental>() {
                new Rental(new Movie("Regular movie", MovieType.Regular), new RegularRentalStrategy(), daysRented),
                new Rental(new Movie("Children movie", MovieType.Children), new ChildrenRentalStrategy(), daysRented),
                new Rental(new Movie("New Release movie", MovieType.NewRelease), new NewReleaseRentalStrategy(), daysRented)
            };
            var expectedStatement = string.Format(App.Statement, customerName, amount, reward);

            // Act
            App.Rentals = rentals;
            var actualStatement = App.Run(customerName);

            // Assert
            Assert.AreEqual(expectedStatement, actualStatement);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [ExpectedException(typeof(ArgumentNullException), "name")]
        public void App_GetStatementForNullCustomer_ShouldThrowException(string customerName)
        {
            // Arrange

            // Act
            App.Run(customerName);

            // Assert
            throw new Exception();
        }

        [TestMethod]
        [DataRow("Ruchit Suthar")]
        [ExpectedException(typeof(ArgumentNullException), "rental")]
        public void App_GetStatementForNullRental_ShouldThrowException(string customerName)
        {
            // Arrange

            // Act
            App.Rentals = null;
            App.Run(customerName);

            // Assert
            throw new Exception();
        }
    }
}
