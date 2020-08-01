using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MovieRental.Test
{
    [TestClass]
    public class MovieTest
    {
        [TestMethod]
        [DataRow("Harry Potter", MovieType.Children)]
        [DataRow("Fast and furious", MovieType.Regular)]
        [DataRow("Avengers: Endgame", MovieType.NewRelease)]
        public void Movie_Create_ShouldCreateNew(string name, MovieType movieType)
        {
            // Arrange
            string expectedMovieName = name;
            MovieType expectedMovieType = movieType;

            // Act
            IMovie movie = new Movie(name, movieType);

            // Assert
            Assert.AreEqual(expectedMovieName, movie.Name);
            Assert.AreEqual(expectedMovieType, movie.MovieType);
        }

        [TestMethod]
        [DataRow(null, MovieType.Children)]
        [DataRow("", MovieType.Regular)]
        [ExpectedException(typeof(ArgumentNullException), "name")]
        public void Movie_CreateNull_ShouldThrowException(string name, MovieType movieType)
        {
            // Arrange
            string expectedMovieName = name;
            MovieType expectedMovieType = movieType;

            // Act
            IMovie movie = new Movie(name, movieType);

            // Assert
            Assert.AreEqual(expectedMovieName, movie.Name);
            Assert.AreEqual(expectedMovieType, movie.MovieType);
        }
    }
}
