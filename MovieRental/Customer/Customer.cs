using System;
using System.Collections.Generic;

namespace MovieRental
{
    public class Customer : ICustomer
    {
        public string Name { get; private set; }
        public int Reward { get; private set; }
        private List<IRental> Rentals { get; set; }

        public Customer(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
            Rentals = new List<IRental>();
        }

        public void AddRental(IRental rental)
        {
            if (!(rental is IRental))
                throw new ArgumentNullException(nameof(rental));

            Rentals.Add(rental);
        }

        public List<IRental> GetRentals()
        {
            return Rentals;
        }

        public double GetOwedAmount()
        {
            double totalAmount = 0;
            foreach (var rental in GetRentals())
                totalAmount += CalculateRent(rental);

            return totalAmount;
        }

        public double GetReward()
        {
            double reward = 0;
            foreach (var rental in GetRentals())
                reward += CalculateReward(rental);

            return reward;
        }

        private double CalculateRent(IRental rental)
        {
            IRentalStrategy rentalStrategy = rental.GetRentalStrategy();
            return rentalStrategy.GetRent(rental.GetDaysRented());
        }

        private double CalculateReward(IRental rental)
        {
            IRewardStrategy rewardStrategy = rental.GetRentalStrategy().RewardStrategy;
            return rewardStrategy.GetReward(rental.GetDaysRented());
        }
    }
}
