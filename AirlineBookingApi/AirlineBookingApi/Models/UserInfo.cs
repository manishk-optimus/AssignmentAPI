using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirlineBookingApi.Models
{
    public class UserInfo
    {
        public int UserInfoId { get; set;}

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set;}

        [Required]
        [Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}