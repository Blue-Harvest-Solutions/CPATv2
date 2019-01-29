using System;
using System.Collections.Generic;
using System.Text;
using CPAT.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CPAT.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Courses> Courses { get; set; }

        public DbSet<AcademicTerms> AcademicTerms { get; set; }

        public DbSet<MajorRequirements> MajorRequirements { get; set; }

        public DbSet<Students> Students { get; set; }

        public DbSet<StudentPlans> StudentPlans { get; set; }
    }
}
