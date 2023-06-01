﻿using Microsoft.EntityFrameworkCore;
using AssessmentMangement.Entites;
using AssessmentMangement.Entites.Employees;

using AssessmentMangement.EntitesBuilder;
using AssessmentMangement.EntitesBuilder.Employees;


namespace AssessmentMangement.DataContext
{
    public partial class  UpwardsLmsContext : DbContext
    {
        public IConfiguration Configuration { get; }
        public UpwardsLmsContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public UpwardsLmsContext(DbContextOptions<UpwardsLmsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        


        public virtual DbSet<Employee> Employees { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(Configuration.GetSection("ConnectionStrings:sqlconnstr").Value);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserBuilder());

            modelBuilder.ApplyConfiguration(new EmployeeBuilder());




            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}