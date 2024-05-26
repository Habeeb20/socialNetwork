using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using backend.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace backend.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class NewsController(IConfiguration configuration) : ControllerBase
    {
        private readonly IConfiguration _configuration = configuration;

        [HttpPost]
        [Route("AddNews")]

        public Response AddNews(News news)
        {
            Response response = new();
            SqlConnection connection = new(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new();
            response = dal.AddNews(news, connection);
            return response;
        }
      

    }
}