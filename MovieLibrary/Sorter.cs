using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public class Sorter
    {
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
            if (ascending)
            {
                listToReturn = list.OrderBy(x => x.rated).ToList();
            }
            else
            {
                listToReturn = list.OrderByDescending(x => x.rated).ToList();
            }
            return listToReturn;
        }

    }
}
