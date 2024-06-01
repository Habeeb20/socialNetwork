
using backend.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController(IConfiguration configuration) : ControllerBase
    {
        private readonly IConfiguration _configuration = configuration;

                
            [HttpPost]
            [Route("AddArticle")]

            public Response AddArticle(Article article)
            {
                Response response = new();
                SqlConnection connection = new(_configuration.GetConnectionString("SNCon").ToString());
                Dal dal = new();
                response = dal.AddArticle(article, connection);

                return response;
            }

            [HttpGet]
            [Route("ArticleList")]

            public Response ArticleList(Article article)
            {
                Response response = new();
                SqlConnection connection = new(_configuration.GetConnectionString("SNCon").ToString());
                Dal dal = new();
                response = dal.ArticleList(article, connection);

                return response;
            }

             public Response ArticleApproval(Article article)
            {
                Response response = new();
                SqlConnection connection = new(_configuration.GetConnectionString("SNCon").ToString());
                Dal dal = new ();
                response = dal.ArticleApproval(article, connection);

                return response;

            }

            

    }






}