using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using restinfortydays.domain;
using restinfortydays.service.Repositories;
using restinfortydays.service.Repositories.Interfaces;

namespace restinfortydays.service.Controllers
{
    public class MoviesController : ApiController
    { 
        //di pattern
        private readonly IMovieRepository _repository;
        
        public MoviesController() : this(new MovieRepository()) { }

        public MoviesController(IMovieRepository repository)
        {
            this._repository = repository;
        }

        //GET /api/movies
        public IEnumerable<Movie> Get()
        {
            var list = _repository.GetList();

            if (list == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return list;
        }

        //GET /api/movies/5
        public Movie Get(int id)
        {
            var item = _repository.GetMovie(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;        
        }

        //POST /api/movies
        public Movie Post(Movie movie)
        {
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return _repository.UpdateMovie(movie);
        }

        // PUT /api/movies/5
        public Movie Put(Movie movie)
        {
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return _repository.CreateMovie(movie);
        }

        // DELETE /api/movies/5
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

    }
       
}