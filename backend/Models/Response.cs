using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Response
    {
         public int Status{get; set;}

         public string StatusMessage{get; set;}

        public int StatusCode{get; set;}

         public Registration Registration {get; set;}

         public List<Registration> ListRegistration {get; set;}

         public List<Article> ListArticle {get; set;}

         public List<News> ListNews{get; set;}

         public List<Event> ListEvent{get; set;}
    }
}