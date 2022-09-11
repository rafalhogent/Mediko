﻿// <auto-generated />
using System;
using MedikoData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MedikoData.Migrations
{
    [DbContext(typeof(MedikoDbContext))]
    partial class MedikoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AppUserLogBook", b =>
                {
                    b.Property<int>("ChoosenLogbooksLogBookId")
                        .HasColumnType("int");

                    b.Property<string>("UsersWhoChoosenId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ChoosenLogbooksLogBookId", "UsersWhoChoosenId");

                    b.HasIndex("UsersWhoChoosenId");

                    b.ToTable("AppUserLogBook");
                });

            modelBuilder.Entity("MedikoData.Entities.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("Language")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "c7db1571-f6a6-4126-9b24-0a609cc15a29",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "def979dc-a7c0-492c-bae2-4d15aad78bd2",
                            EmailConfirmed = false,
                            Language = 1,
                            LockoutEnabled = false,
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEL+zn48nEAiE4IC3cTONbVyNoB80Np9Cs8B5d2oNSP36kYMdBR7849hTEm8AvNE58A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6df89451-fca1-4e9f-9f4b-96992a9c701f",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("MedikoData.Entities.Log", b =>
                {
                    b.Property<int>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LogId"), 1L, 1);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("LogBookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LogTime")
                        .HasColumnType("datetime2");

                    b.Property<float?>("Value1")
                        .HasColumnType("real");

                    b.Property<float?>("Value2")
                        .HasColumnType("real");

                    b.Property<float?>("Value3")
                        .HasColumnType("real");

                    b.HasKey("LogId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("LogBookId");

                    b.ToTable("Logs", (string)null);
                });

            modelBuilder.Entity("MedikoData.Entities.LogBook", b =>
                {
                    b.Property<int>("LogBookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LogBookId"), 1L, 1);

                    b.Property<string>("CreatorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Field1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Field3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IconUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Precision")
                        .HasColumnType("int");

                    b.Property<string>("Unit1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit3")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LogBookId");

                    b.HasIndex("CreatorId");

                    b.ToTable("LogBooks");

                    b.HasData(
                        new
                        {
                            LogBookId = 1,
                            Name = "Dagboek",
                            Precision = 0
                        },
                        new
                        {
                            LogBookId = 2,
                            Field1 = "gewicht",
                            Name = "Gewicht",
                            Precision = 1,
                            Unit1 = "kg"
                        },
                        new
                        {
                            LogBookId = 3,
                            Field1 = "systolic",
                            Field2 = "diastolic",
                            Field3 = "pulse",
                            Name = "Bloeddruk",
                            Precision = 0
                        },
                        new
                        {
                            LogBookId = 4,
                            Field1 = "temperatuur",
                            Name = "Temperatuur",
                            Precision = 1,
                            Unit1 = "°C"
                        },
                        new
                        {
                            LogBookId = 5,
                            Field1 = "drink",
                            Name = "Water",
                            Precision = 1,
                            Unit1 = "ml"
                        },
                        new
                        {
                            LogBookId = 6,
                            Field1 = "glucose",
                            Name = "Glucose",
                            Precision = 1,
                            Unit1 = "mmol/L"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "acc248e1-2ff7-45f0-bb95-782cf55dc309",
                            ConcurrencyStamp = "9fecf9b2-ea30-43b4-b213-bfbba30b8972",
                            Name = "Admin",
                            NormalizedName = "Administrator"
                        },
                        new
                        {
                            Id = "f515dbfd-c2ba-4ae9-977e-ba13717596b7",
                            ConcurrencyStamp = "e3029452-2a31-4773-8962-ff5e0555ae52",
                            Name = "Patient",
                            NormalizedName = "Patient"
                        },
                        new
                        {
                            Id = "9e34941c-2e2e-46d7-825f-abcff3f9cba1",
                            ConcurrencyStamp = "834d5cf8-18dd-4bc3-8b8c-7638ce2dbbc5",
                            Name = "Doktor",
                            NormalizedName = "Doktor"
                        },
                        new
                        {
                            Id = "40c952aa-b7ba-48c3-8dbd-8aa57d8c41e6",
                            ConcurrencyStamp = "555da7e6-2406-43d4-b1bb-a448b24ac203",
                            Name = "Editor",
                            NormalizedName = "Editor"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "c7db1571-f6a6-4126-9b24-0a609cc15a29",
                            RoleId = "acc248e1-2ff7-45f0-bb95-782cf55dc309"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AppUserLogBook", b =>
                {
                    b.HasOne("MedikoData.Entities.LogBook", null)
                        .WithMany()
                        .HasForeignKey("ChoosenLogbooksLogBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedikoData.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UsersWhoChoosenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedikoData.Entities.Log", b =>
                {
                    b.HasOne("MedikoData.Entities.AppUser", "Creator")
                        .WithMany("Logs")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedikoData.Entities.LogBook", "LogBook")
                        .WithMany("Logs")
                        .HasForeignKey("LogBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("LogBook");
                });

            modelBuilder.Entity("MedikoData.Entities.LogBook", b =>
                {
                    b.HasOne("MedikoData.Entities.AppUser", "Creator")
                        .WithMany("CustomLogbooks")
                        .HasForeignKey("CreatorId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MedikoData.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MedikoData.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedikoData.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MedikoData.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedikoData.Entities.AppUser", b =>
                {
                    b.Navigation("CustomLogbooks");

                    b.Navigation("Logs");
                });

            modelBuilder.Entity("MedikoData.Entities.LogBook", b =>
                {
                    b.Navigation("Logs");
                });
#pragma warning restore 612, 618
        }
    }
}
