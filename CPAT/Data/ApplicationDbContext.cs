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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MajorCourse>().HasKey(sc => new { sc.CoursesId, sc.MajorRequirementsId });
            modelBuilder.Entity<CourseTerm>().HasKey(sc => new { sc.CoursesId, sc.AcademicTermsId });

        }

        public DbSet<Courses> Courses { get; set; }

        public DbSet<AcademicTerms> AcademicTerms { get; set; }

        public DbSet<MajorRequirements> MajorRequirements { get; set; }

        public DbSet<Students> Students { get; set; }

        public DbSet<StudentPlans> StudentPlans { get; set; }

        public DbSet<CourseTerm> CourseTerm { get; set; }

        public DbSet<MajorCourse> MajorCourse { get; set; }

        //public DbSet<CPAT.Models.ViewModels.StudentPlanViewModel> StudentPlanViewModel { get; set; }

        //public DbSet<CoursesSelectedForTerm> CoursesSelectedForTerm { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
