using Restt.Context;
using Restt.Repositories;
using Restt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restt
{
    public class RestMenu
    {
        public void Menu()
        {
            RestContext restContext = new RestContext();
            IFilmRepository filmRepository = new FilmRepository(restContext);
            IDictRepository dictRepository = new DictRepository(restContext);

            //var films = filmRepository.GetFilmsByGenre(1).Result.ToList();
            //foreach (var film in films)
            //{
            //    Console.WriteLine(film.Id + " " + film.Name + " " + film.GenreType);
            //}
            while (true)
            {
                Console.WriteLine("Hello to Rest Application!\n1.Get films by Actual\n2.Get films by Date Interval\n3.Get film by Genre\n4.Get film by Name" +
                "\n5.Get film\n6.Get dictionary\n7.Exit");
                int number = Convert.ToInt32(Console.ReadLine());
                if (number == 7) break;
                switch (number)
                {
                    case 1:
                        Console.WriteLine("0 - Not Actual\n1 - Actual");
                        int actualType = Convert.ToInt32(Console.ReadLine());

                        var filmsByActual = filmRepository.GetFilmsByActualAsync(actualType).Result.ToList();
                        foreach (var film in filmsByActual)
                        {
                            string actual = "";
                            var type = restContext.DictGenres.Where(dictGenre => dictGenre.Id == film.GenreType).FirstOrDefault();

                            if (film.Actual == 1) actual = "Актуальный";
                            else actual = "Неактуальный";

                            Console.WriteLine("Жанр: " + type.Genre + "\nНазвание фильма: " + film.Name + "\nДата начала проката: "
                                + film.DateOfStart + "\nДата конца проката: " + film.DateOfFinish + "\nАктуальность: " + actual);
                            Console.ReadLine();

                        }
                        break;
                    case 2:
                        Console.WriteLine("Write start date: ");
                        Console.WriteLine("Write day: ");
                        int dayStart = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Write month: ");
                        int monthStart = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Write year: ");
                        int yearStart = Convert.ToInt32(Console.ReadLine());
                        DateTime startDate = new DateTime(yearStart, monthStart, dayStart);

                        Console.WriteLine("Write finish date: ");
                        Console.WriteLine("Write day: ");
                        int dayFinish = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Write month: ");
                        int monthFinish = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Write year: ");
                        int yearFinish = Convert.ToInt32(Console.ReadLine());
                        DateTime finishDate = new DateTime(yearFinish, monthFinish, dayFinish);

                        var filmsByDate = filmRepository.GetFilmsByDateAsync(startDate, finishDate).Result.ToList();
                        foreach (var film in filmsByDate)
                        {
                            string actual = "";
                            var type = restContext.DictGenres.Where(dictGenre => dictGenre.Id == film.GenreType).FirstOrDefault();

                            if (film.Actual == 1) actual = "Актуальный";
                            else actual = "Неактуальный";

                            Console.WriteLine("Жанр: " + type.Genre + "\nНазвание фильма: " + film.Name + "\nДата начала проката: "
                                + film.DateOfStart + "\nДата конца проката: " + film.DateOfFinish + "\nАктуальность: " + actual);
                            Console.ReadLine();
                        }
                        break;
                    case 3:
                        Console.WriteLine("Write genre name: ");
                        string genreName = Console.ReadLine();
                        var filmsByGenre = filmRepository.GetFilmsByNameGenreAsync(genreName).Result.ToList();
                        foreach (var film in filmsByGenre)
                        {
                            string actual = "";
                            var type = restContext.DictGenres.Where(dictGenre => dictGenre.Id == film.GenreType).FirstOrDefault();

                            if (film.Actual == 1) actual = "Актуальный";
                            else actual = "Неактуальный";

                            Console.WriteLine("Жанр: " + type.Genre + "\nНазвание фильма: " + film.Name + "\nДата начала проката: "
                                + film.DateOfStart + "\nДата конца проката: " + film.DateOfFinish + "\nАктуальность: " + actual);
                            Console.ReadLine();

                        }
                        break;
                    case 4:
                        Console.WriteLine("Write film name: ");
                        string filmName = Console.ReadLine();
                        var filmsByName = filmRepository.GetFilmsByNameAsync(filmName).Result.ToList();
                        foreach (var film in filmsByName)
                        {
                            string actual = "";
                            var type = restContext.DictGenres.Where(dictGenre => dictGenre.Id == film.GenreType).FirstOrDefault();

                            if (film.Actual == 1) actual = "Актуальный";
                            else actual = "Неактуальный";

                            Console.WriteLine("Жанр: " + type.Genre + "\nНазвание фильма: " + film.Name + "\nДата начала проката: "
                                + film.DateOfStart + "\nДата конца проката: " + film.DateOfFinish + "\nАктуальность: " + actual);
                            Console.ReadLine();

                        }
                        break;
                    case 5:
                        bool? actualFilm = null; DateTime? startDateFilm = null; DateTime? finishDateFilm = null;
                        int? genreType = null; string name = null;
                        Console.WriteLine("Write actual: \nFalse - Not actual\nTrue - Actual\nNote: You can write null");

                        var check = Console.ReadLine();
                        if (check != "null") actualFilm = Convert.ToBoolean(check);

                        Console.WriteLine("Write start date: \nNote: You can write null");
                        Console.WriteLine("Write day: ");
                        check = Console.ReadLine();
                        if (check != "null")
                        {
                            int dayStartFilm = Convert.ToInt32(check);
                            Console.WriteLine("Write month: ");
                            int monthStartFilm = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Write year: ");
                            int yearStartFilm = Convert.ToInt32(Console.ReadLine());
                            startDateFilm = new DateTime(yearStartFilm, monthStartFilm, dayStartFilm);
                        }


                        Console.WriteLine("Write finish date: \nNote: You can write null");
                        Console.WriteLine("Write day: ");
                        check = Console.ReadLine();
                        if (check != "null")
                        {
                            int dayFinishFilm = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Write month: ");
                            int monthFinishFilm = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Write year: ");
                            int yearFinishFilm = Convert.ToInt32(Console.ReadLine());
                            finishDateFilm = new DateTime(yearFinishFilm, monthFinishFilm, dayFinishFilm);
                        }

                        Console.WriteLine("Write genre id: \n1 - Comedy\n2 - Fantasy\n3 - Documental\nNote: You can write null");
                        check = Console.ReadLine();
                        if (check != "null") genreType = Convert.ToInt32(check);
                        Console.WriteLine("Write film name: \nNote: You can write null");
                        check = Console.ReadLine();
                        if (check != "null") name = check;

                        var films = filmRepository.GetFilm(actualFilm, startDateFilm, finishDateFilm, genreType, name).ToList();
                        foreach (var film in films)
                        {
                            string actual = "";
                            var type = restContext.DictGenres.Where(dictGenre => dictGenre.Id == film.GenreType).FirstOrDefault();

                            if (film.Actual == 1) actual = "Актуальный";
                            else actual = "Неактуальный";

                            Console.WriteLine("Жанр: " + type.Genre + "\nНазвание фильма: " + film.Name + "\nДата начала проката: "
                                + film.DateOfStart + "\nДата конца проката: " + film.DateOfFinish + "\nАктуальность: " + actual);
                            Console.ReadLine();

                        }
                        break;
                    case 6:
                        Console.WriteLine("What dictionary you want to view?\nCountries\nGenres");
                        string dict = Console.ReadLine();
                        Console.WriteLine(dictRepository.GetDict(dict));
                        break;
                    
                }
            }




        }
    }
    }
