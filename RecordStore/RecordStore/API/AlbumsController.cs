using RecordStore.Models;
using RecordStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RecordStore.API
{
    public class AlbumsController : ApiController
    {
        public IAlbumServices _service;

        public AlbumsController(IAlbumServices service)
        {
            _service = service;
        }

        // GET: api/Albums
        public IEnumerable<Album> Get()
        {
            return _service.List();
        }

        // GET: api/Albums/5
        public Album Get(int id)
        {
            return _service.FindAlbum(id);
        }

        // POST: api/Albums
        public HttpResponseMessage Post(Album album)
        {
            if (ModelState.IsValid) {
                if (album.Id == 0) { 
                _service.Create(album);

                // Return a status code. When you return success, you also pass back the
                // newly updated album.
                return Request.CreateResponse(HttpStatusCode.Created, album);
                }

                else {
                    _service.Edit(album.Id, album);
                    return Request.CreateResponse(HttpStatusCode.OK, album);
                }
            }

            // If things go wrong, pass back a server-side validation error that will be displayed
            // on the client side.
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        // PUT: api/Albums/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Albums/5
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
