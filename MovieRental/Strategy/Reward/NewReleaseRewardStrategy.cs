namespace MovieRental
{
    public class NewReleaseRewardStrategy : RewardStrategy, IRewardStrategy
    {
        public override int Reward => 1;

        public override int GetReward(int daysRented)
        {
            if (daysRented > 1)
                return Reward + 1;

            return Reward;
        }
    }
}
