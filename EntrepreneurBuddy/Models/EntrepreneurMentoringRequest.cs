using System.Collections.Generic;

namespace EntrepreneurBuddy.Models
{
    public class EntrepreneurMentoringRequest
    {
        public int Id { get; set; }
        public int EntreprenuerId { get; set; }
        public int MentoringRequestId { get; set; }
        public Entreprenuer  Entreprenuer { get; set; }
        public MentoringRequest MentoringRequest { get; set; }
    }
}
