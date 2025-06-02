using GuessingGameApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GuessingGameApp.Data.Configurations;

internal class GuessGameResultConfiguration : IEntityTypeConfiguration<GuessGameResult>
{
    public void Configure(EntityTypeBuilder<GuessGameResult> builder)
    {
        builder.ToTable("Results");

        builder.HasKey(ggr => ggr.Id);

        builder.Property(ggr => ggr.CreatedAt).IsRequired();

        builder.Property(ggr => ggr.IsGuessedCorrect)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(ggr => ggr.ResultMessage)
            .IsRequired()
            .HasMaxLength(20);
    }
}