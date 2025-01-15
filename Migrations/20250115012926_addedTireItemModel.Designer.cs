﻿// <auto-generated />
using System;
using BTMSAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BTMSAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250115012926_addedTireItemModel")]
    partial class addedTireItemModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BTMSAPI.Models.BatteryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Batteryserial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateReceived")
                        .HasColumnType("datetime2");

                    b.Property<string>("DebossedNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DrsiNo")
                        .HasColumnType("int");

                    b.Property<string>("ItemCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PoNo")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Receivedby")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Supplier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unitofmeasurement")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BatteryItems");
                });

            modelBuilder.Entity("BTMSAPI.Models.BatteryReleasedItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BatteryItemId")
                        .HasColumnType("int");

                    b.Property<string>("BusinessUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imjno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldSnDebossedNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReleasedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("ReleasedReceivedby")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserplateNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BatteryItemId")
                        .IsUnique()
                        .HasFilter("[BatteryItemId] IS NOT NULL");

                    b.ToTable("BatteryReleasedItems");
                });

            modelBuilder.Entity("BTMSAPI.Models.BatteryReturnedItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BatteryReleasedItemId")
                        .HasColumnType("int");

                    b.Property<string>("Endorsedby")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReceivedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BatteryReleasedItemId")
                        .IsUnique()
                        .HasFilter("[BatteryReleasedItemId] IS NOT NULL");

                    b.ToTable("BatteryReturnedItems");
                });

            modelBuilder.Entity("BTMSAPI.Models.BusinessUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BusinessLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessunitDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessunitName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BusinessUnit");
                });

            modelBuilder.Entity("BTMSAPI.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DepartmentCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("BTMSAPI.Models.TireItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DateReceived")
                        .HasColumnType("datetime2");

                    b.Property<string>("DebossedNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DrciNo")
                        .HasColumnType("int");

                    b.Property<string>("ItemCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewSerialNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PoNo")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Receivedby")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Supplier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TireSerial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TireType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tirebrand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tiresize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unitofmeasurement")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TireItems");
                });

            modelBuilder.Entity("BTMSAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BusinessUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Esignature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IsActive")
                        .HasColumnType("int");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Middlename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BTMSAPI.Models.BatteryReleasedItems", b =>
                {
                    b.HasOne("BTMSAPI.Models.BatteryItem", "BatteryItem")
                        .WithOne()
                        .HasForeignKey("BTMSAPI.Models.BatteryReleasedItems", "BatteryItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("BatteryItem");
                });

            modelBuilder.Entity("BTMSAPI.Models.BatteryReturnedItems", b =>
                {
                    b.HasOne("BTMSAPI.Models.BatteryReleasedItems", "BatteryReleasedItem")
                        .WithOne()
                        .HasForeignKey("BTMSAPI.Models.BatteryReturnedItems", "BatteryReleasedItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("BatteryReleasedItem");
                });
#pragma warning restore 612, 618
        }
    }
}
