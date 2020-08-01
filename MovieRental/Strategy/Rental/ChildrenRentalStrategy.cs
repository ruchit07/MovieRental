namespace MovieRental
{
    public class ChildrenRentalStrategy : RentalStrategy, IRentalStrategy
    {
        private double FixRent { get; set; } = 1.5;
        private int FixRentDays { get; set; } = 3;
        private double RentAfterFixRentDays { get; set; } = 3;
        public override IRewardStrategy RewardStrategy => new DefaultRewardStrategy();

        public ChildrenRentalStrategy()
          : this(1.5, 3, 3)
        {

        }

        public ChildrenRentalStrategy(double fixRent, int fixRentDays, double rentAfterFixRentDays)
            : base(fixRent, fixRentDays, rentAfterFixRentDays)
        {
            FixRent = fixRent;
            FixRentDays = fixRentDays;
            RentAfterFixRentDays = rentAfterFixRentDays;
        }
    }
}
