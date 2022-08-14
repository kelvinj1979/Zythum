using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Areas.Users.Models;
using Zythum.Areas.Beers.Models;
using Zythum.Areas.Brewery.Models;
using Zythum.Models;

namespace SalesSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TUsers> TUsers { get; set; }
        public DbSet<TBrewery> TBrewery { get; set; }
        public DbSet<TReports_brewery> TReports_brewery { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<TBeers> TBeers { get; set; }
        public DbSet<TReports_beer> TReports_beer { get; set; }
    }
}
