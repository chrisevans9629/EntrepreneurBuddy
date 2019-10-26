using System.Collections.Generic;

namespace EntrepreneurBuddy.Models
{
    public class EntrepreneurMentoringRequest
    {
        public int Id { get; set; }
        public int EntreprenuerId { get; set; }
        public int MentoringRequestId { get; set; }
        public IList<Entrepenuer>  Entrepenuers { get; set; }
        public IList<MentoringRequest> MentoringRequests { get; set; }
    }
}
