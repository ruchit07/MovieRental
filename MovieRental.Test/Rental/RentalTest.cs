using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovieRental.Test
{
    [TestClass]
    public class RentalTest
    {
        [TestMethod]
        public void Rental_Create_ShouldCreateNew()
        {
            // Arrange
            IMovie expectedMovie = new Movie("Regular movie", MovieType.Regular);
            IRentalStrategy expectedRentalStrategy = new RegularRentalStrategy();
            int expectedDaysRented = 2;
            IRental expectedRental = new Rental(expectedMovie, expectedRentalStrategy, expectedDaysRented);

            // Act
            IRental actualRental = new Rental(new Movie("Regular movie", MovieType.Regular), new RegularRentalStrategy(), 2);

            // Assert
            Assert.AreEqual(expectedRental.GetMovie().Name, actualRental.GetMovie().Name);
            Assert.AreEqual(expectedRental.GetMovie().MovieType, actualRental.GetMovie().MovieType);
            Assert.AreEqual(expectedRentalStrategy.GetType(), actualRental.GetRentalStrategy().GetType());
            Assert.AreEqual(expectedDaysRented, actualRental.GetDaysRented());
        }

        [TestMethod]
        public void Rental_GetMovie_ShouldReturnMovie()
        {
            // Arrange
            IMovie expectedMovie = new Movie("Regular movie", MovieType.Regular);
            IRentalStrategy expectedRentalStrategy = new RegularRentalStrategy();
            int expectedDaysRented = 2;
            IRental expectedRental = new Rental(expectedMovie, expectedRentalStrategy, expectedDaysRented);

            // Act
            IRental actualRental = new Rental(new Movie("Regular movie", MovieType.Regular), new RegularRentalStrategy(), 2);

            // Assert
            Assert.AreEqual(expectedRental.GetMovie().Name, actualRental.GetMovie().Name);
            Assert.AreEqual(expectedRental.GetMovie().MovieType, actualRental.GetMovie().MovieType);
        }

        [TestMethod]
        public void Rental_GetRentalStrategy_ShouldReturnRentalStrategy()
        {
            // Arrange
            IRentalStrategy expectedRentalStrategy = new RegularRentalStrategy();

            // Act
            IRental actualRental = new Rental(new Movie("Regular movie", MovieType.Regular), new RegularRentalStrategy(), 2);

            // Assert
            Assert.AreEqual(expectedRentalStrategy.GetType(), actualRental.GetRentalStrategy().GetType());
        }

        [TestMethod]
        [DataRow(2)]
        [DataRow(3)]
        public void Rental_GetDaysRented_ShouldReturnDaysRented(int daysRented)
        {
            // Arrange
            int expectedDaysRented = daysRented;

            // Act
            IRental actualRental = new Rental(new Movie("Regular movie", MovieType.Regular), new RegularRentalStrategy(), expectedDaysRented);

            // Assert
            Assert.AreEqual(expectedDaysRented, actualRental.GetDaysRented());
        }
    }
}
