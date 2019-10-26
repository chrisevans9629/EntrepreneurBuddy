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

        // GET: api/Entrepenuers
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Entrepenuer>>> GetEntrepenuers()
        //{
        //    return await _context.Entrepenuers.ToListAsync();
        //}
        [HttpGet("Current")]
        public async Task<ActionResult<Entrepenuer>> GetSignedInEntreprenuer()
        {
            var email = User.Identity.Name;

            var entreprenuer = _context.Entrepenuers.First(p => p.Email == email);
            return Ok(entreprenuer);
        }



        // GET: api/Entrepenuers/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Entrepenuer>> GetEntrepenuer(int id)
        //{
        //    var entrepenuer = await _context.Entrepenuers.FindAsync(id);

        //    if (entrepenuer == null)
        //    {
        //        return NotFound();
        //    }

        //    return entrepenuer;
        //}

        [HttpPost("{id}/Join/{requestId}")]
        public async Task<IActionResult> JoinMentoringRequest(int id, int requestId)
        {
            var entreprenuer = _context.Mentors.FirstOrDefault(p => p.Id == id);
            if (entreprenuer == null)
            {
                return BadRequest("Could not find entreprenuer");
            }
            var request = _context.MentoringRequests.FirstOrDefault(p => p.Id == requestId);
            if (request == null)
            {
                return BadRequest("could not find mentoring Request");
            }
            if (_context.EntrepreneurMentoringRequests.Any(p => p.MentoringRequestId == requestId && p.EntreprenuerId == id))
            {
                return BadRequest("You already have joined this request");
            }
            else
            {
                var entreRequest = new EntrepreneurMentoringRequest()
                {
                    EntreprenuerId = id,
                    MentoringRequestId = requestId,
                };

                _context.Add(entreRequest);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }


        // PUT: api/Entrepenuers/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutEntrepenuer(int id, Entrepenuer entrepenuer)
        //{
        //    if (id != entrepenuer.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(entrepenuer).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EntrepenuerExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Entrepenuers
        //[HttpPost]
        //public async Task<ActionResult<Entrepenuer>> PostEntrepenuer(Entrepenuer entrepenuer)
        //{
        //    _context.Entrepenuers.Add(entrepenuer);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetEntrepenuer", new { id = entrepenuer.Id }, entrepenuer);
        //}

        // DELETE: api/Entrepenuers/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Entrepenuer>> DeleteEntrepenuer(int id)
        //{
        //    var entrepenuer = await _context.Entrepenuers.FindAsync(id);
        //    if (entrepenuer == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Entrepenuers.Remove(entrepenuer);
        //    await _context.SaveChangesAsync();

        //    return entrepenuer;
        //}

        private bool EntrepenuerExists(int id)
        {
            return _context.Entrepenuers.Any(e => e.Id == id);
        }
    }
}
