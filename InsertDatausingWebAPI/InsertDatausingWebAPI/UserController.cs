using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace InsertDatausingWebAPI
{
    public class UserController : ApiController
    {
        
        //creating the object of UserRepository class  
        static UserRepository repository = new UserRepository();

        [AllowAnonymous]
        [System.Web.Http.HttpGet]
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [Route("User")]
        public string PostRegisterUsers(User User)
        {
            //calling UserRepository Class Method and storing Repsonse   
            var response = repository.RegisterUsers(User);
            return response;

        }

    }
}
        