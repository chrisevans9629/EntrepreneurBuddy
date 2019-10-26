using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntrepreneurBuddy.Models;
using Microsoft.AspNetCore.Authorization;

namespace EntrepreneurBuddy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntrepenuersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EntrepenuersController(AppDbContext context)
        {
            _context = context;
        }

       [HttpGet]
        public async Task<ActionResult<IEnumerable<Entreprenuer>>> GetEntrepenuers()
        {
            return await _context.Entrepenuers.ToListAsync();
        }
        [HttpGet("Current")]
        public async Task<ActionResult<Entreprenuer>> GetSignedInEntreprenuer()
        {
            var email = User.Identity.Name;

            var entreprenuer = _context.Entrepenuers.FirstOrDefault(p => p.Email == email);
            return Ok(entreprenuer);
        }

        [HttpPost("Join/{requestId}")]
        public async Task<ActionResult<MentoringRequestDto>> JoinMentoringRequest(int requestId)
        {
            var email = User.Identity.Name;
            var entreprenuer = _context.Entrepenuers.FirstOrDefault(p => p.Email == email);
            if (entreprenuer == null)
            {
                return BadRequest("Could not find entreprenuer");
            }
            var request = _context.MentoringRequests.FirstOrDefault(p => p.Id == requestId);
            if (request == null)
            {
                return BadRequest("could not find mentoring Request");
            }
            if (_context.EntrepreneurMentoringRequests.Any(p => p.MentoringRequestId == requestId && p.EntreprenuerId == entreprenuer.Id))
            {
                return BadRequest("You already have joined this request");
            }
            else
            {
                var entreRequest = new EntrepreneurMentoringRequest()
                {
                    EntreprenuerId = entreprenuer.Id,
                    MentoringRequestId = requestId,
                };
                var requestDto = new MentoringRequestDto()
                {
                    Request = request,
                    AttendCount = _context.EntrepreneurMentoringRequests.Count(r => r.MentoringRequestId == request.Id)
                };
                _context.Add(entreRequest);
                await _context.SaveChangesAsync();
                return Ok(requestDto);
            }
        }

    }
}
