using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FreeContent;

namespace CatalogOfFreeContent.Test
{
    [TestClass]
    public class CatalogTest
    {
        [TestMethod]
        public void TestAddTwiseTheSameItem()
        {
            Catalog catalog = new Catalog(); 
            catalog.Add(new ContentItem(ItemType.Book, 
                new string[]{"Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info"}));

            catalog.Add(new ContentItem(ItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" }));

            int resultCount = catalog.CountContentByTitle;
            Assert.AreEqual(resultCount, 2);
        }

        [TestMethod]
        public void TestAddMultipleDifferentItems()
        {
            Catalog catalog = new Catalog();
            catalog.Add(new ContentItem(ItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" }));

            catalog.Add(new ContentItem(ItemType.Song,
                new string[] { "Song", "Autor", "123", "http://www.song.info" }));

            catalog.Add(new ContentItem(ItemType.Application,
                new string[] { "C#", "Programmer Autor", "4654654", "http://www.csharp.com" }));

            catalog.Add(new ContentItem(ItemType.Movie,
                new string[] { "Iron Man", "Movie Director", "127643892", "http://www.movies.info" }));

            catalog.Add(new ContentItem(ItemType.Movie,
                new string[] { "Iron Man", "Movie Director", "127643892", "http://www.movies.info" }));

            catalog.Add(new ContentItem(ItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" }));

            int resultCount = catalog.CountContentByTitle;
            Assert.AreEqual(resultCount, 6);
        }

        [TestMethod]
        public void TestAddTwiseTheSameItemBySearch()
        {
            Catalog catalog = new Catalog();
            catalog.Add(new ContentItem(ItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" }));

            catalog.Add(new ContentItem(ItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" }));

            IEnumerable<IContent> resultsSearch = catalog.GetListContent("Intro C#", 2);

            int resultCount = resultsSearch.Count();
            Assert.AreEqual(resultCount, 2);
        }

        [TestMethod]
        public void TestAddMultipleDifferentItemsBySearch()
        {
            Catalog catalog = new Catalog();
            ContentItem book = new ContentItem(ItemType.Book, new string[]
                {
                    "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info"
                });
            catalog.Add(book);

            ContentItem song = new ContentItem(ItemType.Song, new string[]
                {
                    "Song", "Autor", "1223423443", "http://www.song.info"
                });
            catalog.Add(song);
            
            ContentItem app = new ContentItem(ItemType.Application, new string[]
                {
                    "C#", "Programmer", "122343", "http://www.csharp.info"
                });
            catalog.Add(app);

            ContentItem movie = new ContentItem(ItemType.Movie, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(movie);

            ContentItem movie2 = new ContentItem(ItemType.Movie, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(movie2);

            ContentItem movie3 = new ContentItem(ItemType.Movie, new string[]
                {
                    "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info"
                });
            catalog.Add(movie3);
            
            IEnumerable<IContent> resultsSearch = catalog.GetListContent("Intro C#", 2);

            IContent firstResult = resultsSearch.First();
            Assert.AreSame(firstResult, book);
            IContent secondResult = resultsSearch.Skip(1).First();
            Assert.AreSame(secondResult, movie3);

            IEnumerable<IContent> newSearch = catalog.GetListContent("Iron Man", 2);
            IContent firstResultNewSearch = newSearch.First();
            Assert.AreSame(firstResultNewSearch, movie);
            IContent secondResultNewSearch = newSearch.Skip(1).First();
            Assert.AreSame(secondResultNewSearch, movie2);
        }

        [TestMethod]
        public void TestGetListContentMissingTitle()
        {
            Catalog catalog = new Catalog();
            ContentItem book = new ContentItem(ItemType.Book, new string[]
                {
                    "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info"
                });
            catalog.Add(book);

            ContentItem song = new ContentItem(ItemType.Song, new string[]
                {
                    "Song", "Autor", "1223423443", "http://www.song.info"
                });
            catalog.Add(song);

            ContentItem app = new ContentItem(ItemType.Application, new string[]
                {
                    "C#", "Programmer", "122343", "http://www.csharp.info"
                });
            catalog.Add(app);

            ContentItem movie = new ContentItem(ItemType.Movie, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(movie);

            IEnumerable<IContent> resultsSearch = catalog.GetListContent("Unknow", 2);

            int resultCount = resultsSearch.Count();
            Assert.AreEqual(resultCount, 0);
        }

        [TestMethod]
        public void TestGetListContentOne()
        {
            Catalog catalog = new Catalog();
            ContentItem book = new ContentItem(ItemType.Book, new string[]
                {
                    "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info"
                });
            catalog.Add(book);

            ContentItem song = new ContentItem(ItemType.Song, new string[]
                {
                    "Song", "Autor", "1223423443", "http://www.song.info"
                });
            catalog.Add(song);

            ContentItem app = new ContentItem(ItemType.Application, new string[]
                {
                    "C#", "Programmer", "122343", "http://www.csharp.info"
                });
            catalog.Add(app);

            ContentItem movie = new ContentItem(ItemType.Movie, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(movie);

            IEnumerable<IContent> resultsSearch = catalog.GetListContent("Song", 2);

            int resultCount = resultsSearch.Count();
            Assert.AreEqual(resultCount, 1);
        }

        [TestMethod]
        public void TestGetListContentPartOfResults()
        {
            Catalog catalog = new Catalog();
            ContentItem book = new ContentItem(ItemType.Book, new string[]
                {
                    "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info"
                });
            catalog.Add(book);

            ContentItem song = new ContentItem(ItemType.Song, new string[]
                {
                    "Song", "Autor", "1223423443", "http://www.song.info"
                });
            catalog.Add(song);

            ContentItem app = new ContentItem(ItemType.Application, new string[]
                {
                    "C#", "Programmer", "122343", "http://www.csharp.info"
                });
            catalog.Add(app);

            ContentItem movie = new ContentItem(ItemType.Movie, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(movie);

            ContentItem movie1 = new ContentItem(ItemType.Movie, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(movie1);

            ContentItem book1 = new ContentItem(ItemType.Book, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(book1);

            ContentItem book2 = new ContentItem(ItemType.Book, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(book2);

            IEnumerable<IContent> resultsSearch = catalog.GetListContent("Iron Man", 3);

            int resultCount = resultsSearch.Count();
            Assert.AreEqual(resultCount, 3);
            
            IContent firstResult = resultsSearch.First();
            Assert.AreSame(firstResult, book1);
            IContent secondResult = resultsSearch.Skip(1).First();
            Assert.AreSame(secondResult, book2);
            IContent thirdResult = resultsSearch.Skip(2).First();
            Assert.AreSame(thirdResult, movie);
        }

        [TestMethod]
        public void TestGetListContentMoreResults()
        {
            Catalog catalog = new Catalog();
            ContentItem book = new ContentItem(ItemType.Book, new string[]
                {
                    "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info"
                });
            catalog.Add(book);

            ContentItem song = new ContentItem(ItemType.Song, new string[]
                {
                    "Song", "Autor", "1223423443", "http://www.song.info"
                });
            catalog.Add(song);

            ContentItem app = new ContentItem(ItemType.Application, new string[]
                {
                    "C#", "Programmer", "122343", "http://www.csharp.info"
                });
            catalog.Add(app);

            ContentItem movie = new ContentItem(ItemType.Movie, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(movie);

            ContentItem movie1 = new ContentItem(ItemType.Movie, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(movie1);

            ContentItem book1 = new ContentItem(ItemType.Book, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(book1);

            ContentItem book2 = new ContentItem(ItemType.Book, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(book2);

            IEnumerable<IContent> resultsSearch = catalog.GetListContent("Iron Man", 5);

            int resultCount = resultsSearch.Count();
            Assert.AreEqual(resultCount, 4);

            IContent firstResult = resultsSearch.First();
            Assert.AreSame(firstResult, book1);
            IContent secondResult = resultsSearch.Skip(1).First();
            Assert.AreSame(secondResult, book2);
            IContent thirdResult = resultsSearch.Skip(2).First();
            Assert.AreSame(thirdResult, movie);
            IContent fourthResult = resultsSearch.Skip(3).First();
            Assert.AreSame(fourthResult, movie1);
        }

        [TestMethod]
        public void TestUpdateContentMissing()
        {
            Catalog catalog = new Catalog();
            ContentItem book = new ContentItem(ItemType.Book, new string[]
                {
                    "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info"
                });
            catalog.Add(book);

            ContentItem song = new ContentItem(ItemType.Song, new string[]
                {
                    "Song", "Autor", "1223423443", "http://www.song.info"
                });
            catalog.Add(song);

            ContentItem app = new ContentItem(ItemType.Application, new string[]
                {
                    "C#", "Programmer", "122343", "http://www.csharp.info"
                });
            catalog.Add(app);

            ContentItem movie = new ContentItem(ItemType.Movie, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(movie);

            ContentItem movie1 = new ContentItem(ItemType.Movie, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(movie1);

            ContentItem book1 = new ContentItem(ItemType.Book, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(book1);

            ContentItem book2 = new ContentItem(ItemType.Book, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(book2);

            int resultCount = catalog.UpdateContent("abv.bg", "abv1.bg");
            Assert.AreEqual(resultCount, 0);
        }

        [TestMethod]
        public void TestUpdateContentOneResult()
        {
            Catalog catalog = new Catalog();
            ContentItem book = new ContentItem(ItemType.Book, new string[]
                {
                    "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info"
                });
            catalog.Add(book);

            ContentItem song = new ContentItem(ItemType.Song, new string[]
                {
                    "Song", "Autor", "1223423443", "http://www.song.info"
                });
            catalog.Add(song);

            ContentItem app = new ContentItem(ItemType.Application, new string[]
                {
                    "C#", "Programmer", "122343", "http://www.csharp.info"
                });
            catalog.Add(app);

            ContentItem movie = new ContentItem(ItemType.Movie, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(movie);

            ContentItem movie1 = new ContentItem(ItemType.Movie, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(movie1);

            ContentItem book1 = new ContentItem(ItemType.Book, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(book1);

            ContentItem book2 = new ContentItem(ItemType.Book, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(book2);

            int resultCount = catalog.UpdateContent("http://www.song.info", "http://www.great_song.com");
            Assert.AreEqual(resultCount, 1);

            IEnumerable<IContent> resultsSearch = catalog.GetListContent("Song", 5);

            IContent firstResult = resultsSearch.First();
            Assert.AreSame(firstResult, song);

            string songUrl = song.Url;
            Assert.AreEqual(songUrl, "http://www.great_song.com");
        }

        [TestMethod]
        public void TestUpdateContentSeveral()
        {
            Catalog catalog = new Catalog();
            ContentItem book = new ContentItem(ItemType.Book, new string[]
                {
                    "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info"
                });
            catalog.Add(book);

            ContentItem song = new ContentItem(ItemType.Song, new string[]
                {
                    "Song", "Autor", "1223423443", "http://www.song.info"
                });
            catalog.Add(song);

            ContentItem app = new ContentItem(ItemType.Application, new string[]
                {
                    "C#", "Programmer", "122343", "http://www.csharp.info"
                });
            catalog.Add(app);

            ContentItem movie = new ContentItem(ItemType.Movie, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(movie);

            ContentItem movie1 = new ContentItem(ItemType.Movie, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(movie1);

            ContentItem book1 = new ContentItem(ItemType.Book, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(book1);

            ContentItem book2 = new ContentItem(ItemType.Book, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(book2);

            int resultCount = catalog.UpdateContent("http://www.movies.info", "http://www.csharp.info");
            Assert.AreEqual(resultCount, 4);

            int newResultCount = catalog.UpdateContent("http://www.csharp.info", 
                "http://www.CSharpForEver.info");
            Assert.AreEqual(newResultCount, 5);

            IEnumerable<IContent> resultsSearchRandomMovie = catalog.GetListContent("Iron Man", 5);

            IContent firstResult = resultsSearchRandomMovie.First();
            Assert.AreSame(firstResult, book1);

            string book1Url = book1.Url;
            Assert.AreEqual(book1Url, "http://www.CSharpForEver.info");
        }

        [TestMethod]
        public void TestUpdateContentCountContentByTitleAndByUrl()
        {
            Catalog catalog = new Catalog();
            ContentItem book = new ContentItem(ItemType.Book, new string[]
                {
                    "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info"
                });
            catalog.Add(book);

            ContentItem song = new ContentItem(ItemType.Song, new string[]
                {
                    "Song", "Autor", "1223423443", "http://www.song.info"
                });
            catalog.Add(song);

            ContentItem app = new ContentItem(ItemType.Application, new string[]
                {
                    "C#", "Programmer", "122343", "http://www.csharp.info"
                });
            catalog.Add(app);

            ContentItem app1 = new ContentItem(ItemType.Application, new string[]
                {
                    "Iron Man", "Programmer", "12122343", "http://www.IronManApp.info"
                });
            catalog.Add(app1);

            ContentItem movie = new ContentItem(ItemType.Movie, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(movie);

            ContentItem movie1 = new ContentItem(ItemType.Movie, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(movie1);

            ContentItem book1 = new ContentItem(ItemType.Book, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(book1);

            ContentItem book2 = new ContentItem(ItemType.Book, new string[]
                {
                    "Iron Man", "Movie Director", "127643892", "http://www.movies.info"
                });
            catalog.Add(book2);

            int resultCount = catalog.UpdateContent("http://www.movies.info", "http://www.csharp.info");
            Assert.AreEqual(resultCount, 4);

            int newResultCount = catalog.UpdateContent("http://www.csharp.info",
                "http://www.CSharpForEver.info");
            Assert.AreEqual(newResultCount, 5);

            int countContentByTitle = catalog.CountContentByTitle;
            Assert.AreEqual(countContentByTitle, 8);

            int countContentByUrl = catalog.CountContentByUrl;
            Assert.AreEqual(countContentByUrl, 8);

            string urlIronManAppNotToBeUpdated = app1.Url;
            Assert.AreEqual(urlIronManAppNotToBeUpdated, "http://www.IronManApp.info");
        }
    }
}
