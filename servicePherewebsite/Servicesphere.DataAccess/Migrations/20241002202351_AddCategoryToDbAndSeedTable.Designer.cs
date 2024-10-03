﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Servicesphere.DataAccess.Data;

#nullable disable

namespace Servicesphere.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241002202351_AddCategoryToDbAndSeedTable")]
    partial class AddCategoryToDbAndSeedTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.1.24451.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ServiceSphere.Models.ServiceCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryId");

                    b.ToTable("Service_Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 10, 1, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            Description = "personal grooming and beauty,hair styling, manicures, pedicures, and makeup services.",
                            Name = "Beauty & Personal Care"
                        },
                        new
                        {
                            CategoryId = 2,
                            CreatedAt = new DateTime(2024, 10, 1, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            Description = "Services for electrical installations, repairs, and maintenance, such as fixing electrical faults, installing new wiring, and setting up lighting systems.",
                            Name = "Plumbing"
                        },
                        new
                        {
                            CategoryId = 3,
                            CreatedAt = new DateTime(2024, 10, 1, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            Description = "Services related to health and wellness, including personal training, yoga instruction, physiotherapy, nutrition advice, and wellness coaching.",
                            Name = "Health & Fitness"
                        },
                        new
                        {
                            CategoryId = 4,
                            CreatedAt = new DateTime(2024, 10, 1, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            Description = "Includes building, remodeling, and renovation services for homes and commercial properties, covering carpentry, masonry, painting, and flooring.",
                            Name = "Construction & Renovation"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}