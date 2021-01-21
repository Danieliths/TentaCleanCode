using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public class MovieInfoCollector
    {
        public List<Movie> GetAllMovies()
        {
            var client = new HttpClient();
            var sorter = new Sorter();
            var resultSimple = client.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/topp100.json").Result;
            var resultDetailed = client.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/detailedMovies.json").Result;
            var movieListSimple = JsonSerializer.Deserialize<List<Movie>>(new StreamReader(resultSimple.Content.ReadAsStream()).ReadToEnd());
            var movieListDetailed = JsonSerializer.Deserialize<List<MovieDetailed>>(new StreamReader(resultDetailed.Content.ReadAsStream()).ReadToEnd());
            var detailedListSimplified = movieListDetailed.Select(x => new Movie
            {
                id = x.id,
                title = x.title,
                rated = x.imdbRating.ToString(),
            }
            ).ToList();
            var mergedList = sorter.MergeTwoLists(movieListSimple, detailedListSimplified);
            return mergedList;
        }
    }
}
