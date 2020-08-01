using System;
using System.Collections.Generic;

namespace MovieRental
{
    class Program
    {
        static void Main(string[] args)
        {
            App.Rentals = new List<IRental>() {
                new Rental(new Movie("Regular movie", MovieType.Regular), new RegularRentalStrategy(), 1),
                new Rental(new Movie("Children movie", MovieType.Children), new ChildrenRentalStrategy(), 1),
                new Rental(new Movie("New Release movie", MovieType.NewRelease), new NewReleaseRentalStrategy(), 1)
            };

            App.Run("Ruchit Suthar");
        }
    }
}
