﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using infrastructure;

namespace infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200425163751_initialCreate")]
    partial class initialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.entities.Address", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Core.entities.Owner", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID");

                    b.Property<Guid?>("Addressid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("profil")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Addressid");

                    b.ToTable("Owner");

                    b.HasData(
                        new
                        {
                            id = new Guid("7c9c3df2-2c78-4d75-b81d-b2d7bb4b8090"),
                            Avatar = "Avatar.jpg",
                            FullName = "Khalid essaadani",
                            profil = "Microsoft MVP/ .NET Consultant"
                        });
                });

            modelBuilder.Entity("Core.entities.PortfolioItem", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID");

                    b.Property<string>("Discreption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("PortfolioItems");
                });

            modelBuilder.Entity("Core.entities.Owner", b =>
                {
                    b.HasOne("Core.entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("Addressid");
                });
#pragma warning restore 612, 618
        }
    }
}