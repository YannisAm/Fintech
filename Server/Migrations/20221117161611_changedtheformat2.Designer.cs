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
    [Migration("20221117161611_changedtheformat2")]
    partial class changedtheformat2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Fintech.Shared.Models.Portfolio", b =>
                {
                    b.Property<int>("PortfolioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PortfolioId"), 1L, 1);

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameOfPortfolio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PortfolioId");

                    b.ToTable("Portofolios");
                });

            modelBuilder.Entity("Fintech.Shared.Models.Security", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateTimeObtained")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PortfolioId")
                        .HasColumnType("int");

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

                    b.HasIndex("PortfolioId");

                    b.ToTable("Securities");
                });

            modelBuilder.Entity("Fintech.Shared.Models.Security", b =>
                {
                    b.HasOne("Fintech.Shared.Models.Portfolio", "Portfolio")
                        .WithMany("Securities")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("Fintech.Shared.Models.Portfolio", b =>
                {
                    b.Navigation("Securities");
                });
#pragma warning restore 612, 618
        }
    }
}
