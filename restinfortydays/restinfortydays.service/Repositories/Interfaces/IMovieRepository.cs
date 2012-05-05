using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using restinfortydays.domain;

namespace restinfortydays.service.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        Movie GetMovie(int Id);
        IEnumerable<Movie> GetList();
        Movie CreateMovie(Movie movie);
        Movie UpdateMovie(Movie movie);
        void Delete(int id);
    }
}