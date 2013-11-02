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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibraryWebApi.Controllers
{
    public class AlbumsController : ApiController
    {
        // GET api/albums
        public IQueryable<Album> Get()
        {
            LibraryEntities context = new LibraryEntities();

            return context.Albums;
        }

        // GET api/albums/5
        public Album Get(int id)
        {
            LibraryEntities context = new LibraryEntities();

            Album album = context.Albums.Find(id);
            return album;
        }

        // POST api/albums
        public void Post([FromBody]Album album)
        {
            LibraryEntities context = new LibraryEntities();

            context.Albums.Add(album);
            context.SaveChanges();
        }

        // PUT api/albums/5
        public void Put(int id, [FromBody]Album newAlbum)
        {
            LibraryEntities context = new LibraryEntities();

            Album album = context.Albums.Find(id);

            int albumOriginalId = album.AlbumId;
            Utilities.CopyPropertyValues(newAlbum, album);
            album.AlbumId = albumOriginalId;

            context.SaveChanges();
        }

        // DELETE api/albums/5
        public void Delete(int id)
        {
            LibraryEntities context = new LibraryEntities();

            Album album = context.Albums.Find(id);
            context.Albums.Remove(album);

            context.SaveChanges();
        }
    }
}
