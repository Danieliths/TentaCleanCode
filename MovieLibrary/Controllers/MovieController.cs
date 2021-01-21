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
        [HttpGet]
        [Route("/toplist")]
        public IActionResult GetAllMovies(bool ascending = true)
        {
            var sorter = new Sorter();
            var service = MovieService.GetServiceInstance();
            var allMovies = service.GetAllMovies();
            var sortedList = sorter.SortList(allMovies, ascending);
            return new OkObjectResult(sortedList);
        }

        [HttpGet]
        [Route("/movie")]
        public IActionResult GetMovieById(string id)
        {
            var sorter = new Sorter();
            var service = MovieService.GetServiceInstance();
            var allMovies = service.GetAllMovies();
            var movieToReturn = allMovies.Where(x => x.id == id).FirstOrDefault();
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