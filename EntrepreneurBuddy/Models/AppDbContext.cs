using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntrepreneurBuddy.Areas.Identity.Data;
using EntrepreneurBuddy.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace EntrepreneurBuddy
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<MentoringRequest> MentoringRequests { get; set; }
        public DbSet<Entrepenuer> Entrepenuers { get; set; }
        public DbSet<EntrepreneurMentoringRequest> EntrepreneurMentoringRequests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MentoringRequest>(p => p.HasOne<Mentor>().WithMany().HasForeignKey(r => r.MentorId));
            modelBuilder.Entity<Entrepenuer>(p =>
            {
                p.HasOne<AppUser>().WithMany().HasForeignKey(r => r.AppUserId);
            });
            modelBuilder.Entity<Mentor>(p =>
            {
                p.HasOne<AppUser>().WithMany().HasForeignKey(r=>r.AppUserId);

            });
            base.OnModelCreating(modelBuilder);

        }
    }
}
