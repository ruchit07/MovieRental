using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovieRental.Test
{
    [TestClass]
    public class NewReleaseRentalStrategyTest
    {
        [TestMethod]
        [DataRow(3, 1, 3, 0, 0)]
        [DataRow(3, 1, 3, 1, 3)]
        [DataRow(3, 1, 3, 2, 6)]
        [DataRow(3, 1, 3, 3, 9)]
        public void NewReleaseRentalStrategyTest_GetRent_ShouldReturnValidRent(double fixRent, int fixRentDays, double rentAfterFixRentDays, int daysRented, double rent)
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
