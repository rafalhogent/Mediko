
using MedikoData.Configurations;
using MedikoData.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;


namespace MedikoData
{
    public class MedikoDbContext : IdentityDbContext<AppUser>
    {
        public MedikoDbContext() { }
        public MedikoDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Log> Logs { get; set; } = null!;
        public DbSet<LogBook> LogBooks { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "Administrator"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Patient",
                    NormalizedName = "Patient"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Doktor",
                    NormalizedName = "Doktor"
                }
                ,
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Editor",
                    NormalizedName = "Editor"
                }
                );


            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new LogBookConfiguration());
            builder.ApplyConfiguration(new LogConfiguration());



           
        }


    }



}

