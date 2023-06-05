using Microsoft.EntityFrameworkCore;
using AssessmentMangement.Entites;
using AssessmentMangement.Entites.Employees;
using AssessmentMangement.EntitesBuilder;
using AssessmentMangement.EntitesBuilder.Employees;
using AssessmentMangement.EntitesBuilder.ClassAssessments;
using AssessmentMangement.Entites.ClassAssessments;
using AssessmentMangement.Entites.ClassStudentAssessments;
using AssessmentMangement.EntitesBuilder.ClassStudentAssessments;
using AssessmentMangement.Entites.ClassStudentAssessmentResources;
using AssessmentMangement.EntitesBuilder.ClassStudentAssessmentResourcess;

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
        
        public virtual DbSet<ClassAssessment> ClassAssessments { get; set; }

        public virtual DbSet<ClassStudentAssessment> ClassStudentAssessments { get; set; }

        public virtual DbSet<ClassStudentAssessmentResource> ClassStudentAssessmentResources { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(Configuration.GetSection("ConnectionStrings:sqlconnstr").Value);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserBuilder());

            modelBuilder.ApplyConfiguration(new EmployeeBuilder());

            modelBuilder.ApplyConfiguration(new ClassAssessmentBuilder());

            modelBuilder.ApplyConfiguration(new ClassStudentAssessmentBuilder());
           
            modelBuilder.ApplyConfiguration(new ClassStudentAssessmentResourceBuilder());


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}