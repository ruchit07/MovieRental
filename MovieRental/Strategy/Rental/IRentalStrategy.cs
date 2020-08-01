namespace MovieRental
{
    public interface IRentalStrategy
    {
        IRewardStrategy RewardStrategy { get; }
        double GetRent(int daysRented);
    }
}
