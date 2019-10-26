using System;
using EntrepreneurBuddy.Areas.Identity.Data;
using EntrepreneurBuddy.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(EntrepreneurBuddy.Areas.Identity.IdentityHostingStartup))]
namespace EntrepreneurBuddy.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DefaultConnection")));

                services.AddDefaultIdentity<AppUser>()
                    .AddEntityFrameworkStores<AppDbContext>();
            });
        }
    }
}