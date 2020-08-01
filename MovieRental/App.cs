using System;
using System.Collections.Generic;

namespace MovieRental
{
    public class App
    {
        public static List<IRental> Rentals { get; set; }
        public static string Statement => "{0} owed {1} Rs. Earned {2} Reward points.";

        public static string Run(string customerName)
        {
            ICustomer customer = new Customer(customerName);

            if (!(Rentals is List<IRental>))
                throw new ArgumentNullException(nameof(Rentals));

            foreach (IRental rental in Rentals)
                customer.AddRental(rental);

            var rent = customer.GetOwedAmount();
            var reward = customer.GetReward();
            var statement = string.Format(Statement, customer.Name, rent, reward);

            Console.WriteLine(statement);
            return statement;
        }
    }
}
