﻿// <auto-generated />
using System;
using Fintech.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fintech.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220921164855_SecuritySeeding")]
    partial class SecuritySeeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Fintech.Shared.Models.Security", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateTimeObtained")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("SecurityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StockesOwned")
                        .HasColumnType("int");

                    b.Property<float>("StocksValue")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Securities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateTimeObtained = new DateTime(2022, 9, 21, 19, 48, 55, 263, DateTimeKind.Local).AddTicks(5052),
                            Description = "The best ETF",
                            Price = 152.69f,
                            SecurityName = "VUAA",
                            StockesOwned = 3,
                            StocksValue = 458.07f
                        },
                        new
                        {
                            Id = 2,
                            DateTimeObtained = new DateTime(2022, 9, 21, 19, 48, 55, 263, DateTimeKind.Local).AddTicks(5059),
                            Description = "The best MSFT",
                            Price = 352.42f,
                            SecurityName = "MSFT",
                            StockesOwned = 10,
                            StocksValue = 3524.2f
                        },
                        new
                        {
                            Id = 3,
                            DateTimeObtained = new DateTime(2022, 9, 21, 19, 48, 55, 263, DateTimeKind.Local).AddTicks(5065),
                            Description = "The best technological company",
                            Price = 1253.88f,
                            SecurityName = "APPL",
                            StockesOwned = 100,
                            StocksValue = 12538.8f
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
