using BlazorMovies.Shared;
using BlazorMovies.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Helpers
{
    public class RepositoryInMemory : IRepository
    {
        public List<Movie> GetMovies()
        {
            return new List<Movie>()
    {
                    new Movie(){Title="Spider Man : For Far",ReleaseDate = new DateTime(2015,2,27)},
                    new Movie(){Title="Inception",ReleaseDate = new DateTime(2011,03,04)},
                    new Movie(){Title="Star Ware",ReleaseDate=new DateTime(2010,05,04)}
            };
        }
    }
}
