using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntrepreneurBuddy.Models
{

    public class EntrepreneurMentoringRequest
    {
        public int Id { get; set; }
        public IList<Entrepenuer>  Entrepenuers { get; set; }
        public IList<MentoringRequest> MentoringRequests { get; set; }
    }

    public class Entrepenuer
    {
        public string AppUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
    }
}
