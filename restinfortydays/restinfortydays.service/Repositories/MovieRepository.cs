using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using restinfortydays.domain;
using restinfortydays.service.Repositories.Interfaces;

namespace restinfortydays.service.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private static List<Movie> _movies = init();

        private static List<Movie> init()
        {
            var list = new List<Movie>();

            list.Add(
                new Movie()
                {
                    Id = 1,
                    Director = "Martin Scorcese", 
                    Rating = 9, 
                    ReleaseDate = Convert.ToDateTime("6/11/2012"),
                    TagLine = "I'll be back",
                    Title = "Once upon a time",
                    Genres = new List<String>() {"drama","comedy","rock-opera"}
                }
                );

            return list;
        }

        public Movie GetMovie(int Id)
        {
            var list = GetList();
            if (list != null)
            {
                return list.SingleOrDefault(x => x.Id == Id);
            }
            return null;
        }

        public IEnumerable<Movie> GetList()
        {
            return _movies;
        }

        public Movie CreateMovie(domain.Movie movie)
        {
            int index = _movies.FindIndex(x => x.Id == movie.Id);

            if (index < 0)
            {

                _movies.Add(movie);
                return movie;
            }
            else
            {
                throw new Exception("Movie already exists");
            }
        }


        /// <summary>
        /// Helper for upddate movie
        /// </summary>
        /// <param name="cur"></param>
        /// <param name="newMovie"></param>
        private void overWriteMovie(ref Movie cur, Movie newMovie)
        {
            if (cur.Id != newMovie.Id) { throw new Exception("Movies do not match."); }

            cur.Rating = newMovie.Rating;
            cur.ReleaseDate = newMovie.ReleaseDate;
            cur.Director = newMovie.Director;
            cur.TagLine = newMovie.TagLine;
            cur.Title = newMovie.Title;
        }


        public Movie UpdateMovie(Movie movie)
        {
            int index = _movies.FindIndex(x => x.Id == movie.Id);

            if (index < 0)
            {
                throw new Exception("Movie does not exist");
            }

            var item = _movies.FirstOrDefault(x => x.Id == movie.Id);
            if (item == null)
            {
                throw new Exception("Movie does not exist");
            }

            overWriteMovie(ref item, movie);
            _movies[index] = item; //this seems odd

            return item;
        }

        public void Delete(int id)
        {
            var item = _movies.FirstOrDefault(x => x.Id == id);
            _movies.Remove(item);
        }
    }
}