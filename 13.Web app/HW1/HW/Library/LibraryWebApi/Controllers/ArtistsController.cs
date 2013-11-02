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
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace LibraryWebApi.Controllers
{
    public class ArtistsController : ApiController
    {
        // GET api/artists
        public IQueryable<Artist> Get()
        {
            LibraryEntities context = new LibraryEntities();

            return context.Artists;
        }

        // GET api/artists/5
        public Artist Get(int id)
        {
            LibraryEntities context = new LibraryEntities();

            Artist artist = context.Artists.Find(id);
            return artist;
        }

        // POST api/artists
        public void Post([FromBody]Artist artist)
        {
            LibraryEntities context = new LibraryEntities();

            context.Artists.Add(artist);
            context.SaveChanges();
        }

        // PUT api/artists/5
        public void Put(int id, [FromBody]Artist newArtist)
        {
            LibraryEntities context = new LibraryEntities();

            Artist artist = context.Artists.Find(id);

            int artistOriginalId = artist.ArtistId;
            Utilities.CopyPropertyValues(newArtist, artist);
            artist.ArtistId = artistOriginalId;

            context.SaveChanges();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            LibraryEntities context = new LibraryEntities();

            Artist artist = context.Artists.Find(id);
            context.Artists.Remove(artist);

            context.SaveChanges();
        }
    }
}
