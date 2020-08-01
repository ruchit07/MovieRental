namespace MovieRental
{
    public class NewReleaseRentalStrategy : RentalStrategy, IRentalStrategy
    {
        private double FixRent { get; set; } = 3;
        private int FixRentDays { get; set; } = 1;
        private double RentAfterFixRentDays { get; set; } = 3;
        public override IRewardStrategy RewardStrategy => new NewReleaseRewardStrategy();

        public NewReleaseRentalStrategy()
           : this(3, 1, 3)
        {

        }

        public NewReleaseRentalStrategy(double fixRent, int fixRentDays, double rentAfterFixRentDays)
            : base(fixRent, fixRentDays, rentAfterFixRentDays)
        {
            FixRent = fixRent;
            FixRentDays = fixRentDays;
            RentAfterFixRentDays = rentAfterFixRentDays;
        }
    }
}
