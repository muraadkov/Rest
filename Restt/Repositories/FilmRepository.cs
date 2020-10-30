using Restt.Context;
using Restt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Dapper;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Restt.Repositories.Interfaces;
using System.Data.SqlClient;

namespace Restt.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly RestContext _context;

        public FilmRepository(RestContext context)
        {
            _context = context;
        }

        public async Task<List<Film>> GetFilmsByActualAsync(int actual)
        {
            var films = await _context.Films.Where(film => film.Actual == actual).ToListAsync();
            return films;
        } 

        public async Task<List<Film>> GetFilmsByDateAsync(DateTime? dateStart, DateTime? dateFinish)
        {
            var films = await _context.Films.Where(film => film.DateOfStart > dateStart && film.DateOfFinish < dateFinish).ToListAsync();
            return films;
        }

        public async Task<List<Film>> GetFilmsByGenreAsync(int? genreType)
        {
            var films = await _context.Films.Where(film => film.GenreType == genreType).ToListAsync();
            return films;
        }

        public async Task<List<Film>> GetFilmsByNameGenreAsync(string genreName)
        {
            var type = await _context.DictGenres.SqlQuery("select * from DictGenres where Genre like @name", new SqlParameter("@name", genreName)).FirstOrDefaultAsync();
            long numType = type.Id;
            var films = await _context.Films.Where(film => film.GenreType == numType).ToListAsync();
            return films;
        }

        public async Task<List<Film>> GetFilmsByNameAsync(string name)
        {
            var films = await _context.Films.SqlQuery("select * from Films where Name like @name", new SqlParameter("@name", name+'%')).ToListAsync();
            //var films = await _context.Films.Where(film => film.Name == name).ToListAsync();
            return films;
        }

        public List<Film> GetFilmsByActual(int actual)
        {
            var films = _context.Films.Where(film => film.Actual == actual).ToList();
            return films;
        }

        public List<Film> GetFilmsByDate(DateTime? dateStart, DateTime? dateFinish)
        {
            var films =  _context.Films.Where(film => film.DateOfStart > dateStart && film.DateOfFinish < dateFinish).ToList();
            return films;
        }

        public List<Film> GetFilmsByGenre(int? genreType)
        {
            var films = _context.Films.Where(film => film.GenreType == genreType).ToList();
            return films;
        }

        public List<Film> GetFilmsByNameGenre(string genreName)
        {
            var type = _context.DictGenres.SqlQuery("select * from DictGenres where Genre like @name", new SqlParameter("@name", genreName)).FirstOrDefault();
            long numType = type.Id;
            var films = _context.Films.Where(film => film.GenreType == numType).ToList();
            return films;
        }

        public List<Film> GetFilmsByName(string name)
        {
            var films = _context.Films.SqlQuery("select * from Films where Name like @name", new SqlParameter("@name", name + '%')).ToList();
            //var films = await _context.Films.Where(film => film.Name == name).ToListAsync();
            return films;
        }

        List<Film> IFilmRepository.GetFilm(bool? actual, DateTime? startDate, DateTime? finishDate, int? genreType, string name)
        {
            var films = new List<Film>();
            if(actual != null)
            {
                films = GetFilmsByActual(Convert.ToInt32(actual));
            }
            if (genreType != null)
            {
                films.AddRange(GetFilmsByGenre(genreType));
            }
            if (startDate != null && finishDate != null)
            {
                films.AddRange(GetFilmsByDate(startDate, finishDate));
            }
            if(name != null)
            {
                 films.AddRange(GetFilmsByName(name));        
             }

            return films;


            //var films = _context.Films.Where(film => actual != null ? film.Actual == Convert.ToInt32(actual) &&
            //    dateInterval != null== dateInterval &&
            //        genreType != null ? film.GenreType == genreType && name != null ? film.Name == name
            //    : genreType != null ? film.GenreType == genreType
            //    : name != null ? film.Name == name
            //    : dateInterval != null ? film.DateOfFinish - film.DateOfStart == dateInterval
            //    : genreType != null ? film.GenreType == genreType
            //    : name != null ? film.Name == name).ToList();
        }


       
    }
}
