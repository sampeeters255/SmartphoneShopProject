﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Peeters_Sam_r049890.Data;

namespace Peeters_Sam_r049890.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220818160104_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Peeters_Sam_r049890.Models.Klant", b =>
                {
                    b.Property<int>("KlantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Voornaam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KlantId");

                    b.ToTable("Klanten");
                });

            modelBuilder.Entity("Peeters_Sam_r049890.Models.Merk", b =>
                {
                    b.Property<int>("MerkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Herkomst")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Merknaam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MerkId");

                    b.ToTable("Merken");
                });

            modelBuilder.Entity("Peeters_Sam_r049890.Models.Smartphone", b =>
                {
                    b.Property<int>("SmartphoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MerkId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Prijs")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SmartphoneId");

                    b.HasIndex("MerkId");

                    b.ToTable("Smartphone");
                });

            modelBuilder.Entity("Peeters_Sam_r049890.Models.Smartphone", b =>
                {
                    b.HasOne("Peeters_Sam_r049890.Models.Merk", "Merk")
                        .WithMany("Smartphones")
                        .HasForeignKey("MerkId");
                });
#pragma warning restore 612, 618
        }
    }
}