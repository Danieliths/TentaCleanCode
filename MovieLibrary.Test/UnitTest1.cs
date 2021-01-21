using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieLibrary;
using MovieLibrary.Models;
using System.Collections.Generic;

namespace MovieLibrary.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SortList()
        {
            //Arrange
            var sorterService = SortService.GetServiceInstance();
            List<Movie> expected = new List<Movie>
            {
                new Movie
                {
                title = "Pulp Fiction",
                id = "tt0110912",
                rated =  "8,8"
                },
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
            };
            List<Movie> secondExpected = new List<Movie>
            {
                new Movie
                {
                title = "The Godfather",
                id = "tt0068646",
                rated =  "9,1"
                },
                new Movie
                {
                title = "The Godfather: Part II",
                id = "tt0071562",
                rated =  "9,0"
                },
                new Movie
                {
                title = "Pulp Fiction",
                id = "tt0110912",
                rated =  "8,8"
                },
            };
            List<Movie> listToSort = new List<Movie>
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
            // Act
            var actual = sorterService.SortList(listToSort, true);
            var secondActual = sorterService.SortList(listToSort, false);
            //Assert
            Assert.AreEqual(expected[0].title, actual[0].title);
            Assert.AreEqual(expected[1].title, actual[1].title);
            Assert.AreEqual(expected[2].title, actual[2].title);
            Assert.AreEqual(secondExpected[0].title, secondActual[0].title);
            Assert.AreEqual(secondExpected[1].title, secondActual[1].title);
            Assert.AreEqual(secondExpected[2].title, secondActual[2].title);
        }
        [TestMethod]
        public void MergeTwoLists()
        {
            //Arrange
            var sorterService = SortService.GetServiceInstance();
            List<Movie> expected = new List<Movie>
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
                new Movie
                {
                title = "The Godfasdfather: Part IIII",
                id = "tt0071dfd562",
                rated =  "10"
                },
            };
            List<Movie> listToMerge1 = new List<Movie>
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
            List<Movie> listToMerge2 = new List<Movie>
            {
                new Movie
                {
                title = "The Godfasdfather: Part IIII",
                id = "tt0071dfd562",
                rated =  "10"
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
            // Act
            var actual = sorterService.MergeTwoLists(listToMerge1, listToMerge2);
            //Assert
            Assert.AreEqual(expected[0].title, actual[0].title);
            Assert.AreEqual(expected[1].title, actual[1].title);
            Assert.AreEqual(expected[2].title, actual[2].title);
            Assert.AreEqual(expected[3].title, actual[3].title);
        }
    }
}
