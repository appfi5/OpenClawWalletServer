using OpenClawWalletServer.Domain.AggregatesModel.SendTransactionRecordAggregate;
using OpenClawWalletServer.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OpenClawWalletServer.Infrastructure.EntityConfigurations;

public class SendTransactionRecordTypeConfiguration : IEntityTypeConfiguration<SendTransactionRecord>
{
    public void Configure(EntityTypeBuilder<SendTransactionRecord> builder)
    {
        builder.ToTable("SendTransactionRecord");
        builder.HasKey(sr => sr.Id);

        builder.Property(sr => sr.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(t => t.AgentSendTransactionTaskId);
        builder.Property(sr => sr.OrderId)
            .IsRequired();
        builder.Property(sr => sr.OrderType)
            .IsRequired();
        builder.Property(t => t.CurrencyType)
            .IsRequired()
            .HasDefaultValue(CurrencyType.Unknown);
        builder.Property(t => t.Content)
            .IsRequired()
            .HasMaxLength(1024)
            .HasDefaultValue(string.Empty);
        builder.Property(t => t.ExecuteTime)
            .IsRequired()
            .HasDefaultValue(DateTime.MinValue);
        builder.Property(t => t.Deleted)
            .IsRequired()
            .HasDefaultValue(false);
    }
}
