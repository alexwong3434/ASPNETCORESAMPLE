using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCoreSample4.Models;

namespace NetCoreSample4.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<NetCoreSample4.Models.Movie> Movie { get; set; }
        public DbSet<NetCoreSample4.Models.TestIItem> TestIItem { get; set; }
    }
}
