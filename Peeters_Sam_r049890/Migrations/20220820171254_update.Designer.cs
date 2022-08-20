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
    [Migration("20220820171254_update")]
    partial class update
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MerkId");

                    b.ToTable("Merken");
                });

            modelBuilder.Entity("Peeters_Sam_r049890.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Aantal")
                        .HasColumnType("int");

                    b.Property<int>("KlantId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Peeters_Sam_r049890.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Aantal")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Prijs")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SmartphoneId")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("SmartphoneId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("Peeters_Sam_r049890.Models.ShoppingCardItem", b =>
                {
                    b.Property<int>("ShoppingCardItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Hoeveelheid")
                        .HasColumnType("int");

                    b.Property<string>("ShoppingCardId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SmartphoneId")
                        .HasColumnType("int");

                    b.HasKey("ShoppingCardItemId");

                    b.HasIndex("SmartphoneId");

                    b.ToTable("ShoppingCardItems");
                });

            modelBuilder.Entity("Peeters_Sam_r049890.Models.Smartphone", b =>
                {
                    b.Property<int>("SmartphoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AangemaaktDatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("MerkId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Prijs")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SmartphoneId");

                    b.HasIndex("MerkId");

                    b.ToTable("Smartphone");
                });

            modelBuilder.Entity("Peeters_Sam_r049890.Models.OrderItem", b =>
                {
                    b.HasOne("Peeters_Sam_r049890.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Peeters_Sam_r049890.Models.Smartphone", "Smartphone")
                        .WithMany()
                        .HasForeignKey("SmartphoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Peeters_Sam_r049890.Models.ShoppingCardItem", b =>
                {
                    b.HasOne("Peeters_Sam_r049890.Models.Smartphone", "Smartphone")
                        .WithMany()
                        .HasForeignKey("SmartphoneId");
                });

            modelBuilder.Entity("Peeters_Sam_r049890.Models.Smartphone", b =>
                {
                    b.HasOne("Peeters_Sam_r049890.Models.Merk", "Merk")
                        .WithMany("Smartphones")
                        .HasForeignKey("MerkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
