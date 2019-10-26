using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntrepreneurBuddy.Models;
using Microsoft.EntityFrameworkCore;
namespace EntrepreneurBuddy
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options) {

        }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<MentoringRequest> MentoringRequests { get; set; }
        public DbSet<Entrepenuer> Entrepenuers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MentoringRequest>(p => p.HasOne<Mentor>().WithMany().HasForeignKey(r=>r.MentorId));
            modelBuilder.Entity<Entrepenuer>(p => p.HasOne<MentoringRequest>().WithMany().HasForeignKey(r=>r.MentoringRequestId));


        }
    }
}
