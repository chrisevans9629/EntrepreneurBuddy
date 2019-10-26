using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntrepreneurBuddy.Models
{
    public class Mentor
    {
        public Mentor()
        {
            SkillsList = new List<string>();
        }
        public string AppUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Skills { get; set; }

        public void SkillsChanged()
        {
            if (Skills != null)
            {
                SkillsList = new List<string>(Skills.Split(',').Select(p=>p.Trim()));
            }
        }

        public string Zip { get; set; }
        public string ImageUrl { get; set; }
        public string Bio { get; set; }
        public string Position { get; set; }
        public int Rating { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public string LinkedInUrl { get; set; }

        public IList<string> SkillsList { get; set; }
    }
}
