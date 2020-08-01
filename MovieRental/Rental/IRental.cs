namespace MovieRental
{
    public interface IRental
    {
        IMovie GetMovie();
        IRentalStrategy GetRentalStrategy();
        int GetDaysRented();
    }
}
