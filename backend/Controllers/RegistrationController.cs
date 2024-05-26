using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController(IConfiguration configuration) : ControllerBase
    {
        private readonly IConfiguration _configuration = configuration;

        [HttpPost]
        [Route("Registration")]

        public Response Registration(Registration registration)
        {
            Response response = new();
            SqlConnection connection = new(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new();
            response = dal.Registration(registration, connection);
            return response;
        }

        [HttpPost]
        [Route("Login")]

        public Response Login (Registration registration)
        {
            Response response = new();
            SqlConnection connection = new(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new();
            response = dal.Login(registration, connection);
            return response;
        }

        [HttpPost]
        [Route("userApproval")]

        public Response UserApproval(Registration registration)
        {
            Response response = new();
            SqlConnection connection = new(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new ();
            response = dal.UserApproval(registration, connection);

            return response;

        }

       



    }

   
}