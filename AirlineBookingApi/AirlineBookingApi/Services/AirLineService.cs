using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirlineBookingApi.Models;
using AirlineBookingApi.UOW;

namespace AirlineBookingApi.Services
{
    public class AirLineService : IAirLineService
    {
        IUnitOfWork _unitOfWork;
        public AirLineService(IUnitOfWork work)
        {
            _unitOfWork = work;
        }

        public void Booking(Bookings booking)
        {
            _unitOfWork.BookingsRepo().Add(booking);
        }

        public IEnumerable<Locations> GetLocations()
        {
           var locations = _unitOfWork.LocationRepo().GetList();
            return locations;
        }

        public void login()
        {
            throw new NotImplementedException();
        }

        public void Register(UserInfo user)
        {
            _unitOfWork.UserRepo().Add(user);
        }

        public UserInfo GetUser(string email)
        {
            var user = _unitOfWork.UserRepo().GetUserInfo(email);
            return user;
        }

        public void AddToken(TokenData token)
        {
            _unitOfWork.TokenRepo().Add(token);
        }

        public void DeleteToken(string email)
        {
            _unitOfWork.TokenRepo().DeleteToken(email);
          
        }

        public TokenData GetTokenData(string token)
        {
           return  _unitOfWork.TokenRepo().GetTokenData(token);
        }

        public void UpdateUser(UserInfo user)
        {
            _unitOfWork.UserRepo().Edit(user);
        }

        public bool  SaveChanges()
        {
            try
            {
                _unitOfWork.Commit();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}