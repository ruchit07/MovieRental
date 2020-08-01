using System;

namespace MovieRental
{
    public class Rental : IRental
    {
        private IMovie _movie;
        private IRentalStrategy _rentalStrategy;
        private int _daysRented;

        public Rental(IMovie movie, IRentalStrategy rentalStrategy, int daysRented)
        {
            if (!(movie is IMovie))
                throw new ArgumentNullException(nameof(movie));

            if (!(rentalStrategy is IRentalStrategy))
                throw new ArgumentNullException(nameof(rentalStrategy));

            _movie = movie;
            _rentalStrategy = rentalStrategy;
            _daysRented = daysRented;
        }

        public IMovie GetMovie()
        {
            return _movie;
        }

        public int GetDaysRented()
        {
            return _daysRented;
        }

        public IRentalStrategy GetRentalStrategy()
        {
            return _rentalStrategy;
        }
    }
}
