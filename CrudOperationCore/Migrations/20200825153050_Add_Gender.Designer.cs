﻿// <auto-generated />
using System;
using CrudOperationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrudOperationCore.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20200825153050_Add_Gender")]
    partial class Add_Gender
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CrudOperationCore.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("CrudOperationCore.Models.EShopProduct", b =>
                {
                    b.Property<int>("EShopProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("EShopProductId");

                    b.ToTable("EShopProducts");
                });

            modelBuilder.Entity("CrudOperationCore.Models.Gender", b =>
                {
                    b.Property<int>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenderName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenderId");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("CrudOperationCore.Models.Province", b =>
                {
                    b.Property<int>("ProvinceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProvinceName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProvinceId");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("CrudOperationCore.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("HomeAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileIamge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResidentailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("GenderId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CrudOperationCore.Models.City", b =>
                {
                    b.HasOne("CrudOperationCore.Models.Province", "Province")
                        .WithMany("cities")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CrudOperationCore.Models.User", b =>
                {
                    b.HasOne("CrudOperationCore.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");
                });
#pragma warning restore 612, 618
        }
    }
}
