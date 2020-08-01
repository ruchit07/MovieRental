using System;

namespace MovieRental
{
    public class Movie : IMovie
    {
        public string Name { get; private set; }
        public MovieType MovieType { get; private set; }

        public Movie(string name, MovieType movieType)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
            MovieType = movieType;
        }
    }
}
