﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntrepreneurBuddy.Models
{
    public class Entrepenuer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public int MentoringRequestId { get; set; }

    }
}
