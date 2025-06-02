using GuessingGameApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GuessingGameApp.Data.Configurations;

internal class UserGameRelConfiguration : IEntityTypeConfiguration<UserGameRel>
{
    public void Configure(EntityTypeBuilder<UserGameRel> builder)
    {
        builder.ToTable("UserGameRels");

        builder.HasKey(ugr => ugr.Id);

        builder.Property(ugr => ugr.UserId).IsRequired();
        builder.Property(ugr => ugr.CreatedAt).IsRequired();
        builder.Property(ugr => ugr.GuessGameId).IsRequired();
        builder.Property(ugr => ugr.GuessesCount).IsRequired();

        builder.HasOne(ugr => ugr.User)
            .WithMany(u => u.Games)
            .HasForeignKey(ugr => ugr.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(ugr => ugr.GuessGame)
            .WithMany(gg => gg.Users)
            .HasForeignKey(ugr => ugr.GuessGameId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}