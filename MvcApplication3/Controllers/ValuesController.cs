using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MvcApplication3.Controllers
{

    public class ValuesController : ApiController
    {
        // GET api/values
        public HttpResponseMessage Get()
        {
            var value1 = "hello I'm GET";
            return Request.CreateResponse(HttpStatusCode.OK, value1);
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]string value)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "hello I'm POST"+value);
        }

        // PUT api/values/5


        public HttpResponseMessage Put([FromBody]string value)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "hello I'm PUT" + value);
        }

        // DELETE api/values/5

        public HttpResponseMessage Delete([FromBody]string value)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "hello I'm DELETE" + value);
        }
    }
}