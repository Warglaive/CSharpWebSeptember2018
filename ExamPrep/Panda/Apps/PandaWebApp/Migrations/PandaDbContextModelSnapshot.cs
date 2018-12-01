﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PandaWebApp.Data;

namespace PandaWebApp.Migrations
{
    [DbContext(typeof(PandaDbContext))]
    partial class PandaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PandaWebApp.Models.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime>("EstimatedDeliveryDate");

                    b.Property<int>("ReceiptId");

                    b.Property<int>("RecipientId");

                    b.Property<string>("ShippingAddress");

                    b.Property<int>("Status");

                    b.Property<double>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("ReceiptId")
                        .IsUnique();

                    b.HasIndex("RecipientId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("PandaWebApp.Models.Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Fee");

                    b.Property<DateTime>("IssuedOn");

                    b.Property<int>("PackageId");

                    b.Property<int>("RecipientId");

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("PandaWebApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<int>("Role");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PandaWebApp.Models.Package", b =>
                {
                    b.HasOne("PandaWebApp.Models.Receipt", "Receipt")
                        .WithOne("Package")
                        .HasForeignKey("PandaWebApp.Models.Package", "ReceiptId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PandaWebApp.Models.User", "Recipient")
                        .WithMany("Packages")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PandaWebApp.Models.Receipt", b =>
                {
                    b.HasOne("PandaWebApp.Models.User", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
