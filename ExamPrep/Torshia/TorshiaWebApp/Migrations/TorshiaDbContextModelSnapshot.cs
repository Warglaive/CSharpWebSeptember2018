﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TorshiaWebApp.Data;

namespace TorshiaWebApp.Migrations
{
    [DbContext(typeof(TorshiaDbContext))]
    partial class TorshiaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TorshiaWebApp.Models.Participant", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("TaskId");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("TorshiaWebApp.Models.Report", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ReportedOn");

                    b.Property<string>("ReporterId");

                    b.Property<int>("Status");

                    b.Property<string>("TaskId");

                    b.HasKey("Id");

                    b.HasIndex("ReporterId");

                    b.HasIndex("TaskId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("TorshiaWebApp.Models.Sector", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("TaskId");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("AffectedSectors");
                });

            modelBuilder.Entity("TorshiaWebApp.Models.Task", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("DueDate");

                    b.Property<bool>("IsReported");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TorshiaWebApp.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("Role");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TorshiaWebApp.Models.Participant", b =>
                {
                    b.HasOne("TorshiaWebApp.Models.Task")
                        .WithMany("Participants")
                        .HasForeignKey("TaskId");
                });

            modelBuilder.Entity("TorshiaWebApp.Models.Report", b =>
                {
                    b.HasOne("TorshiaWebApp.Models.User", "Reporter")
                        .WithMany()
                        .HasForeignKey("ReporterId");

                    b.HasOne("TorshiaWebApp.Models.Task", "Task")
                        .WithMany()
                        .HasForeignKey("TaskId");
                });

            modelBuilder.Entity("TorshiaWebApp.Models.Sector", b =>
                {
                    b.HasOne("TorshiaWebApp.Models.Task")
                        .WithMany("AffectedSectors")
                        .HasForeignKey("TaskId");
                });
#pragma warning restore 612, 618
        }
    }
}