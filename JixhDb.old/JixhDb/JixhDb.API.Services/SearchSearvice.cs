﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using JixhDb.Models.EntittyModels;
using JixhDb.Models.ViewModels.Movies;

namespace JixhDb.API.Services
{
    using JixhDb.API.Services.Contracts;

    public class SearchSearvice : Service, ISearchService
    {
        public IEnumerable<MovieSearchViewModel> GetAll(int i, string search)
        {
            var movies = this.Context.Movies.Where(movie => movie.Title.Contains(search));

            if (movies.Any())
            {
                if (movies.Count() > i)
                {
                    movies = movies.Take(i);
                }

                var searchRes = Mapper.Map<IEnumerable<Movie>, IEnumerable<MovieSearchViewModel>>(movies);
                foreach (var movie in searchRes)
                {
                    
                }
                return searchRes;

            }
            

            return null;

        }
    }
}
