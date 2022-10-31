using EFCoreMovie3_RazorPages.Models;
using EFCoreMovie3_RazorPages.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMovie3_RazorPages.Services.EFServices
{
    public class EFMoviesService:IMovieService
    {
        MovieDBContext context;
        public EFMoviesService(MovieDBContext service)
        {
            context = service;
        }
        public IEnumerable<Movie>  GetMovies(string filter)
        {
            return this.context.Set<Movie>().Where(s => s.Title.StartsWith(filter)).AsNoTracking().ToList();
        }
        public IEnumerable<Movie> GetMovies()
        {
            return context.Movies;
        }

        void IMovieService.AddMovie(Movie movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();
        }

        public Movie GetMovieById(int id)
        {
            return context.Movies.Find(id);
        }

        public void DeleteMovie(Movie movie)
        {
            context.Movies.Remove(movie);
            context.SaveChanges(true);
        }

        public IEnumerable<Movie> GetMoviesByStudioId(int id)
        {
            return this.context.Set<Movie>().Where(s => s.StudioId == id).AsNoTracking().ToList();
        }
    }
}
