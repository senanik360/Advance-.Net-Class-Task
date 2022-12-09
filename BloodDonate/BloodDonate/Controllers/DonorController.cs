using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BloodDonate.Controllers
{
    public class DonorController : ApiController
    {
        [Route("api/donor")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = DonorService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/donor/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = DonorService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/donor/add")]
        [HttpPost]
        public HttpResponseMessage Post(DonorDTO donor)
        {
            var resp = DonorService.Add(donor);
            if (resp != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = resp });

            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

    }
}
