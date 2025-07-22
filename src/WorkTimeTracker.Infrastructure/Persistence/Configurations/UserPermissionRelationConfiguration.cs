using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkTimeTracker.Domain.Models;

namespace WorkTimeTracker.Infrastructure.Persistence.Configurations;

public sealed class UserPermissionRelationConfiguration : IEntityTypeConfiguration<UserPermissionRelation>
{
    public void Configure(EntityTypeBuilder<UserPermissionRelation> builder)
    {
        builder.HasKey(
            x => new
            {
                x.UserId,
                x.PermissionId,
            }
        );
    }
}
