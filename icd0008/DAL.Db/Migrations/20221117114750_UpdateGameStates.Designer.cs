﻿// <auto-generated />
using System;
using DAL.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Db.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221117114750_UpdateGameStates")]
    partial class UpdateGameStates
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Domain.Db.CheckersGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CheckersOptionsId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("GameOverAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("GamePlayer1Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GamePlayer2Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameType")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GameWonByPlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CheckersOptionsId");

                    b.HasIndex("GamePlayer1Id");

                    b.HasIndex("GamePlayer2Id");

                    b.HasIndex("GameWonByPlayerId");

                    b.ToTable("CheckersGames");
                });

            modelBuilder.Entity("Domain.Db.CheckersOptions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<short>("BoardHeight")
                        .HasColumnType("INTEGER");

                    b.Property<short>("BoardWidth")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("MandatoryTake")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("QueensHaveOpMoves")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("WhitesFirst")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("CheckersOptions");
                });

            modelBuilder.Entity("Domain.Db.GameState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CheckersGameId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("SerializedGameState")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CheckersGameId");

                    b.ToTable("GameStates");
                });

            modelBuilder.Entity("Domain.Db.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<int>("PlayerType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlayerName")
                        .IsUnique();

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Domain.Db.CheckersGame", b =>
                {
                    b.HasOne("Domain.Db.CheckersOptions", "CheckersOptions")
                        .WithMany("OthelloGames")
                        .HasForeignKey("CheckersOptionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Db.Player", "GamePlayer1")
                        .WithMany("GamesAsPlayedP1")
                        .HasForeignKey("GamePlayer1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Db.Player", "GamePlayer2")
                        .WithMany("GamesAsPlayedP2")
                        .HasForeignKey("GamePlayer2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Db.Player", "GameWonByPlayer")
                        .WithMany()
                        .HasForeignKey("GameWonByPlayerId");

                    b.Navigation("CheckersOptions");

                    b.Navigation("GamePlayer1");

                    b.Navigation("GamePlayer2");

                    b.Navigation("GameWonByPlayer");
                });

            modelBuilder.Entity("Domain.Db.GameState", b =>
                {
                    b.HasOne("Domain.Db.CheckersGame", "CheckersGame")
                        .WithMany("GameStates")
                        .HasForeignKey("CheckersGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CheckersGame");
                });

            modelBuilder.Entity("Domain.Db.CheckersGame", b =>
                {
                    b.Navigation("GameStates");
                });

            modelBuilder.Entity("Domain.Db.CheckersOptions", b =>
                {
                    b.Navigation("OthelloGames");
                });

            modelBuilder.Entity("Domain.Db.Player", b =>
                {
                    b.Navigation("GamesAsPlayedP1");

                    b.Navigation("GamesAsPlayedP2");
                });
#pragma warning restore 612, 618
        }
    }
}
