/*
 * Task01
 * 
 * Using ASP.NET Web API and Entity Framework (database first or code first) create a database and web services with full CRUD (create, read, update, delete) operations 
 * for hierarchy of following classes:
 * - Artists (Name, Country, DateOfBirth, etc.)
 * - Albums (Title, Year, Producer, etc.)
 * - Songs (Title, Year, Genre, etc.)
 * - Every album has a list of artists
 * - Every song has artist
 * - Every album has list of songs
 */

using DataModel;
using LibraryWebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibraryWebApi.Controllers
{
    public class SongsController : ApiController
    {
        // GET api/songs
        public IQueryable<Song> Get()
        {
            LibraryEntities context = new LibraryEntities();
            
            return context.Songs.Select(x => x);
        }

        // GET api/songs/5
        public Song Get(int id)
        {
            LibraryEntities context = new LibraryEntities();

            Song song = context.Songs.Find(id);
            return song;
        }

        // POST api/songs
        public void Post([FromBody]Song song)
        {
            LibraryEntities context = new LibraryEntities();

            context.Songs.Add(song);
            context.SaveChanges();
        }

        // PUT api/songs/5
        public void Put(int id, [FromBody]Song newSong)
        {
            LibraryEntities context = new LibraryEntities();

            Song song = context.Songs.Find(id);

            int songOriginalId = song.SongId;
            Utilities.CopyPropertyValues(newSong, song);
            song.SongId = songOriginalId;

            context.SaveChanges();
        }

        // DELETE api/songs/5
        public void Delete(int id)
        {
            LibraryEntities context = new LibraryEntities();

            Song song = context.Songs.Find(id);
            context.Songs.Remove(song);

            context.SaveChanges();
        }
    }
}
