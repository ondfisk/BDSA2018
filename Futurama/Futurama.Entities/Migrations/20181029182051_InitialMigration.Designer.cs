﻿// <auto-generated />
using System;
using Futurama.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Futurama.Entities.Migrations
{
    [DbContext(typeof(FuturamaContext))]
    [Migration("20181029182051_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Futurama.Entities.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("Futurama.Entities.Character", b =>
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
                });

            modelBuilder.Entity("Futurama.Entities.Episode", b =>
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

            modelBuilder.Entity("Futurama.Entities.EpisodeCharacter", b =>
                {
                    b.Property<int>("EpisodeId");

                    b.Property<int>("CharacterId");

                    b.HasKey("EpisodeId", "CharacterId");

                    b.HasIndex("CharacterId");

                    b.ToTable("EpisodeCharacters");
                });

            modelBuilder.Entity("Futurama.Entities.Character", b =>
                {
                    b.HasOne("Futurama.Entities.Actor", "Actor")
                        .WithMany("Characters")
                        .HasForeignKey("ActorId");
                });

            modelBuilder.Entity("Futurama.Entities.EpisodeCharacter", b =>
                {
                    b.HasOne("Futurama.Entities.Character", "Characters")
                        .WithMany("EpisodeCharacters")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Futurama.Entities.Episode", "Episode")
                        .WithMany("EpisodeCharacters")
                        .HasForeignKey("EpisodeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
