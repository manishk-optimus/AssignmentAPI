using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirlineBookingApi.Models;
using AirlineBookingApi.Repositories;

namespace AirlineBookingApi.UOW
{
    public class UnitOfWork : IUnitOfWork
    {

        private AirlineBookingContext context;

        public UnitOfWork(AirlineBookingContext _context)
        {
            this.context = _context;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        private AirLineBookingRepository<Bookings> _booking;
        public AirLineBookingRepository<Bookings> BookingsRepo()
        {
            if (_booking == null)
            {
                _booking = new AirLineBookingRepository<Bookings>(context);
            }
            return _booking;
        }

        private AirLineBookingRepository<Locations> _location; 

        public AirLineBookingRepository<Locations> LocationRepo()
        {
            if (_location == null)
            {
                _location = new AirLineBookingRepository<Locations>(context);
            }
            return _location;
        }

        private AirLineBookingRepository<UserInfo> _user;
        public AirLineBookingRepository<UserInfo> UserRepo()
        {
            if (_user == null)
            {
                _user = new AirLineBookingRepository<UserInfo>(context);
            }
            return _user;
        }

        private AirLineBookingRepository<TokenData> _token;
        public AirLineBookingRepository<TokenData> TokenRepo()
        {
            if (_token == null)
            {
                _token = new AirLineBookingRepository<TokenData>(context);
            }
            return _token;
        }
    }
}