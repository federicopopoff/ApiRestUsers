using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
    }
}