﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sp19team23finalproject.DAL;

namespace sp19team23finalproject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190510165304_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("sp19team23finalproject.Models.Application", b =>
                {
                    b.Property<int>("ApplicationID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Accepted");

                    b.Property<int>("ApplicationNumber");

                    b.Property<int?>("PositionID");

                    b.Property<bool>("Status");

                    b.Property<string>("UserId");

                    b.HasKey("ApplicationID");

                    b.HasIndex("PositionID");

                    b.HasIndex("UserId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("sp19team23finalproject.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<bool>("ActiveStatus");

                    b.Property<DateTime?>("Birthday");

                    b.Property<int?>("CompanyID");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<decimal?>("GPA");

                    b.Property<int?>("GradDate");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<int?>("MajorID");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int?>("PositionType");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("CompanyID");

                    b.HasIndex("MajorID");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("sp19team23finalproject.Models.Company", b =>
                {
                    b.Property<int>("CompanyID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyDescription");

                    b.Property<string>("CompanyName")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Industry");

                    b.HasKey("CompanyID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("sp19team23finalproject.Models.Interview", b =>
                {
                    b.Property<int>("InterviewID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyID");

                    b.Property<DateTime>("InterviewDate");

                    b.Property<int>("InterviewRoom");

                    b.Property<bool>("InterviewStatus");

                    b.Property<int>("InterviewTime");

                    b.Property<int?>("PositionID");

                    b.Property<string>("RecruiterId");

                    b.Property<string>("StudentId");

                    b.HasKey("InterviewID");

                    b.HasIndex("CompanyID");

                    b.HasIndex("PositionID");

                    b.HasIndex("RecruiterId");

                    b.HasIndex("StudentId");

                    b.ToTable("Interviews");
                });

            modelBuilder.Entity("sp19team23finalproject.Models.Major", b =>
                {
                    b.Property<int>("MajorID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MajorName")
                        .IsRequired();

                    b.HasKey("MajorID");

                    b.ToTable("Majors");
                });

            modelBuilder.Entity("sp19team23finalproject.Models.Position", b =>
                {
                    b.Property<int>("PositionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyID");

                    b.Property<DateTime>("Deadline");

                    b.Property<string>("Description");

                    b.Property<string>("Location")
                        .IsRequired();

                    b.Property<int>("PositionType");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("PositionID");

                    b.HasIndex("CompanyID");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("sp19team23finalproject.Models.PositionApplication", b =>
                {
                    b.Property<int>("PositionApplicationID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApplicationID");

                    b.Property<int?>("PositionID");

                    b.HasKey("PositionApplicationID");

                    b.HasIndex("ApplicationID");

                    b.HasIndex("PositionID");

                    b.ToTable("PositionApplications");
                });

            modelBuilder.Entity("sp19team23finalproject.Models.PositionMajor", b =>
                {
                    b.Property<int>("PositionMajorID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MajorID");

                    b.Property<int?>("PositionID");

                    b.HasKey("PositionMajorID");

                    b.HasIndex("MajorID");

                    b.HasIndex("PositionID");

                    b.ToTable("PositionMajors");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("sp19team23finalproject.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("sp19team23finalproject.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("sp19team23finalproject.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("sp19team23finalproject.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("sp19team23finalproject.Models.Application", b =>
                {
                    b.HasOne("sp19team23finalproject.Models.Position", "Position")
                        .WithMany("Applications")
                        .HasForeignKey("PositionID");

                    b.HasOne("sp19team23finalproject.Models.AppUser", "User")
                        .WithMany("Applications")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("sp19team23finalproject.Models.AppUser", b =>
                {
                    b.HasOne("sp19team23finalproject.Models.Company", "Company")
                        .WithMany("AppUsers")
                        .HasForeignKey("CompanyID");

                    b.HasOne("sp19team23finalproject.Models.Major", "Major")
                        .WithMany("AppUsers")
                        .HasForeignKey("MajorID");
                });

            modelBuilder.Entity("sp19team23finalproject.Models.Interview", b =>
                {
                    b.HasOne("sp19team23finalproject.Models.Company", "Company")
                        .WithMany("Interviews")
                        .HasForeignKey("CompanyID");

                    b.HasOne("sp19team23finalproject.Models.Position", "Position")
                        .WithMany("Interviews")
                        .HasForeignKey("PositionID");

                    b.HasOne("sp19team23finalproject.Models.AppUser", "Recruiter")
                        .WithMany("InterviewsGiven")
                        .HasForeignKey("RecruiterId");

                    b.HasOne("sp19team23finalproject.Models.AppUser", "Student")
                        .WithMany("InterviewsSuffered")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("sp19team23finalproject.Models.Position", b =>
                {
                    b.HasOne("sp19team23finalproject.Models.Company", "Company")
                        .WithMany("Positions")
                        .HasForeignKey("CompanyID");
                });

            modelBuilder.Entity("sp19team23finalproject.Models.PositionApplication", b =>
                {
                    b.HasOne("sp19team23finalproject.Models.Application", "Application")
                        .WithMany()
                        .HasForeignKey("ApplicationID");

                    b.HasOne("sp19team23finalproject.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionID");
                });

            modelBuilder.Entity("sp19team23finalproject.Models.PositionMajor", b =>
                {
                    b.HasOne("sp19team23finalproject.Models.Major", "Major")
                        .WithMany("PositionMajors")
                        .HasForeignKey("MajorID");

                    b.HasOne("sp19team23finalproject.Models.Position", "Position")
                        .WithMany("PositionMajors")
                        .HasForeignKey("PositionID");
                });
#pragma warning restore 612, 618
        }
    }
}
