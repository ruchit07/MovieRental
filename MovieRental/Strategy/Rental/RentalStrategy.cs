namespace MovieRental
{
    public abstract class RentalStrategy : IRentalStrategy
    {
        private double FixRent { get; set; }
        private int FixRentDays { get; set; }
        private double RentAfterFixRentDays { get; set; }
        public abstract IRewardStrategy RewardStrategy { get; }

        public RentalStrategy(double fixRent, int fixRentDays, double rentAfterFixRentDays)
        {
            FixRent = fixRent;
            FixRentDays = fixRentDays;
            RentAfterFixRentDays = rentAfterFixRentDays;
        }

        public virtual double GetRent(int day)
        {
            if (day <= 0)
                return 0;

            double amount = FixRent;

            if (day > FixRentDays)
                amount += CalculateAmount(day);

            return amount;
        }

        private double CalculateAmount(int day)
        {
            return (day - FixRentDays) * RentAfterFixRentDays;
        }
    }
}
