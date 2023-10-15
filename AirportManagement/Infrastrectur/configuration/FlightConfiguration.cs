using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrectur.configuration
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            //configuer la relation many to many
      //      builder.HasMany(f => f.Passengers).WithMany(p => p.Flights).UsingEntity(t => t.ToTable("Reservation"));
            //configuer la relation one to many
            builder.HasOne(f => f.Plane).WithMany(pl => pl.Flights).HasForeignKey(f => f.PlaneFK).OnDelete(DeleteBehavior.ClientSetNull);


            builder.HasKey(f => f.FlightId);
        }
    }
}
