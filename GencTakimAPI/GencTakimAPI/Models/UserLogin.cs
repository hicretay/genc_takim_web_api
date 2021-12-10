using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GencTakimAPI.Models
{
    public class userLogin  
    {
        public string UserEmail { get; set; }   
        public string UserPassword { get; set; }
    }
    public class saveUser
    {
        public int? Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserTelephone { get; set; }
        public int? Birthdate { get; set; } 
    }
}
