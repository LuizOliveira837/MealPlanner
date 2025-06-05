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
        public DbSet<MealPlan> MealPlans { get; set; }
        public DbSet<MealPlanFood> MealPlanFoods { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Patient>()
                .ToTable("Patients")
                              .HasKey(p => p.Id);
          

            modelBuilder.Entity<Food>()
                .ToTable("Foods")
                              .HasKey(p => p.Id);

            modelBuilder.Entity<MealPlan>()
                .ToTable("MealPlans")
                .HasOne(mp => mp.Patient)
                .WithMany(p => p.MealPlans)
                .HasForeignKey(mp => mp.PatientId);


            modelBuilder.Entity<MealPlanFood>()
                .ToTable("MealPlanFoods")
                .HasKey(mpf => new { mpf.MealPlanId, mpf.FoodId });

            modelBuilder.Entity<MealPlanFood>()
                .HasOne(mpf => mpf.MealPlan)
                .WithMany(mp => mp.MealPlanFoods)
                .HasForeignKey(mpf => mpf.MealPlanId);

            modelBuilder.Entity<MealPlanFood>()
                .HasOne(mpf => mpf.Food);




        }
    }
}
