using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using backend.Models;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;


namespace backend.Controllers
{
    public class Dal
    {
        public Response Registration(Registration registration, SqlConnection connection)
        {
            Response response = new();
            SqlCommand cmd = new("insert into Registration(Name, Email, Password, PhoneNo, IsActive, IsApproved) VALUES('" + registration.Name + "', '" + registration.Email + "', '" + registration.Password + "', '" + registration.PhoneNo + "', 1, 0)", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "successful";
            }else 
            {
                response.StatusCode = 100;
                response.StatusMessage = "failed";

            }
            return response;
        }

        public Response Login(Registration registration, SqlConnection connection)
        {
            SqlDataAdapter Da= new("select from registration where = '" + registration.Email + "' AND PASSWORD  '"+registration.Password+"' ", connection);
            DataTable dt = new ();
            Da.Fill(dt);
            Response response = new();
            if(dt.Rows.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Login successful";
                Registration reg = new()
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                    Name = Convert.ToString(dt.Rows[0]["Name"]),
                    Email = Convert.ToString(dt.Rows[0]["Email"])
                };
                response.Registration = reg;
            } else
            {
                response.StatusCode = 100;
                response.StatusMessage = "login failed";
                response.Registration = null;

            }
            return response;
        }

        public Response UserApproval(Registration registration, SqlConnection connection)
        {
            Response response = new();
            SqlCommand cmd = new("Update registration set isApproved = 1 Where Id = " + registration.Id + "And isActive + 1",connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i> 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "successful";
            }
            else 
            {
                response.StatusCode = 100;
                response.StatusMessage = "failed";
            }
            
            return response;

        }

        public Response AddNews(News news, SqlConnection connection)
        {
            Response response = new();
            SqlCommand cmd = new("Insert into News(Title, Content, Email,IsActive,CreatedOn) Values("+news.Title + "," + news.Content + ","+ news.Email + ",'1', GetDATE())", connection); 
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0)
            {
                response.StatusCode= 200;
                response.StatusMessage ="news created";

            }
            else 
            {
                response.StatusCode= 100;
                response.StatusMessage = "it failed";
            }
            return response;
        }

        public Response NewsList(SqlConnection connection)

        {
            Response response = new ();
            SqlDataAdapter da = new("SELECT FROM NEWS isActive = 1", connection);
            DataTable dt = new();
            da.Fill(dt);
            List<News>IsNews = new();
            if(dt.Rows.Count> 0)
            {
                for(int i= 0; i < dt.Rows.Count; i++)
                {
                    News news = new();
                    news.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                    news.Title = Convert.ToString(dt.Rows[i]["title"]);
                    news.Email = Convert.ToString(dt.Rows[i]["email"]);
                    news.Content = Convert.ToString(dt.Rows[i]["Content"]);
                    news.IsActive = Convert.ToInt32(dt.Rows[i]["isActive"]);
                    news.CreatedOn = Convert.ToString(dt.Rows[i]["createdOn"]);
                    IsNews.Add(news);
                }
                if(IsNews.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "successful";
                    response.ListNews = IsNews;
                }
                else 
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "failed";
                    response.ListNews = IsNews;
                }

            }
            return response;
            
        }
        
        public Response AddArticle( Article article, SqlConnection connection)
        {
            Response response = new();
            SqlCommand cmd = new("Insert into Article(Title, Content, Email,IsActive,isApproved) Values("+article.Title + "," + article.Content + ","+ article.Email + "," + article.Image +",'1', GetDATE())", connection); 
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0)
            {
                response.StatusCode= 200;
                response.StatusMessage ="Article  created";

            }
            else 
            {
                response.StatusCode= 100;
                response.StatusMessage = "it failed";
            }
            return response;
        }

        
        public Response ArticleList(Article article,SqlConnection connection)

        {
            Response response = new ();
            SqlDataAdapter da = null;
            if(article.type == "user")
            {
                new SqlDataAdapter("SELECT FROM Article were Email = 1" +article.Email+ "", connection);

            }
            if(article.type == "page")
            {
                new SqlDataAdapter("SELECT FROM NEWS isActive = 1", connection);

            }
           
            DataTable dt = new();
            da.Fill(dt);
            List<Article>IsArticle = new();
            if(dt.Rows.Count> 0)
            {
                for(int i= 0; i < dt.Rows.Count; i++)
                {
                    Article art = new();
                    art.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                    art.Title = Convert.ToString(dt.Rows[i]["title"]);
                    art.Email = Convert.ToString(dt.Rows[i]["email"]);
                    art.Content = Convert.ToString(dt.Rows[i]["Content"]);
                    art.Image = Convert.ToString(dt.Rows[i]["image"]);
                    art.IsApproved = Convert.ToInt32(dt.Rows[i]["isApproved"]);
                    IsArticle.Add(art);
                }
                if(IsArticle.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "successful";
                    response.ListArticle = null;
                }
                else 
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "failed";
                    response.ListArticle = null;
                }

            }
            return response;
            
        }
        
        public Response ArticleApproval(Article article, SqlConnection connection)
        {
            Response response = new();
            SqlCommand cmd = new("Update registration set isApproved = 1 Where Id = " + article.Id + "And isActive + 1",connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i> 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "successful";
            }
            else 
            {
                response.StatusCode = 100;
                response.StatusMessage = "failed";
            }
            
            return response;

        }

        public Response StaffRegistration(Staff staff, SqlConnection connection)
        {
            Response response = new();
            SqlCommand cmd = new("insert into Registration(Name, Email, Password, PhoneNo, IsActive) VALUES('" + staff.Name + "', '" + staff.Email + "', '" + staff.Password + "', '" +  "', 1)", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "successful";
            }else 
            {
                response.StatusCode = 100;
                response.StatusMessage = "failed";

            }
            return response;
        }




    }
}