using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace TestUpload.API
{
    public class UploadController : ApiController
    {

        // POST: api/Upload
        public HttpResponseMessage Post()
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0) {
                foreach (string file in httpRequest.Files) {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/uploads/" + postedFile.FileName);
                    postedFile.SaveAs(filePath);
                    // NOTE: To store in memory use postedFile.InputStream
                }

                return Request.CreateResponse(HttpStatusCode.Created);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }



    }
}
