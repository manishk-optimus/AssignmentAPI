﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirlineBookingApi.Models
{
    public class Login
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string password { get; set; }
    }
}