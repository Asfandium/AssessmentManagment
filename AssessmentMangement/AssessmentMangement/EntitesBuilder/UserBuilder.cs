using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AssessmentMangement.Entites;

namespace AssessmentMangement.EntitesBuilder
{
    internal class UserBuilder : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
        }
    }
}
