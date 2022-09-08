using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedikoData.Entities;

namespace MedikoData.Configurations
{
    public class LogBookConfiguration : IEntityTypeConfiguration<LogBook>
    {
        public void Configure(EntityTypeBuilder<LogBook> builder)
        {

            //builder.HasOne(x => x.Creator).WithMany(c => c.CustomLogBooks);
            //builder.HasMany(x => x.Logs).WithOne(l => l.Type);


            builder.HasData(
                new LogBook { LogBookId = 1, Name = "Diary" },
                new LogBook { LogBookId = 2, Name = "Weight", Field1 = "weight", Unit1 = "kg", Precision = 1 },
                new LogBook
                {
                    LogBookId = 3,
                    Name = "Blood pressure",
                    Field1 = "systolic",
                    Field2 = "diastolic",
                    Field3 = "pulse",
                    Precision = 0
                },

                new LogBook { LogBookId = 4, Name = "Temperature", Field1 = "temperature", Unit1 = "°C", Precision = 1 },
                new LogBook { LogBookId = 5, Name = "Water", Field1 = "drink", Unit1 = "ml", Precision = 1 },
                new LogBook { LogBookId = 6, Name = "Glucose", Field1 = "glucose", Unit1 = "mmol/L", Precision = 1 }


                );
        }
    }
}
