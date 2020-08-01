using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovieRental.Test
{
    [TestClass]
    public class RegularRentalStrategyTest
    {
        [TestMethod]
        [DataRow(2, 2, 1.5, 0, 0)]
        [DataRow(2, 2, 1.5, 1, 2)]
        [DataRow(2, 2, 1.5, 2, 2)]
        [DataRow(2, 2, 1.5, 3, 3.5)]
        public void RegularRentalStrategy_GetRent_ShouldReturnValidRent(double fixRent, int fixRentDays, double rentAfterFixRentDays, int daysRented, double rent)
        {
            // Arrange
            double expectedRent = rent;

            // Act
            IRentalStrategy rentalStrategy = new RegularRentalStrategy(fixRent, fixRentDays, rentAfterFixRentDays);
            double actualRent = rentalStrategy.GetRent(daysRented);

            // Assert
            Assert.AreEqual(expectedRent, actualRent);
        }
    }
}
