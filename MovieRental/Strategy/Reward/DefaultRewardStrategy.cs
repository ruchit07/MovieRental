namespace MovieRental
{
    public class DefaultRewardStrategy : RewardStrategy, IRewardStrategy
    {
        public override int Reward => 1;

        public override int GetReward(int daysRented)
        {
            return Reward;
        }
    }
}
