using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieRental.Test
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        [DataRow("Ruchit Suthar")]
        [DataRow("John Doe")]
        public void Customer_Create_ShouldCreateNewCustomer(string customerName)
        {
            // Arrange
            string expectedName = customerName;

            // Act
            ICustomer customer = new Customer(customerName);

            // Assert
            Assert.AreEqual(expectedName, customer.Name);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentNullException), "name")]
        public void Customer_CreateWithNull_ShouldThrowException(string customerName)
        {
            // Arrange
            string expectedName = customerName;

            // Act
            ICustomer customer = new Customer(customerName);

            // Assert
            Assert.AreEqual(expectedName, customer.Name);
        }

        [TestMethod]
        [DataRow("Ruchit Suthar")]
        public void Customer_AddRental_ShouldAddRent(string customerName)
        {
            // Arrange
            IRental expectedRental = new Rental(new Movie("Regular movie", MovieType.Regular), new RegularRentalStrategy(), 2);

            // Act
            ICustomer customer = new Customer(customerName);
            customer.AddRental(expectedRental);

            // Assert
            Assert.IsTrue(customer.GetRentals().Any(actualRental => actualRental.Equals(expectedRental)));
        }

        [TestMethod]
        [DataRow("Ruchit Suthar")]
        [ExpectedException(typeof(ArgumentNullException), "rental")]
        public void Customer_AddRentalNull_ShouldThrowException(string customerName)
        {
            // Arrange
            IRental expectedRental = null;

            // Act
            ICustomer customer = new Customer(customerName);
            customer.AddRental(expectedRental);

            // Assert
            Assert.IsTrue(customer.GetRentals().Any(actualRental => actualRental.Equals(expectedRental)));
        }

        [TestMethod]
        [DataRow("Ruchit Suthar")]
        public void Customer_GetRentals_ShouldReturnRentals(string customerName)
        {
            // Arrange
            List<IRental> expectedRental = new List<IRental>() {
                new Rental(new Movie("Regular movie", MovieType.Regular), new RegularRentalStrategy(), 1),
                new Rental(new Movie("Children movie", MovieType.Children), new ChildrenRentalStrategy(), 1),
                new Rental(new Movie("New Release movie", MovieType.NewRelease), new NewReleaseRentalStrategy(), 1)
            };

            // Act
            ICustomer customer = new Customer(customerName);
            foreach (var rental in expectedRental)
                customer.AddRental(rental);

            List<IRental> actualRentals = customer.GetRentals();

            // Assert
            Assert.IsTrue(expectedRental.Count.Equals(actualRentals.Count));
            CollectionAssert.AreEqual(expectedRental, actualRentals);
        }

        [TestMethod]
        [DataRow("Ruchit Suthar")]
        public void Customer_GetRentals_ShouldReturnEmptyRentals(string customerName)
        {
            // Arrange
            List<IRental> expectedRental = new List<IRental>();

            // Act
            ICustomer customer = new Customer(customerName);
            foreach (var rental in expectedRental)
                customer.AddRental(rental);

            List<IRental> actualRentals = customer.GetRentals();

            // Assert
            Assert.IsTrue(expectedRental.Count.Equals(actualRentals.Count));
            CollectionAssert.AreEqual(expectedRental, actualRentals);
        }

        [TestMethod]
        [DataRow("Ruchit Suthar", 1, 6.5)]
        [DataRow("Ruchit Suthar", 2, 9.5)]
        [DataRow("Ruchit Suthar", 3, 14)]
        public void Customer_GetOwedAmount_ShouldReturnValidAmount(string customerName, int daysRented, double amount)
        {
            // Arrange
            List<IRental> expectedRental = new List<IRental>() {
                new Rental(new Movie("Regular movie", MovieType.Regular), new RegularRentalStrategy(), daysRented),
                new Rental(new Movie("Children movie", MovieType.Children), new ChildrenRentalStrategy(), daysRented),
                new Rental(new Movie("New Release movie", MovieType.NewRelease), new NewReleaseRentalStrategy(), daysRented)
            };
            var expectedAmount = amount;

            // Act
            ICustomer customer = new Customer(customerName);
            foreach (var rental in expectedRental)
                customer.AddRental(rental);

            double actualAmount = customer.GetOwedAmount();

            // Assert
            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [TestMethod]
        [DataRow("Ruchit Suthar", 1, 3)]
        [DataRow("Ruchit Suthar", 2, 4)]
        [DataRow("Ruchit Suthar", 3, 4)]
        public void Customer_GetReward_ShouldReturnValidReward(string customerName, int daysRented, int reward)
        {
            // Arrange
            List<IRental> expectedRental = new List<IRental>() {
                new Rental(new Movie("Regular movie", MovieType.Regular), new RegularRentalStrategy(), daysRented),
                new Rental(new Movie("Children movie", MovieType.Children), new ChildrenRentalStrategy(), daysRented),
                new Rental(new Movie("New Release movie", MovieType.NewRelease), new NewReleaseRentalStrategy(), daysRented)
            };
            var expectedReward = reward;

            // Act
            ICustomer customer = new Customer(customerName);
            foreach (var rental in expectedRental)
                customer.AddRental(rental);

            double actualReward = customer.GetReward();

            // Assert
            Assert.AreEqual(expectedReward, actualReward);
        }
    }
}
