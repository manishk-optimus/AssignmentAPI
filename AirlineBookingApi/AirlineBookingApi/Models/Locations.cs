using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirlineBookingApi.Models
{
    public class Locations
    {
        [Key]
        public int LocationId { get; set; }

        public string Name { get; set; } 
    }
}