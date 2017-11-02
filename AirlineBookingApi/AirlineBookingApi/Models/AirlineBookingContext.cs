using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AirlineBookingApi.Models
{
    public class AirlineBookingContext:DbContext
    {
        public virtual DbSet<UserInfo> UserData { get; set; }
        public virtual DbSet<Locations> LocationData { get; set; }
        public virtual DbSet<Bookings> BookingData { get; set; }
        public virtual DbSet<TokenData> TokenData { get; set; }

        public void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<AirlineBookingContext>(null);
            //base.OnModelCreating(modelBuilder);

        }
    }
}