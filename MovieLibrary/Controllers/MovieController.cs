using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Models;

namespace MovieLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController
    {
        static HttpClient client = new HttpClient();

        [HttpGet]
        [Route("/allmovies")]
        public IActionResult GetAllMovies(bool asc = true)
        {
            List<string> listToReturn = new List<string>();
            List<Movie> listToMergeTo = new List<Movie>();
            var resultSimple = client.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/topp100.json").Result;
            var resultDetailed = client.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/detailedMovies.json").Result;

            var movieListSimple = JsonSerializer.Deserialize<List<Movie>>(new StreamReader(resultSimple.Content.ReadAsStream()).ReadToEnd());
            var movieListDetailed = JsonSerializer.Deserialize<List<MovieDetailed>>(new StreamReader(resultDetailed.Content.ReadAsStream()).ReadToEnd());

            var sorter = new Sorter();

            var listToSort = new List<Movie>
            {
                new Movie
                {
                title = "The Godfather: Part II",
                id = "tt0071562",
                rated =  "9,0"
                },
                new Movie
                {

                title = "The Godfather",
                id = "tt0068646",
                rated =  "9,1"
                },
                new Movie
                {
                title = "Pulp Fiction",
                id = "tt0110912",
                rated =  "8,8"
                },
            };
            var test = sorter.SortList(listToSort, true);

            listToMergeTo = movieListSimple;
            var detailedListSimplified = movieListDetailed.Select(x => new Movie
            {
                id = x.id,
                title = x.title,
                rated = x.imdbRating.ToString(),
            }
            ).ToList();

            foreach (var movie in detailedListSimplified)
            {
                if (!listToMergeTo.Where(x => x.title == movie.title).Any())
                {
                    listToMergeTo.Add(movie);
                }
            }

            if (asc)
            {
                listToReturn = listToMergeTo.OrderBy(x => x.rated).Select(x => x.title).ToList();
            }
            else
            {
                listToReturn = listToMergeTo.OrderByDescending(x => x.rated).Select(x => x.title).ToList();
            }
            return new OkObjectResult(listToReturn);
        }

        [HttpGet]
        [Route("/toplist")]
        public IActionResult Toplist(bool asc = true)
        {
            List<string> listToReturn = new List<string>();
            var result = client.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/topp100.json").Result;
            var movieList = JsonSerializer.Deserialize<List<Movie>>(new StreamReader(result.Content.ReadAsStream()).ReadToEnd());
            if (asc)
            {
                listToReturn = movieList.OrderBy(x => x.rated).Select(x => x.title).ToList();
            }
            else
            {
                listToReturn = movieList.OrderByDescending(x => x.rated).Select(x => x.title).ToList();
            }
            return new OkObjectResult(listToReturn);
        }



        [HttpGet]
        [Route("/movie")]
        public IActionResult GetMovieById(string id)
        {
            var result = client.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/topp100.json").Result;
            var movieList = JsonSerializer.Deserialize<List<Movie>>(new StreamReader(result.Content.ReadAsStream()).ReadToEnd());
            var movieToReturn = movieList.Where(x => x.id == id).FirstOrDefault();
            if (movieToReturn != null)
            {
                return new OkObjectResult(movieToReturn);
            }
            else
            {
                return new ConflictObjectResult("Cant find that id");
            }
        }
    }
}