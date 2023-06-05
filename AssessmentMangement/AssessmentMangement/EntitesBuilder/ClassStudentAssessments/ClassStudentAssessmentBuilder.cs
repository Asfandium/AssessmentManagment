using AssessmentMangement.Entites.Employees;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AssessmentMangement.Entites.ClassStudentAssessments;

namespace AssessmentMangement.EntitesBuilder.ClassStudentAssessments
{
    public class ClassStudentAssessmentBuilder : IEntityTypeConfiguration<ClassStudentAssessment>
    {
        public void Configure(EntityTypeBuilder<ClassStudentAssessment> builder)
        {
            builder.ToTable("ClassStudentAssessment");
        }
    }
}