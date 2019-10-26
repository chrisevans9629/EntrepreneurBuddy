using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntrepreneurBuddy.Models
{
    public class MentoringRequest
    {
        public string Topic { get; set; }
        public DateTime DateCreated { get; set; }
        public int Id { get; set; }
        public int MentorId { get; set; }

    }
}
