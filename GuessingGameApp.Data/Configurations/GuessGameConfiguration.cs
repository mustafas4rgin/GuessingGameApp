using GuessingGameApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GuessingGameApp.Data.Configurations;

internal class GuessGameConfiguration : IEntityTypeConfiguration<GuessGame>
{
    public void Configure(EntityTypeBuilder<GuessGame> builder)
    {
        builder.ToTable("GuessGames");

        builder.HasKey(gg => gg.Id);

        builder.Property(gg => gg.CreatedAt).IsRequired();
        builder.Property(gg => gg.Answer).IsRequired();
        builder.Property(gg => gg.DayId).IsRequired();
        builder.Property(gg => gg.GuessGameResultId).IsRequired();

        builder.Property(gg => gg.GuessCount)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(gg => gg.IsPlayed)
            .IsRequired()
            .HasDefaultValue(false);

        builder.HasOne(gg => gg.Day)
            .WithMany()
            .HasForeignKey(gg => gg.DayId)
            .OnDelete(DeleteBehavior.NoAction);
            
        builder.HasOne(gg => gg.GuessGameResult)
            .WithMany()
            .HasForeignKey(gg => gg.GuessGameResultId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}