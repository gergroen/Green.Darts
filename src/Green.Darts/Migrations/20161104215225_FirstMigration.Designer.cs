using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Green.Darts.Dao.EntityFrameworkCore;

namespace Green.Darts.Migrations
{
    [DbContext(typeof(DartsDbContext))]
    [Migration("20161104215225_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Green.Darts.Model.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AwayTeamId");

                    b.Property<Guid?>("HomeTeamId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("HomeTeamId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Green.Darts.Model.Leg", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Number");

                    b.Property<Guid?>("SetId");

                    b.HasKey("Id");

                    b.HasIndex("SetId");

                    b.ToTable("Leg");
                });

            modelBuilder.Entity("Green.Darts.Model.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<Guid?>("RoundId");

                    b.Property<Guid?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("RoundId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Green.Darts.Model.Round", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BestOfLegs");

                    b.Property<int>("BestOfSets");

                    b.Property<bool>("DoubleIn");

                    b.Property<bool>("DoubleOut");

                    b.Property<Guid?>("GameId");

                    b.Property<string>("Name");

                    b.Property<int>("Number");

                    b.Property<int>("StartPoints");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Round");
                });

            modelBuilder.Entity("Green.Darts.Model.Set", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Number");

                    b.Property<Guid?>("RoundId");

                    b.HasKey("Id");

                    b.HasIndex("RoundId");

                    b.ToTable("Set");
                });

            modelBuilder.Entity("Green.Darts.Model.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("Green.Darts.Model.Throw", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Number");

                    b.Property<string>("Score");

                    b.Property<Guid?>("TurnId");

                    b.HasKey("Id");

                    b.HasIndex("TurnId");

                    b.ToTable("Throw");
                });

            modelBuilder.Entity("Green.Darts.Model.Turn", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("LegId");

                    b.Property<int>("Number");

                    b.Property<Guid?>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("LegId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Turn");
                });

            modelBuilder.Entity("Green.Darts.Model.Game", b =>
                {
                    b.HasOne("Green.Darts.Model.Team", "AwayTeam")
                        .WithMany()
                        .HasForeignKey("AwayTeamId");

                    b.HasOne("Green.Darts.Model.Team", "HomeTeam")
                        .WithMany()
                        .HasForeignKey("HomeTeamId");
                });

            modelBuilder.Entity("Green.Darts.Model.Leg", b =>
                {
                    b.HasOne("Green.Darts.Model.Set")
                        .WithMany("Legs")
                        .HasForeignKey("SetId");
                });

            modelBuilder.Entity("Green.Darts.Model.Player", b =>
                {
                    b.HasOne("Green.Darts.Model.Round")
                        .WithMany("Players")
                        .HasForeignKey("RoundId");

                    b.HasOne("Green.Darts.Model.Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("Green.Darts.Model.Round", b =>
                {
                    b.HasOne("Green.Darts.Model.Game")
                        .WithMany("Rounds")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("Green.Darts.Model.Set", b =>
                {
                    b.HasOne("Green.Darts.Model.Round")
                        .WithMany("Sets")
                        .HasForeignKey("RoundId");
                });

            modelBuilder.Entity("Green.Darts.Model.Throw", b =>
                {
                    b.HasOne("Green.Darts.Model.Turn")
                        .WithMany("Throws")
                        .HasForeignKey("TurnId");
                });

            modelBuilder.Entity("Green.Darts.Model.Turn", b =>
                {
                    b.HasOne("Green.Darts.Model.Leg")
                        .WithMany("Turns")
                        .HasForeignKey("LegId");

                    b.HasOne("Green.Darts.Model.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");
                });
        }
    }
}
