using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovieRental.Test
{
    [TestClass]
    public class ChildrenRentalStrategyTest
    {
        [TestMethod]
        [DataRow(1.5, 3, 3, 0, 0)]
        [DataRow(1.5, 3, 3, 1, 1.5)]
        [DataRow(1.5, 3, 3, 2, 1.5)]
        [DataRow(1.5, 3, 3, 3, 1.5)]
        [DataRow(1.5, 3, 3, 4, 4.5)]
        [DataRow(1.5, 3, 3, 5, 7.5)]
        public void ChildrenRentalStrategy_GetRent_ShouldReturnValidRent(double fixRent, int fixRentDays, double rentAfterFixRentDays, int daysRented, double rent)
        {
            // Arrange
            double expectedRent = rent;

            // Act
            IRentalStrategy rentalStrategy = new ChildrenRentalStrategy(fixRent, fixRentDays, rentAfterFixRentDays);
            double actualRent = rentalStrategy.GetRent(daysRented);

            // Assert
            Assert.AreEqual(expectedRent, actualRent);
        }
    }
}
