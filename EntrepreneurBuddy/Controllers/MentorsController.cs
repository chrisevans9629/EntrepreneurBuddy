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
    public class MentorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MentorsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mentor>>> GetMentors()
        {
            var list = await _context.Mentors.OrderByDescending(p=>p.Rating).ToListAsync();
            foreach (var item in list)
            {
                item.SkillsChanged();
            }
            return list;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Mentor>> GetMentor(int id)
        {
            var mentor = await _context.Mentors.FindAsync(id);

            if (mentor == null)
            {
                return NotFound();
            }
            mentor.SkillsChanged();
            return mentor;
        }

        [HttpPost("{id}/Like")]
        public async Task<IActionResult> PutLike(int id)
        {
            var mentor = _context.Mentors.FirstOrDefault(p => p.Id == id);
            mentor.Rating++;
            mentor.SkillsChanged();
            await _context.SaveChangesAsync();
            return Ok(mentor);
        }
        
    }
}
