using AirlineBookingApi.Models;
using AirlineBookingApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace AirlineBookingApi.Controllers
{
    public class AirlineBookingController : ApiController
    {
        private IAirLineService _service;
        public AirlineBookingController(IAirLineService service)
        {
            _service = service;
        }

        // GET: api/employees
        [HttpGet]
        public IEnumerable<Locations> GetLocations()
        {
            return _service.GetLocations();
        }

        [Route("api/AirlineBooking/Register")]
        [HttpPost]
        public IHttpActionResult Register([FromBody] UserInfo user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var _user = _service.GetUser(user.Email);

            if (_user == null)
            {
                _service.Register(user);
                _service.SaveChanges();
                return Ok("user successfully registered");
            }
            else
            {
                return Conflict();
            }

        }

        [Route("api/AirlineBooking/Login")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Login(Login user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var _user = _service.GetUser(user.Email);

            if (_user != null)
            {
                if (user.password == _user.Password)
                {
                  
                    var token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                    TokenData tData = new Models.TokenData
                    {
                        Email = _user.Email,
                        Token = token
                    }; 
                    _service.AddToken(tData);
                    _service.SaveChanges();
                    string msg = "You are successfully logges in Your token is:" + token;
                    return Ok(msg+ "the url for the other methods will be : api/AirlineBooking/MethodName/YourToken");
                }
                else
                {
                    return Conflict();
                }
            }
            else
            {
                return Conflict();
            }

        }

        [Route("api/AirlineBooking/Booking/{token}")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Booking([FromBody]UserLocation order,[FromUri]string token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var tData = _service.GetTokenData(token);
            if (tData == null)
            {
                return Conflict();
            }
            else
            {
                var user = _service.GetUser(tData.Email);

                Bookings order1 = new Bookings
                {
                    ArrivalLocation = order.ArrivalLocation,
                    DepartureLocation = order.DepartureLocation,
                    UserInfoId = user.UserInfoId
                }
                ;

                _service.Booking(order1);
                _service.SaveChanges();
                return Ok("Order successfully booked");
            }
        }

        [Route("api/AirlineBooking/Logout/{token}")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Logout(string token)
        {
           var tData = _service.GetTokenData(token);

            if (tData != null)
            {
                _service.DeleteToken(tData.Email);
                _service.SaveChanges();
                return Ok("Successfully logged out");
            }
            else
            {
                return Conflict();
            }
        }


        /* the updated password must be sent with the url*/
        [Route("api/AirlineBooking/UpdateProfile/{token}/{pass}")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult UpdateProfile([FromUri]string pass, [FromUri]string token)
        {
            var tData = _service.GetTokenData(token);
            if (tData != null)
            {
                var usr = _service.GetUser(tData.Email);
                usr.Password = pass;
                usr.ConfirmPassword = pass;
                _service.UpdateUser(usr);
                if (_service.SaveChanges())
                {
                    return Ok("password changed successfully");
                }
                return BadRequest("Internal Error");
            }
            else
            {
                return Conflict();
            }

        }
   }
}
