using GuessingGameApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GuessingGameApp.Data.Configurations;

internal class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.ToTable("Games");

        builder.HasKey(g => g.Id);

        builder.Property(g => g.CreatedAt).IsRequired();

        builder.Property(g => g.Developer)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(g => g.Genre)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(g => g.MetaScore)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(g => g.OriginalPlatform)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(g => g.Release)
            .IsRequired()
            .HasMaxLength(5);
    }
}