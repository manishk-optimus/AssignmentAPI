using AirlineBookingApi.Models;
using AirlineBookingApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingApi.UOW
{
    public interface IUnitOfWork
    {
        void Commit();
        AirLineBookingRepository<Bookings> BookingsRepo();
        AirLineBookingRepository<Locations> LocationRepo();
        AirLineBookingRepository<UserInfo> UserRepo();
        AirLineBookingRepository<TokenData> TokenRepo();
    }
}
