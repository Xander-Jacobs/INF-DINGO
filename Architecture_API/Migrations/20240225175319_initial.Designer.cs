﻿// <auto-generated />
using Architecture_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Architecture_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240225175319_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Architecture_API.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            Description = "Year 1, Semester 1. Academic Information Management",
                            Duration = "Semester",
                            Name = "AIM101"
                        },
                        new
                        {
                            CourseId = 2,
                            Description = "Year 1, Semester 2. Academic Literacy for IT",
                            Duration = "Semester",
                            Name = "ALL121"
                        },
                        new
                        {
                            CourseId = 3,
                            Description = "Year 1. Systems Analysis and Design",
                            Duration = "Year",
                            Name = "INF171"
                        },
                        new
                        {
                            CourseId = 4,
                            Description = "Year 2. Systems Analysis and Design",
                            Duration = "Year",
                            Name = "INF271"
                        },
                        new
                        {
                            CourseId = 5,
                            Description = "Year 2. Programming",
                            Duration = "Year",
                            Name = "INF272"
                        },
                        new
                        {
                            CourseId = 6,
                            Description = "Year 2, Semester 1. Databases",
                            Duration = "Semester",
                            Name = "INF214"
                        },
                        new
                        {
                            CourseId = 7,
                            Description = "Year 3, Semester 1. Programming Management",
                            Duration = "Semester",
                            Name = "INF315"
                        },
                        new
                        {
                            CourseId = 8,
                            Description = "Year 3, Semester 2. IT Trends",
                            Duration = "Semester",
                            Name = "INF324"
                        },
                        new
                        {
                            CourseId = 9,
                            Description = "Year 3, Semester 1. Programming",
                            Duration = "Semester",
                            Name = "INF354"
                        },
                        new
                        {
                            CourseId = 10,
                            Description = "Year 3. Project",
                            Duration = "Year",
                            Name = "INF370"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
