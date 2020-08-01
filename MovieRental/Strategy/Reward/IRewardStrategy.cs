namespace MovieRental
{
    public interface IRewardStrategy
    {
        int GetReward(int daysRented);
    }
}
