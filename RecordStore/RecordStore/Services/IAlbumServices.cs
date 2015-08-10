using System;
namespace RecordStore.Services
{
    public interface IAlbumServices
    {
        void Create(RecordStore.Models.Album album);
        void Delete(int id);
        void Edit(int id, RecordStore.Models.Album album);
        RecordStore.Models.Album FindAlbum(int id);
        System.Collections.Generic.IList<RecordStore.Models.Album> List();
    }
}
