using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FriendOrganizer.DataAcess.Data
{
    public class FriendConfiguration : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.ToTable("Friends");
            builder.HasKey(f => f.Id);
            builder.Property(f => f.FirstName).IsRequired().HasMaxLength(20);
            builder.Property(f => f.LastName).IsRequired().HasMaxLength(40);
            builder.Property(f => f.Email).IsRequired().HasMaxLength(30);
        }
    }
}
