﻿// <auto-generated />
using System;
using CourseManagmentBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CourseManagmentBackend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CourseManagmentBackend.Models.Course", b =>
                {
                    b.Property<long>("PkCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazivKursa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkCourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CourseManagmentBackend.Models.Status", b =>
                {
                    b.Property<long>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("CourseManagmentBackend.Models.Student", b =>
                {
                    b.Property<long>("PkStudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojIndeksa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("StatusId")
                        .HasColumnType("bigint");

                    b.Property<long?>("YearId")
                        .HasColumnType("bigint");

                    b.HasKey("PkStudentID");

                    b.HasIndex("StatusId");

                    b.HasIndex("YearId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("CourseManagmentBackend.Models.User", b =>
                {
                    b.Property<Guid>("PkUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkUserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CourseManagmentBackend.Models.Year", b =>
                {
                    b.Property<long>("YearId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("YearId");

                    b.ToTable("Year");
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.Property<long>("KurseviPkCourseId")
                        .HasColumnType("bigint");

                    b.Property<long>("StudentiPkStudentID")
                        .HasColumnType("bigint");

                    b.HasKey("KurseviPkCourseId", "StudentiPkStudentID");

                    b.HasIndex("StudentiPkStudentID");

                    b.ToTable("CourseStudent");
                });

            modelBuilder.Entity("CourseManagmentBackend.Models.Student", b =>
                {
                    b.HasOne("CourseManagmentBackend.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.HasOne("CourseManagmentBackend.Models.Year", "Year")
                        .WithMany()
                        .HasForeignKey("YearId");

                    b.Navigation("Status");

                    b.Navigation("Year");
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.HasOne("CourseManagmentBackend.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("KurseviPkCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseManagmentBackend.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentiPkStudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
