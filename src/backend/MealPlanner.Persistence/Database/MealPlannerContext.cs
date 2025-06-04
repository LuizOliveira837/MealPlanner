using MealPlanner.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Persistence.Database
{
    public class MealPlannerContext : DbContext
    {

        public MealPlannerContext(DbContextOptions<MealPlannerContext> options) : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Food> Foods { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          

            modelBuilder.Entity<Patient>()
                              .HasKey(p => p.Id);



          

        }
    }
}
