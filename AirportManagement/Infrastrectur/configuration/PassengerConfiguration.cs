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
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            //configurer les type détenu
            
            builder.OwnsOne(p => p.FullName,
                full =>
                {
                    full.Property(f => f.FirstName).HasMaxLength(30).HasColumnName("PassFirstName");
                    full.Property(f => f.LastName).IsRequired().HasColumnName("PassLastName");
                }
                
                
                );


            // configurer l'heritage TPH (table Par hirarchie)
          //  builder.HasDiscriminator<int>("IsTraveller").HasValue<Passenger>(0).HasValue<Traveller>(1).HasValue<Staff>(2);

        }
    }
}
