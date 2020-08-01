using System.Collections.Generic;

namespace MovieRental
{
    public interface ICustomer
    {
        string Name { get; }
        int Reward { get; }
        void AddRental(IRental rental);
        List<IRental> GetRentals();
        double GetOwedAmount();
        double GetReward();
    }
}
