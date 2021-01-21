using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public class SortService
    {
        private static SortService instance = null;
        public static SortService GetServiceInstance()
        {
            if (instance == null)
            {
                instance = new SortService();
            }
            return instance;
        }
        public List<Movie> MergeTwoLists(List<Movie> list1, List<Movie> list2)
        {
            var listToMergeTo = list1;
            foreach (var movie in list2)
            {
                if (!listToMergeTo.Where(x => x.title == movie.title).Any())
                {
                    listToMergeTo.Add(movie);
                }
            }
            return listToMergeTo;
        }
        public List<Movie> SortList(List<Movie> list, bool ascending)
        {
            var listToReturn = new List<Movie>();
            ReplaceComma(list);
            if (ascending)
            {
                listToReturn = list.OrderBy(x => double.Parse(x.rated, CultureInfo.InvariantCulture)).ToList();
            }
            else
            {
                listToReturn = list.OrderByDescending(x => double.Parse(x.rated, CultureInfo.InvariantCulture)).ToList();
            }
            return listToReturn;
        }
        private List<Movie> ReplaceComma(List<Movie> movieList)
        {
            foreach (var movie in movieList)
            {
                if (movie.rated.Contains(","))
                {
                    movie.rated = movie.rated.Replace(',', '.');
                }
            }
            return movieList;
        }
    }
}
