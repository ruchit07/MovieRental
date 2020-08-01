namespace MovieRental
{
    public class RegularRentalStrategy : RentalStrategy, IRentalStrategy
    {
        public double FixRent { get; set; } = 2;
        public int FixRentDays { get; set; } = 2;
        public double RentAfterFixRentDays { get; set; } = 1.5;
        public override IRewardStrategy RewardStrategy => new DefaultRewardStrategy();

        public RegularRentalStrategy()
            : this(2, 2, 1.5)
        {

        }

        public RegularRentalStrategy(double fixRent, int fixRentDays, double rentAfterFixRentDays)
            : base(fixRent, fixRentDays, rentAfterFixRentDays)
        {
            FixRent = fixRent;
            FixRentDays = fixRentDays;
            RentAfterFixRentDays = rentAfterFixRentDays;
        }
    }
}
