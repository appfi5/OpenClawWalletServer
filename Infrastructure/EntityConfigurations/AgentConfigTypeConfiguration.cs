using OpenClawWalletServer.Domain.AggregatesModel.AgentConfigAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OpenClawWalletServer.Infrastructure.EntityConfigurations;

/// <summary>
/// Agent配置的数据库配置
/// </summary>
public class AgentConfigTypeConfiguration : IEntityTypeConfiguration<AgentConfig>
{
    public void Configure(EntityTypeBuilder<AgentConfig> builder)
    {
        builder.ToTable("AgentConfig");

        builder.HasKey(ac => ac.Id);

        builder.Property(t => t.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        builder.Property(ac => ac.ServerUrl)
            .IsRequired()
            .HasMaxLength(256)
            .HasDefaultValue(string.Empty);

        builder.Property(ac => ac.Code)
            .IsRequired()
            .HasMaxLength(128)
            .HasDefaultValue(string.Empty);

        builder.Property(ac => ac.Token)
            .IsRequired()
            .HasMaxLength(256)
            .HasDefaultValue(string.Empty);

        builder.Property(ac => ac.Deleted)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(ac => ac.CreatedAt)
            .IsRequired()
            .HasDefaultValue(DateTime.MinValue);
        
        builder.Property(ac => ac.UpdateAt)
            .IsRequired()
            .HasDefaultValue(DateTime.MinValue);
    }
}
