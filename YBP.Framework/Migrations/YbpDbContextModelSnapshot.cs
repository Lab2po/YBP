﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using YBP.Framework.Storage.EF;

namespace YBP.Framework.Migrations
{
    [DbContext(typeof(YbpDbContext))]
    partial class YbpDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("YBP.Framework.Storage.EF.YbpActionHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("FinishedUTC");

                    b.Property<bool>("IsAuthorized");

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Params");

                    b.Property<int>("ProcessId");

                    b.Property<string>("Results");

                    b.Property<DateTime>("StartedUTC");

                    b.Property<bool>("Succeed");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .HasName("IX_Ybp_ActionHistory_Name");

                    b.HasIndex("ProcessId");

                    b.ToTable("YbpActionHistory");
                });

            modelBuilder.Entity("YBP.Framework.Storage.EF.YbpFlag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsSet");

                    b.Property<string>("Key")
                        .HasMaxLength(128);

                    b.Property<int>("ProcessId");

                    b.Property<DateTime>("UpdatedUTC");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProcessId");

                    b.ToTable("YbpFlags");
                });

            modelBuilder.Entity("YBP.Framework.Storage.EF.YbpFlagHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FlagId");

                    b.Property<bool>("IsSet");

                    b.Property<DateTime>("UpdatedUTC");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("FlagId");

                    b.ToTable("YbpFlagHistory");
                });

            modelBuilder.Entity("YBP.Framework.Storage.EF.YbpProcess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InstanceId")
                        .HasMaxLength(128);

                    b.Property<string>("Pfx")
                        .HasMaxLength(16);

                    b.Property<string>("SecurityContext")
                        .HasMaxLength(2048);

                    b.HasKey("Id");

                    b.HasIndex("Pfx", "InstanceId")
                        .IsUnique()
                        .HasName("IX_Ybp_Process")
                        .HasFilter("[Pfx] IS NOT NULL AND [InstanceId] IS NOT NULL");

                    b.ToTable("YbpProcesses");
                });

            modelBuilder.Entity("YBP.Framework.Storage.EF.YbpActionHistory", b =>
                {
                    b.HasOne("YBP.Framework.Storage.EF.YbpProcess", "Process")
                        .WithMany()
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("YBP.Framework.Storage.EF.YbpFlag", b =>
                {
                    b.HasOne("YBP.Framework.Storage.EF.YbpProcess", "Process")
                        .WithMany()
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("YBP.Framework.Storage.EF.YbpFlagHistory", b =>
                {
                    b.HasOne("YBP.Framework.Storage.EF.YbpFlag", "Flag")
                        .WithMany()
                        .HasForeignKey("FlagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}