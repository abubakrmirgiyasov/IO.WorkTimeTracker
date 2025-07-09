using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkTimeTracker.Domain.Models;

namespace WorkTimeTracker.Infrastructure.Persistence.Configurations;

public class WorkTimeTrackingConfigurations : IEntityTypeConfiguration<WorkTimeTracking>
{
    public void Configure(EntityTypeBuilder<WorkTimeTracking> builder)
    {
        builder.HasIndex(x => x.Name);
        builder.HasIndex(x => x.ShortDescription);
    }
}
