using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirlineBookingApi.Models
{
    public class Bookings
    {
        [Key]
        public int BookingId { get; set; }
        
        public int UserInfoId { get; set; }
               
        public string DepartureLocation { get; set; }
         
        public string ArrivalLocation { get; set; }
    }
}