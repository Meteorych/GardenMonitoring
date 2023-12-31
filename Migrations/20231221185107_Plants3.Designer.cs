﻿// <auto-generated />
using System;
using GardenMonitoring.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GardenMonitoring.Migrations
{
    [DbContext(typeof(PlantContext))]
    [Migration("20231221185107_Plants3")]
    partial class Plants3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GardenMonitoring.Models.Plant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Plant");
                });

            modelBuilder.Entity("GardenMonitoring.Models.PlantClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PlantClass");
                });

            modelBuilder.Entity("GardenMonitoring.Models.PlantState", b =>
                {
                    b.Property<int>("PlantId")
                        .HasColumnType("int");

                    b.Property<int>("Humidity")
                        .HasColumnType("int");

                    b.Property<int>("Light")
                        .HasColumnType("int");

                    b.Property<int>("Pressure")
                        .HasColumnType("int");

                    b.Property<int>("Temperature")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("PlantId");

                    b.ToTable("PlantState");
                });

            modelBuilder.Entity("GardenMonitoring.Models.Sensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("SensorState")
                        .HasColumnType("bit");

                    b.Property<string>("SensorType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sensor");
                });

            modelBuilder.Entity("GardenMonitoring.Models.Settings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MaxHumidity")
                        .HasColumnType("int");

                    b.Property<int>("MaxLight")
                        .HasColumnType("int");

                    b.Property<int>("MaxPressure")
                        .HasColumnType("int");

                    b.Property<int>("MaxTemperature")
                        .HasColumnType("int");

                    b.Property<int>("MinHumidity")
                        .HasColumnType("int");

                    b.Property<int>("MinLight")
                        .HasColumnType("int");

                    b.Property<int>("MinPressure")
                        .HasColumnType("int");

                    b.Property<int>("MinTemperature")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Settings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MaxHumidity = 85,
                            MaxLight = 3500,
                            MaxPressure = 900,
                            MaxTemperature = 30,
                            MinHumidity = 65,
                            MinLight = 2500,
                            MinPressure = 730,
                            MinTemperature = 20
                        });
                });

            modelBuilder.Entity("GardenMonitoring.Models.Plant", b =>
                {
                    b.HasOne("GardenMonitoring.Models.PlantClass", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("GardenMonitoring.Models.PlantState", b =>
                {
                    b.HasOne("GardenMonitoring.Models.Plant", "Plant")
                        .WithMany()
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plant");
                });
#pragma warning restore 612, 618
        }
    }
}
