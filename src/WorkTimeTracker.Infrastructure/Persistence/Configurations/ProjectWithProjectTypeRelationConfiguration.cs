using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkTimeTracker.Domain.Models;

namespace WorkTimeTracker.Infrastructure.Persistence.Configurations;

internal sealed class ProjectWithProjectTypeRelationConfiguration : IEntityTypeConfiguration<ProjectWithProjectTypeRelation>
{
    public void Configure(EntityTypeBuilder<ProjectWithProjectTypeRelation> builder)
    {
        builder.HasKey(
            x => new
            {
                x.ProjectId,
                x.ProjectTypeId,
            }
        );
    }
}
