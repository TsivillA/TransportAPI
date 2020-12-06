using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.DAL.Models;

namespace WebApi.DAL.EntityConfigurations
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30);
            builder.Property(x => x.LastName).HasMaxLength(50);
            builder.Property(x => x.PersonalId).HasMaxLength(11);
            builder.HasIndex(x => x.PersonalId).IsUnique();
        }
    }
}
