using AirlineBookingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineBookingApi.Repositories
{
    public class AirLineBookingRepository<T>:GenericRepository<T>,IAirlineBookingRepository<T> where T:class
    {
        AirlineBookingContext Db;

        public AirLineBookingRepository(AirlineBookingContext context) : base(context)
        {
            Db = context;
        }

        public UserInfo GetUserInfo(string email)
        {
            var user = Db.UserData.FirstOrDefault(e => e.Email == email);
            return user;
        }

        public void DeleteToken(string email)
        {
            var token = Db.TokenData.FirstOrDefault(e => e.Email == email);
                Db.TokenData.Remove(token);
            Db.SaveChanges();
          
        }
        public TokenData GetTokenData(string token)
        {
            return  Db.TokenData.FirstOrDefault(e => e.Token == token);
      
        }




    }
}