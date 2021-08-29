﻿// <auto-generated />
using BackendDioPrediction.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackendDioPrediction.Models.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210717102309_HouseToDatabaseV2")]
    partial class HouseToDatabaseV2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackendDioPrediction.Models.DbModels.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Bathrooms")
                        .HasColumnType("real");

                    b.Property<float>("Bedrooms")
                        .HasColumnType("real");

                    b.Property<int>("Condition")
                        .HasColumnType("int");

                    b.Property<float>("Floors")
                        .HasColumnType("real");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("SqftLiving")
                        .HasColumnType("int");

                    b.Property<int>("SqftLot")
                        .HasColumnType("int");

                    b.Property<int>("View")
                        .HasColumnType("int");

                    b.Property<bool>("Waterfront")
                        .HasColumnType("bit");

                    b.Property<int>("YearBuilt")
                        .HasColumnType("int");

                    b.Property<int>("YearRenovated")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Houses");
                });
#pragma warning restore 612, 618
        }
    }
}