using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practical2_OPPPO.Collections;
using Practical2_OPPPO.Films;
using System;

namespace Practical2_OPPPO_Tests
{
    [TestClass]
    public class MyListTest
    {
        [TestMethod]
        public void TestInit()
        {
            MyList films = new MyList();

            Assert.AreEqual(0, films.Count);
        }

        [TestMethod]
        public void TestAddItem()
        {
            MyList films = new MyList();
            FeatureFilm ff = new FeatureFilm("Title 1", "Producer 1", 10.0f);
            CartoonFilm cf = new CartoonFilm("Title 2", FilmType.Cartoon, 7.5f);
            HorrorFilm hf = new HorrorFilm("Title 3", "Producer 3", 5.0f);

            films.Add(ff);
            films.Add(cf);
            films.Add(hf);

            Assert.AreEqual(3, films.Count);

            int i = 0;
            Film[] test = { ff, cf, hf };

            foreach (Film film in films)
                Assert.AreEqual(test[i++], film);
        }

        [TestMethod]
        public void TestRemove()
        {
            MyList films = new MyList();
            FeatureFilm ff = new FeatureFilm("Title 1", "Producer 1", 10.0f);
            CartoonFilm cf = new CartoonFilm("Title 2", FilmType.Cartoon, 7.5f);
            HorrorFilm hf = new HorrorFilm("Title 3", "Producer 3", 5.0f);

            films.Add(ff);
            films.Add(cf);
            films.Add(hf);

            Predicate<Film> ratingLessThanTen = (Film film) => { return film.Rating < 10.0f; };

            films.Remove(ratingLessThanTen);

            foreach (Film film in films)
                Assert.IsTrue(film.Rating >= 10.0f);
        }

        [TestMethod]
        public void TestSortAscending()
        {
            MyList films = new MyList();
            FeatureFilm ff = new FeatureFilm("Title 1", "Producer 1", 10.0f);
            CartoonFilm cf = new CartoonFilm("Title 2", FilmType.Cartoon, 7.5f);
            HorrorFilm hf = new HorrorFilm("Title 3", "Producer 3", 5.0f);

            films.Add(ff);
            films.Add(cf);
            films.Add(hf);

            films.Sort(SortType.Ascending);

            float[] ratings = new float[3];
            int i = 0;

            foreach (Film film in films)
                ratings[i++] = film.Rating;
            

            for (int j = 1; j < ratings.Length; j++)
                Assert.IsTrue(ratings[j] >= ratings[j - 1]);
        }

        [TestMethod]
        public void TestSortDescending()
        {
            MyList films = new MyList();
            FeatureFilm ff = new FeatureFilm("Title 1", "Producer 1", 10.0f);
            CartoonFilm cf = new CartoonFilm("Title 2", FilmType.Cartoon, 7.5f);
            HorrorFilm hf = new HorrorFilm("Title 3", "Producer 3", 5.0f);

            films.Add(ff);
            films.Add(cf);
            films.Add(hf);

            films.Sort();

            float[] ratings = new float[3];
            int i = 0;

            foreach (Film film in films)
                ratings[i++] = film.Rating;

            for (int j = 1; j < ratings.Length; j++)
                Assert.IsTrue(ratings[j] <= ratings[j - 1]);
        }
    }
}
