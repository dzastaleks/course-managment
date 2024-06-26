﻿// <auto-generated />
using CourseManagmentBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CourseManagmentBackend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210421234433_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkCourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CourseManagmentBackend.Models.Student", b =>
                {
                    b.Property<long>("PkStudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojIndeksa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Godina")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("PkStudentID");

                    b.ToTable("Students");
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
