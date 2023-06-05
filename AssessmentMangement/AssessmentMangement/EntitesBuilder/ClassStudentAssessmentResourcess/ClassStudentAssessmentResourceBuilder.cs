using AssessmentMangement.Entites.Employees;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AssessmentMangement.Entites.ClassStudentAssessmentResources;

namespace AssessmentMangement.EntitesBuilder.ClassStudentAssessmentResourcess
{
    public class ClassStudentAssessmentResourceBuilder : IEntityTypeConfiguration<ClassStudentAssessmentResource>
    {
        public void Configure(EntityTypeBuilder<ClassStudentAssessmentResource> builder)
        {
            builder.ToTable("ClassStudentAssessmentResource");
        }
    }
}