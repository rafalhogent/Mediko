using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedikoData.Entities;

namespace MedikoData.Configurations
{
    public class LogConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {

            builder.ToTable("Logs");
            //builder.HasKey(p => new { p.creatorId, p.typeId, p.LogTime })
            //       .HasName("PK_Logs");



            builder.HasOne(l => l.Creator)
                   .WithMany(c => c.Logs).IsRequired();

            builder.HasOne(x => x.LogBook)
                   .WithMany(x => x.Logs)
                   //.HasForeignKey(x => x.typeId)
                   .IsRequired();




            // Concurrency - Met TimeStamp :
        }
    }
}
