using AirlineBookingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingApi.Services
{
    public interface IAirLineService
    {
        void Register(UserInfo user);
        void login();
        IEnumerable<Locations> GetLocations();
        void Booking(Bookings booking);
        UserInfo GetUser(string email);
        void UpdateUser(UserInfo pass);
        bool SaveChanges();
        void AddToken(TokenData token);
        TokenData GetTokenData(string token);
        void DeleteToken(string email);
    }
}
