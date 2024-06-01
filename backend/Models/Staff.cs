using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Staff
    {
        
        public int Id{get; set;}

        public string Name {get; set;}

        public string Email {get; set;}

        public int IsActive{get; set;}


        public string Password {get; set;}
    }
}