using CoderCamps;
using RecordStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecordStore.Services
{
    public class AlbumServices : RecordStore.Services.IAlbumServices 
    {
        private IGenericRepository _repo;

        public AlbumServices(IGenericRepository repo)
        {
            _repo = repo;
        }

        public IList<Album> List()
        {
            return _repo.Query<Album>().ToList();
        }

        public Album FindAlbum(int id)
        {
            return _repo.Query<Album>().Where(a => a.Id == id).FirstOrDefault();
        }

        public void Create (Album album)
        {
            _repo.Add<Album>(album);
            _repo.SaveChanges();
                
        }

        public void Edit(int id, Album album)
        {
            var original = this.FindAlbum(id);
            original.Artist = album.Artist;
            original.Genre = album.Genre;
            original.Title = album.Title;
            _repo.SaveChanges();
        }

        public void Delete(int id)
        {
            _repo.Delete<Album>(id);
            _repo.SaveChanges();
        }


    }
}