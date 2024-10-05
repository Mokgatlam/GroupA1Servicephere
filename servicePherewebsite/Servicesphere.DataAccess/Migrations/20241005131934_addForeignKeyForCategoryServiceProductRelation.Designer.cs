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
    [Migration("20241005131934_addForeignKeyForCategoryServiceProductRelation")]
    partial class addForeignKeyForCategoryServiceProductRelation
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
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

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
                            Name = "Electrical"
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

            modelBuilder.Entity("ServiceSphere.Models.ServiceProduct", b =>
                {
                    b.Property<int>("SProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("ImageUrls")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("SProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Service_Products");

                    b.HasData(
                        new
                        {
                            SProductId = 1,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 10, 1, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            Description = "Professional plaiting services for children, perfect for school and special occasions.",
                            ImageUrls = "url1.jpg,url2.jpg,url3.jpg",
                            IsActive = true,
                            IsVerified = true,
                            Location = "Bloemfontein",
                            Name = "Child Hair Plaiting",
                            Price = 150.0,
                            UpdatedAt = new DateTime(2024, 10, 1, 14, 30, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            SProductId = 2,
                            CategoryId = 3,
                            CreatedAt = new DateTime(2024, 10, 1, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            Description = "Expert electrical repairs and installations.",
                            ImageUrls = "electric1.jpg,electric2.jpg",
                            IsActive = true,
                            IsVerified = false,
                            Location = "Bloemfontein",
                            Name = "Electrical Repairs",
                            Price = 800.0,
                            UpdatedAt = new DateTime(2024, 10, 1, 14, 30, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            SProductId = 3,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 10, 1, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            Description = "Relaxing and rejuvenating facial treatment with natural products.",
                            ImageUrls = "facial1.jpg,facial2.jpg",
                            IsActive = true,
                            IsVerified = false,
                            Location = "Bloemfontein",
                            Name = "Facial Treatment",
                            Price = 450.0,
                            UpdatedAt = new DateTime(2024, 10, 1, 14, 30, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ServiceSphere.Models.ServiceProduct", b =>
                {
                    b.HasOne("ServiceSphere.Models.ServiceCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
