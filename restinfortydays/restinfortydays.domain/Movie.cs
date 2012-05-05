using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restinfortydays.domain
{
        [Serializable]
        public class Movie
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public decimal Rating { get; set; }
            public string Director { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string TagLine { get; set; }
            public List<string> Genres { get; set; }
        }
}
