namespace MovieRental
{
    public interface IMovie
    {
        public string Name { get; }
        public MovieType MovieType { get; }
    }
}
