namespace Ploeh.Samples.BookingApi
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ReservationsContext : DbContext
    {
        public ReservationsContext()
            : base("name=ReservationsModel")
        {
        }

        public virtual DbSet<Reservation> Reservations { get; set; }
    }
}
