﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Treehouse.AspNetCore.Data;

namespace Treehouse.AspNetCore.Migrations
{
    [DbContext(typeof(PlayerContext))]
    [Migration("20200111201949_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Treehouse.AspNetCore.Models.League+Conference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Conference");
                });

            modelBuilder.Entity("Treehouse.AspNetCore.Models.League+Division", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DivisionNumber")
                        .HasColumnType("int");

                    b.Property<string>("link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Division");
                });

            modelBuilder.Entity("Treehouse.AspNetCore.Models.League+Team2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DivisionId")
                        .HasColumnType("int");

                    b.Property<int>("GamesPlayed")
                        .HasColumnType("int");

                    b.Property<string>("LocationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Points")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VenueId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.HasIndex("VenueId");

                    b.ToTable("Team2");
                });

            modelBuilder.Entity("Treehouse.AspNetCore.Models.League+Venue", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Venue");
                });

            modelBuilder.Entity("Treehouse.AspNetCore.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApiNr")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Skill")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("Treehouse.AspNetCore.Models.Player2+Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApiNr")
                        .HasColumnType("int");

                    b.Property<string>("fullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("link")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Treehouse.AspNetCore.Models.Player2+Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("abbreviation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("Treehouse.AspNetCore.Models.Player2+Rootobject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("link")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Treehouse.AspNetCore.Models.Player2+Roster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PositionId")
                        .HasColumnType("int");

                    b.Property<int?>("RootobjectId")
                        .HasColumnType("int");

                    b.Property<string>("jerseyNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("personId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.HasIndex("RootobjectId");

                    b.HasIndex("personId");

                    b.ToTable("Roster");
                });

            modelBuilder.Entity("Treehouse.AspNetCore.Models.Token", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Token");
                });

            modelBuilder.Entity("Treehouse.AspNetCore.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MongoNr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("__v")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isVerified")
                        .HasColumnType("bit");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Treehouse.AspNetCore.Models.League+Team2", b =>
                {
                    b.HasOne("Treehouse.AspNetCore.Models.League+Division", "Division")
                        .WithMany()
                        .HasForeignKey("DivisionId");

                    b.HasOne("Treehouse.AspNetCore.Models.League+Venue", "Venue")
                        .WithMany()
                        .HasForeignKey("VenueId");
                });

            modelBuilder.Entity("Treehouse.AspNetCore.Models.Player", b =>
                {
                    b.HasOne("Treehouse.AspNetCore.Models.League+Team2", "Team")
                        .WithMany("Roster")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Treehouse.AspNetCore.Models.Player2+Roster", b =>
                {
                    b.HasOne("Treehouse.AspNetCore.Models.Player2+Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId");

                    b.HasOne("Treehouse.AspNetCore.Models.Player2+Rootobject", null)
                        .WithMany("roster")
                        .HasForeignKey("RootobjectId");

                    b.HasOne("Treehouse.AspNetCore.Models.Player2+Person", "person")
                        .WithMany()
                        .HasForeignKey("personId");
                });

            modelBuilder.Entity("Treehouse.AspNetCore.Models.Token", b =>
                {
                    b.HasOne("Treehouse.AspNetCore.Models.User", null)
                        .WithMany("tokens")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
