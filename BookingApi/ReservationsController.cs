using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Ploeh.Samples.BookingApi
{
    public class ReservationsController : ApiController
    {
        public IHttpActionResult Post(ReservationRendition rendition)
        {
            return this.Ok();
        }
    }
}