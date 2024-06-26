﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherForecastWebAPI.DBContext;

#nullable disable

namespace WeatherForecastWebAPI.Migrations
{
    [DbContext(typeof(WeatherForecastMSSQLDBContext))]
    [Migration("20240508151428_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WeatherForecastWebAPI.Models.WeatherForecastModelV1", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<double>("TemperatureC")
                        .HasColumnType("float");

                    b.HasKey("Date", "Latitude", "Longitude");

                    b.ToTable("WeatherForecastV1");
                });

            modelBuilder.Entity("WeatherForecastWebAPI.Models.WeatherForecastModelV2", b =>
                {
                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("TemperatureC")
                        .HasColumnType("float");

                    b.HasKey("Latitude", "Longitude", "Date");

                    b.ToTable("WeatherForecastV2");
                });
#pragma warning restore 612, 618
        }
    }
}
