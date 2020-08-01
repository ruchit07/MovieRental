namespace MovieRental
{
    public abstract class RewardStrategy : IRewardStrategy
    {
        public abstract int Reward { get; }

        public abstract int GetReward(int daysRented);
    }
}
