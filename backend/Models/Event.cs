using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Event
    {
        
        public int Id{get; set;}

        public string Title {get; set;}

        public string Email {get; set;}

        public string Content {get; set;}
   

        public int IsActive{get; set;}

    }
}