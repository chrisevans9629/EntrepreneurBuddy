using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntrepreneurBuddy.Models
{
    public class Mentor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Skills { get; set; }
        public string Zip { get; set; }
        public string ImageUrl { get; set; }
        public string Bio { get; set; }
        public string Position { get; set; }
        public int Rating { get; set; }
        public int Id { get; set; }
    }
}
