using Restt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restt.Repositories.Interfaces
{
    public interface IFilmRepository
    {
        Task<List<Film>> GetFilmsByActualAsync(int actual);

        Task<List<Film>> GetFilmsByDateAsync(DateTime? dateStart, DateTime? dateFinish);

        Task<List<Film>> GetFilmsByGenreAsync(int? genreType);

        Task<List<Film>> GetFilmsByNameGenreAsync(string genreName);

        Task<List<Film>> GetFilmsByNameAsync(string name);

        List<Film> GetFilmsByActual(int actual);

        List<Film> GetFilmsByDate(DateTime? dateStart, DateTime? dateFinish);

        List<Film> GetFilmsByGenre(int? genreType);

        List<Film> GetFilmsByNameGenre(string genreName);

        List<Film> GetFilmsByName(string name);

        List<Film> GetFilm(bool? actual = null, DateTime? startDate = null, DateTime? finishDate = null, int? genreType = null, string name = null);
    }
}
