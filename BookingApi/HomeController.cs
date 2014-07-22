using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Ploeh.Samples.BookingApi
{
    public class HomeController : ApiController
    {
        public IHttpActionResult Get()
        {
            return this.Ok();
        }
    }
}