﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NicolasCasamen_MVCTaller.Data;

#nullable disable

namespace NicolasCasamen_MVCTaller.Migrations
{
    [DbContext(typeof(NicolasCasamen_MVCTallerContext))]
    partial class NicolasCasamen_MVCTallerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NicolasCasamen_MVCTaller.Models.Burger", b =>
                {
                    b.Property<int>("BurgerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BurgerId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("WithCheese")
                        .HasColumnType("bit");

                    b.HasKey("BurgerId");

                    b.ToTable("Burger");
                });

            modelBuilder.Entity("NicolasCasamen_MVCTaller.Models.Promo", b =>
                {
                    b.Property<int>("PromoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PromoId"), 1L, 1);

                    b.Property<int>("BurgerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaPromocion")
                        .HasColumnType("datetime2");

                    b.Property<string>("PromoDescripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PromoId");

                    b.HasIndex("BurgerId");

                    b.ToTable("Promo");
                });

            modelBuilder.Entity("NicolasCasamen_MVCTaller.Models.Promo", b =>
                {
                    b.HasOne("NicolasCasamen_MVCTaller.Models.Burger", "Burger")
                        .WithMany("Promos")
                        .HasForeignKey("BurgerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Burger");
                });

            modelBuilder.Entity("NicolasCasamen_MVCTaller.Models.Burger", b =>
                {
                    b.Navigation("Promos");
                });
#pragma warning restore 612, 618
        }
    }
}
