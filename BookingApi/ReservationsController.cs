using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Ploeh.Samples.BookingApi
{
    public class ReservationsController : ApiController
    {
        private const int capacity = 10;

        public IHttpActionResult Post(ReservationRendition rendition)
        {
            DateTimeOffset requestedDate;
            if (!DateTimeOffset.TryParse(rendition.Date, out requestedDate))
                return this.BadRequest("Invalid date.");
            
            var min = requestedDate.Date;
            var max = requestedDate.Date.AddDays(1);

            using (var ctx = new ReservationsContext())
            {
                var reservedSeats = (from r in ctx.Reservations
                                     where min <= r.Date && r.Date < max
                                     select r.Quantity)
                                    .DefaultIfEmpty(0)
                                    .Sum();
                if (rendition.Quantity + reservedSeats > capacity)
                    return this.StatusCode(HttpStatusCode.Forbidden);

                ctx.Reservations.Add(new Reservation
                {
                    Date = requestedDate,
                    Name = rendition.Name,
                    Email = rendition.Email,
                    Quantity = rendition.Quantity
                });
                ctx.SaveChanges();                
            }

            return this.Ok();
        }
    }
}