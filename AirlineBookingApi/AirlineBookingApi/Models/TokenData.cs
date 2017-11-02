using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineBookingApi.Models
{
    public class TokenData
    {
        public int TokenDataId { get; set;}
        public string Email { get; set; }
        public string Token { get; set; }
    }
}