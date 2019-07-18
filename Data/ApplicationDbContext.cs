using System;
using System.Collections.Generic;
using System.Text;
using CampplaceTest1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CampplaceTest1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CampplaceTest1.Models.Camp> Camp { get; set; }
        public DbSet<CampplaceTest1.Models.Comment> Comment { get; set; }
    }
}
