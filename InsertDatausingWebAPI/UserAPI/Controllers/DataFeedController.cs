using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserAPI.Models;

namespace UserAPI.Controllers
{
    public class DataFeedController : ApiController
    {
        static UserRepository repository = new UserRepository();

        [AllowAnonymous]
        [HttpPost]        
        [Route("api/DataFeed/PostRegisterUsers")]
        public string PostRegisterUsers(User User)
        {
            //calling UserRepository Class Method and storing Repsonse   
            var response = repository.RegisterUsers(User);
            return response;

        }
    }
}
