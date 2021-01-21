using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.Models
{
    public class MovieDetailed
    {
        public string id { get; set; }
        public string title { get; set; }
        public string year { get; set; }
        public List<string> genres { get; set; }
        public List<int> ratings { get; set; }
        public string poster { get; set; }
        public string contentRating { get; set; }
        public string duration { get; set; }
        public string releaseDate { get; set; }
        public int averageRating { get; set; }
        public string originalTitle { get; set; }
        public string storyline { get; set; }
        public List<string> actors { get; set; }
        public object imdbRating { get; set; }
        public string posterurl { get; set; }
    }
}
