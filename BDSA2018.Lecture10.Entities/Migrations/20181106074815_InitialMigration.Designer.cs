﻿// <auto-generated />
using System;
using BDSA2018.Lecture10.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BDSA2018.Lecture10.Entities.Migrations
{
    [DbContext(typeof(FuturamaContext))]
    [Migration("20181106074815_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BDSA2018.Lecture10.Entities.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Actors");

                    b.HasData(
                        new { Id = 1, Name = "Billy West" },
                        new { Id = 2, Name = "Katey Sagal" },
                        new { Id = 3, Name = "John DiMaggio" },
                        new { Id = 4, Name = "Lauren Tom" },
                        new { Id = 5, Name = "Phil LaMarr" }
                    );
                });

            modelBuilder.Entity("BDSA2018.Lecture10.Entities.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActorId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Planet")
                        .HasMaxLength(50);

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.ToTable("Characters");

                    b.HasData(
                        new { Id = 1, ActorId = 1, Name = "Philip J. Fry", Planet = "Earth", Species = "Human" },
                        new { Id = 2, ActorId = 2, Name = "Leela Turanga", Planet = "Earth", Species = "Mutant, Human" },
                        new { Id = 3, ActorId = 3, Name = "Bender Bending Rodrique", Planet = "Earth", Species = "Robot" },
                        new { Id = 4, ActorId = 1, Name = "John A. Zoidberg", Planet = "Decapod 10", Species = "Decapodian" },
                        new { Id = 5, ActorId = 4, Name = "Amy Wong", Planet = "Mars", Species = "Human" },
                        new { Id = 6, ActorId = 5, Name = "Hermes Conrad", Planet = "Earth", Species = "Human" },
                        new { Id = 7, ActorId = 1, Name = "Hubert J. Farnsworth", Planet = "Earth", Species = "Human" }
                    );
                });

            modelBuilder.Entity("BDSA2018.Lecture10.Entities.Episode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("FirstAired");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("BDSA2018.Lecture10.Entities.EpisodeCharacter", b =>
                {
                    b.Property<int>("EpisodeId");

                    b.Property<int>("CharacterId");

                    b.HasKey("EpisodeId", "CharacterId");

                    b.HasIndex("CharacterId");

                    b.ToTable("EpisodeCharacters");
                });

            modelBuilder.Entity("BDSA2018.Lecture10.Entities.Character", b =>
                {
                    b.HasOne("BDSA2018.Lecture10.Entities.Actor", "Actor")
                        .WithMany("Characters")
                        .HasForeignKey("ActorId");
                });

            modelBuilder.Entity("BDSA2018.Lecture10.Entities.EpisodeCharacter", b =>
                {
                    b.HasOne("BDSA2018.Lecture10.Entities.Character", "Characters")
                        .WithMany("EpisodeCharacters")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BDSA2018.Lecture10.Entities.Episode", "Episode")
                        .WithMany("EpisodeCharacters")
                        .HasForeignKey("EpisodeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}