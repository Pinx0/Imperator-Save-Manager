﻿// <auto-generated />
using System;
using System.ComponentModel.DataAnnotations.Schema;
using ImperatorStats.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ImperatorStats.Migrations
{
    [DbContext(typeof(MySqlContext))]
    partial class MySqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ImperatorSaveParser.Country", b =>
                {
                    b.Property<int>("SaveId")
                        .HasColumnType("int")
                        .HasMaxLength(50);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<double>("AveragedIncome")
                        .HasColumnType("double");

                    b.Property<double>("Centralization")
                        .HasColumnType("double");

                    b.Property<double>("CurrentIncome")
                        .HasColumnType("double");

                    b.Property<double>("EstimatedMonthlyIncome")
                        .HasColumnType("double");

                    b.Property<string>("FlagTag")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ForeignReligionPops")
                        .HasColumnType("int");

                    b.Property<string>("HistoricalTag")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("LastBattleWon")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("LastWar")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Legitimacy")
                        .HasColumnType("double");

                    b.Property<int>("LoyalCohorts")
                        .HasColumnType("int");

                    b.Property<int>("LoyalPops")
                        .HasColumnType("int");

                    b.Property<double>("MaxManpower")
                        .HasColumnType("double");

                    b.Property<double>("MonthlyManpower")
                        .HasColumnType("double");

                    b.Property<double>("ReligiousUnity")
                        .HasColumnType("double");

                    b.Property<int>("StartingPopulation")
                        .HasColumnType("int");

                    b.Property<string>("Tag")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("TotalCohorts")
                        .HasColumnType("int");

                    b.Property<int>("TotalPopulation")
                        .HasColumnType("int");

                    b.Property<double>("TotalPowerBase")
                        .HasColumnType("double");

                    b.HasKey("SaveId", "CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("ImperatorSaveParser.CountryCurrencyData", b =>
                {
                    b.Property<int>("SaveId")
                        .HasColumnType("int")
                        .HasMaxLength(50);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<double>("AggressiveExpansion")
                        .HasColumnType("double");

                    b.Property<double>("Gold")
                        .HasColumnType("double");

                    b.Property<double>("Manpower")
                        .HasColumnType("double");

                    b.Property<double>("MilitaryExperience")
                        .HasColumnType("double");

                    b.Property<double>("PoliticalInfluence")
                        .HasColumnType("double");

                    b.Property<double>("Stability")
                        .HasColumnType("double");

                    b.Property<double>("Tyranny")
                        .HasColumnType("double");

                    b.Property<double>("WarExhaustion")
                        .HasColumnType("double");

                    b.HasKey("SaveId", "CountryId");

                    b.ToTable("CountryCurrencyData");
                });

            modelBuilder.Entity("ImperatorSaveParser.CountryEconomy", b =>
                {
                    b.Property<int>("SaveId")
                        .HasColumnType("int")
                        .HasMaxLength(50);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<double>("LastMonthIncome")
                        .HasColumnType("double");

                    b.HasKey("SaveId", "CountryId");

                    b.ToTable("CountryEconomy");
                });

            modelBuilder.Entity("ImperatorSaveParser.CountryEconomyTelemetry", b =>
                {
                    b.Property<int>("SaveId")
                        .HasColumnType("int")
                        .HasMaxLength(50);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<double>("AggressiveExpansion")
                        .HasColumnType("double");

                    b.Property<double>("Gold")
                        .HasColumnType("double");

                    b.Property<double>("Manpower")
                        .HasColumnType("double");

                    b.Property<double>("MilitaryExperience")
                        .HasColumnType("double");

                    b.Property<double>("PoliticalInfluence")
                        .HasColumnType("double");

                    b.Property<double>("Stability")
                        .HasColumnType("double");

                    b.Property<double>("Tyranny")
                        .HasColumnType("double");

                    b.Property<double>("WarExhaustion")
                        .HasColumnType("double");

                    b.HasKey("SaveId", "CountryId", "Type");

                    b.ToTable("CountryEconomyTelemetry");
                });

            modelBuilder.Entity("ImperatorSaveParser.CountryTechnology", b =>
                {
                    b.Property<int>("SaveId")
                        .HasColumnType("int")
                        .HasMaxLength(50);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<double>("Progress")
                        .HasColumnType("double");

                    b.HasKey("SaveId", "CountryId", "Type");

                    b.ToTable("CountryTechnology");
                });

            modelBuilder.Entity("ImperatorSaveParser.Family", b =>
                {
                    b.Property<int>("SaveId")
                        .HasColumnType("int")
                        .HasMaxLength(50);

                    b.Property<int>("FamilyId")
                        .HasColumnType("int");

                    b.Property<string>("Key")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("SaveId", "FamilyId");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("ImperatorSaveParser.Save", b =>
                {
                    b.Property<int>("SaveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasMaxLength(50);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SaveKey")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("SaveId")
                        .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);

                    b.ToTable("Saves");
                });

            modelBuilder.Entity("ImperatorSaveParser.Country", b =>
                {
                    b.HasOne("ImperatorSaveParser.Save", "Save")
                        .WithMany()
                        .HasForeignKey("SaveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ImperatorSaveParser.CountryCurrencyData", b =>
                {
                    b.HasOne("ImperatorSaveParser.Country", "Country")
                        .WithOne("CurrencyData")
                        .HasForeignKey("ImperatorSaveParser.CountryCurrencyData", "SaveId", "CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ImperatorSaveParser.CountryEconomy", b =>
                {
                    b.HasOne("ImperatorSaveParser.Country", "Country")
                        .WithOne("Economy")
                        .HasForeignKey("ImperatorSaveParser.CountryEconomy", "SaveId", "CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ImperatorSaveParser.CountryEconomyTelemetry", b =>
                {
                    b.HasOne("ImperatorSaveParser.CountryEconomy", "CountryEconomy")
                        .WithMany("Telemetries")
                        .HasForeignKey("SaveId", "CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ImperatorSaveParser.CountryTechnology", b =>
                {
                    b.HasOne("ImperatorSaveParser.Country", "Country")
                        .WithMany("Technologies")
                        .HasForeignKey("SaveId", "CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ImperatorSaveParser.Family", b =>
                {
                    b.HasOne("ImperatorSaveParser.Save", "Save")
                        .WithMany()
                        .HasForeignKey("SaveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
