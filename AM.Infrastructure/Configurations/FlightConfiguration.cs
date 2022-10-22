using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace AM.Infrastructure.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        { 

            builder.HasMany(F => F.passengers).WithMany(Passenger => Passenger.flights)
                .UsingEntity(i => i.ToTable("Reservation"));

            builder.HasOne(f => f.Plane).WithMany(Plane=>Plane.flights)
                .HasForeignKey(Plane=>Plane.PlaneId).OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
