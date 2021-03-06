﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zadatak.Data;

namespace Zadatak.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200824222025_prva.3")]
    partial class prva3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Zadatak.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Player1Id")
                        .HasColumnType("int");

                    b.Property<int?>("Player2Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Player1Id");

                    b.HasIndex("Player2Id");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("Zadatak.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<byte>("Years")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("Zadatak.Models.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("CurrentSet")
                        .HasColumnType("tinyint");

                    b.Property<bool>("IsOver")
                        .HasColumnType("bit");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MatchId")
                        .IsUnique();

                    b.ToTable("Result");
                });

            modelBuilder.Entity("Zadatak.Models.Set", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsPlayed")
                        .HasColumnType("bit");

                    b.Property<short>("Player1GemsWon")
                        .HasColumnType("smallint");

                    b.Property<short>("Player1Points")
                        .HasColumnType("smallint");

                    b.Property<short>("Player2GemsWon")
                        .HasColumnType("smallint");

                    b.Property<short>("Player2Points")
                        .HasColumnType("smallint");

                    b.Property<int?>("ResultId")
                        .HasColumnType("int");

                    b.Property<bool>("WithTieBreak")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ResultId");

                    b.ToTable("Set");
                });

            modelBuilder.Entity("Zadatak.Models.Match", b =>
                {
                    b.HasOne("Zadatak.Models.Player", "Player1")
                        .WithMany("Matches")
                        .HasForeignKey("Player1Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Zadatak.Models.Player", "Player2")
                        .WithMany()
                        .HasForeignKey("Player2Id");
                });

            modelBuilder.Entity("Zadatak.Models.Result", b =>
                {
                    b.HasOne("Zadatak.Models.Match", "Match")
                        .WithOne("Result")
                        .HasForeignKey("Zadatak.Models.Result", "MatchId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Zadatak.Models.Set", b =>
                {
                    b.HasOne("Zadatak.Models.Result", "Result")
                        .WithMany("Sets")
                        .HasForeignKey("ResultId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
