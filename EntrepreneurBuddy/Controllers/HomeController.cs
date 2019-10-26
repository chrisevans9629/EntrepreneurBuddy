using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EntrepreneurBuddy.Models;
using Microsoft.AspNetCore.Authorization;

namespace EntrepreneurBuddy.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        AppDbContext _context;
public HomeController(AppDbContext context)
{
 _context = context;   
}
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Analytics()
        {
            return View();
        }
        public IActionResult MentoringRequests(int id)
       {
            var mentor = _context.Mentors.Find(id);
            return View(mentor);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
