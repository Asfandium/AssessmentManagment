using AssessmentMangement.Entites.Employees;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AssessmentMangement.Entites.ClassAssessments;

namespace AssessmentMangement.EntitesBuilder.ClassAssessments
{
    public class ClassAssessmentBuilder : IEntityTypeConfiguration<ClassAssessment>
    {
        public void Configure(EntityTypeBuilder<ClassAssessment> builder)
        {
            builder.ToTable("ClassAssessment");
        }
    }
}