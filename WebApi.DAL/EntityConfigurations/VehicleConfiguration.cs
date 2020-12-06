using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.DAL.Models;

namespace WebApi.DAL.EntityConfigurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(x => x.MakeGe).HasMaxLength(30);
            builder.Property(x => x.MakeEn).HasMaxLength(30);
            builder.Property(x => x.ModelGe).HasMaxLength(30);
            builder.Property(x => x.ModelEn).HasMaxLength(30);
            builder.Property(x => x.Vin).HasMaxLength(17);
            builder.Property(x => x.RegistrationPlate).HasMaxLength(9);
            builder.Property(x => x.ImageName).HasMaxLength(80);
        }
    }
}
