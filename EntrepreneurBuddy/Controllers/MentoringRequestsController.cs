using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntrepreneurBuddy.Models;

namespace EntrepreneurBuddy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentoringRequestsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MentoringRequestsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("{mentorId}")]
        public async Task<ActionResult<IEnumerable<MentoringRequestDto>>> GetMentoringRequests(int mentorId)
        {
            var email = User.Identity.Name;
            var isMentor = _context.Mentors.Any(p => p.Email == email && p.Id == mentorId);
            return await _context.MentoringRequests.OrderBy(p=>p.DateCreated).Where(p=>p.MentorId == mentorId).Select(p=> new MentoringRequestDto() 
            {
                Request =p, 
                AttendCount = _context.EntrepreneurMentoringRequests.Count(r=>r.MentoringRequestId == p.Id),
                Emails = isMentor ? _context.EntrepreneurMentoringRequests.Where(r=>r.MentoringRequestId == p.Id).Select(r=>r.Entreprenuer.Email) : null
            }).ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<MentoringRequestDto>> PostMentoringRequest(MentoringRequest mentoringRequest)
        {
            var email = User.Identity.Name;
            var entreprenuer = _context.Entrepenuers.FirstOrDefault(p => p.Email == email);
            if (entreprenuer == null)
            {
                return BadRequest("Could not find entreprenuer");
            }
            _context.MentoringRequests.Add(mentoringRequest);

            var entreRequest = new EntrepreneurMentoringRequest()
            {
                EntreprenuerId = entreprenuer.Id,
                MentoringRequest = mentoringRequest,
            };
            _context.EntrepreneurMentoringRequests.Add(entreRequest);

            await _context.SaveChangesAsync();
            var request = new MentoringRequestDto()
            {
                Request = mentoringRequest,
                AttendCount = _context.EntrepreneurMentoringRequests.Count(r => r.MentoringRequestId == mentoringRequest.Id)
            };
            return Ok(request);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<MentoringRequest>> DeleteMentoringRequest(int id)
        {
            var mentoringRequest = await _context.MentoringRequests.FindAsync(id);
            if (mentoringRequest == null)
            {
                return NotFound();
            }

            _context.MentoringRequests.Remove(mentoringRequest);
            await _context.SaveChangesAsync();

            return mentoringRequest;
        }

    }
}
