using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace EntrepreneurBuddy.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options) {

        }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<MentoringRequest> MentoringRequests { get; set; }
        public DbSet<Entrepenuer> Entrepenuers { get; set; }

        
    }
}
