using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace restinfortydays.service.Controllers
{
    public class ValuesController : ApiController
    {
        // GET /api/values
        public IEnumerable<restinfortydays.domain.Movie> Get()
        {
            
            var movie = new restinfortydays.domain.Movie();
            movie.Director = "Sam Huntington";
            movie.Genres = new List<String>() { "sam", "cam" };
            movie.Id = 1;
            movie.Rating = 2;
            movie.Title = "UnRestful Nights";
            movie.TagLine = "Sleep when dead";

            var movies = new List<restinfortydays.domain.Movie>();
            movies.Add(movie);
            return movies;

        }

        //// GET /api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST /api/values
        //public void Post(string value)
        //{
        //}

        //// PUT /api/values/5
        //public void Put(int id, string value)
        //{
        //}

        //// DELETE /api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}