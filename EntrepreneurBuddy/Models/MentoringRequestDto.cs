using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntrepreneurBuddy.Models
{
    public class MentoringRequestDto
    {
        public MentoringRequest Request { get; set; }
        public int AttendCount { get; set; }
        public IEnumerable<string> Emails { get; set; } 
    }
}
