﻿// <auto-generated />
using System;
using System.ComponentModel.DataAnnotations.Schema;
using ImperatorStats.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ImperatorStats.Migrations
{
    [DbContext(typeof(ImperatorContext))]
    [Migration("20200203213347_Improved-ProvinceNames")]
    partial class ImprovedProvinceNames
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Imperator.Save.Army", b =>
                {
                    b.Property<int>("SaveId")
                        .HasColumnType("int");

                    b.Property<int>("ArmyId")
                        .HasColumnType("int");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<double>("Experience")
                        .HasColumnType("double");

                    b.Property<double>("Morale")
                        .HasColumnType("double");

                    b.Property<double>("Strength")
                        .HasColumnType("double");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("SaveId", "ArmyId");

                    b.HasIndex("SaveId", "CountryId");

                    b.ToTable("Army");
                });

            modelBuilder.Entity("Imperator.Save.Country", b =>
                {
                    b.Property<int>("SaveId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<double>("AccumulatedAggressiveExpansion")
                        .HasColumnType("double");

                    b.Property<double>("AccumulatedGold")
                        .HasColumnType("double");

                    b.Property<double>("AccumulatedManpower")
                        .HasColumnType("double");

                    b.Property<double>("AccumulatedMilitaryExperience")
                        .HasColumnType("double");

                    b.Property<double>("AccumulatedPoliticalInfluence")
                        .HasColumnType("double");

                    b.Property<double>("AccumulatedStability")
                        .HasColumnType("double");

                    b.Property<double>("AccumulatedTyranny")
                        .HasColumnType("double");

                    b.Property<double>("AccumulatedWarExhaustion")
                        .HasColumnType("double");

                    b.Property<double>("AggressiveExpansion")
                        .HasColumnType("double");

                    b.Property<double>("AveragedIncome")
                        .HasColumnType("double");

                    b.Property<double>("Centralization")
                        .HasColumnType("double");

                    b.Property<string>("CountryType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("CurrentIncome")
                        .HasColumnType("double");

                    b.Property<double>("EstimatedMonthlyIncome")
                        .HasColumnType("double");

                    b.Property<string>("FlagTag")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ForeignReligionPops")
                        .HasColumnType("int");

                    b.Property<double>("Gold")
                        .HasColumnType("double");

                    b.Property<string>("HistoricalTag")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("LastBattleWon")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("LastMonthExpense")
                        .HasColumnType("double");

                    b.Property<double>("LastMonthIncome")
                        .HasColumnType("double");

                    b.Property<DateTime>("LastWar")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Legitimacy")
                        .HasColumnType("double");

                    b.Property<int>("LoyalCohorts")
                        .HasColumnType("int");

                    b.Property<int>("LoyalPops")
                        .HasColumnType("int");

                    b.Property<string>("MainReligionId")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4");

                    b.Property<double>("Manpower")
                        .HasColumnType("double");

                    b.Property<double>("MaxManpower")
                        .HasColumnType("double");

                    b.Property<double>("MilitaryExperience")
                        .HasColumnType("double");

                    b.Property<double>("MonthlyManpower")
                        .HasColumnType("double");

                    b.Property<double>("PoliticalInfluence")
                        .HasColumnType("double");

                    b.Property<string>("PrimaryCultureId")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4");

                    b.Property<double>("ReligiousUnity")
                        .HasColumnType("double");

                    b.Property<double>("SpentAggressiveExpansion")
                        .HasColumnType("double");

                    b.Property<double>("SpentGold")
                        .HasColumnType("double");

                    b.Property<double>("SpentManpower")
                        .HasColumnType("double");

                    b.Property<double>("SpentMilitaryExperience")
                        .HasColumnType("double");

                    b.Property<double>("SpentPoliticalInfluence")
                        .HasColumnType("double");

                    b.Property<double>("SpentStability")
                        .HasColumnType("double");

                    b.Property<double>("SpentTyranny")
                        .HasColumnType("double");

                    b.Property<double>("SpentWarExhaustion")
                        .HasColumnType("double");

                    b.Property<double>("Stability")
                        .HasColumnType("double");

                    b.Property<int>("StartingPopulation")
                        .HasColumnType("int");

                    b.Property<string>("Tag")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<int>("TotalCohorts")
                        .HasColumnType("int");

                    b.Property<int>("TotalInventions")
                        .HasColumnType("int");

                    b.Property<int>("TotalPopulation")
                        .HasColumnType("int");

                    b.Property<double>("TotalPowerBase")
                        .HasColumnType("double");

                    b.Property<double>("Tyranny")
                        .HasColumnType("double");

                    b.Property<double>("WarExhaustion")
                        .HasColumnType("double");

                    b.HasKey("SaveId", "CountryId");

                    b.HasIndex("MainReligionId");

                    b.HasIndex("PrimaryCultureId");

                    b.HasIndex("Tag");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Imperator.Save.CountryIdea", b =>
                {
                    b.Property<int>("SaveId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.HasKey("SaveId", "CountryId", "Name");

                    b.ToTable("CountryIdeas");
                });

            modelBuilder.Entity("Imperator.Save.CountryName", b =>
                {
                    b.Property<string>("CountryTag")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("CountryTag");

                    b.ToTable("CountryNames");
                });

            modelBuilder.Entity("Imperator.Save.CountryPlayer", b =>
                {
                    b.Property<int>("SaveId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("PlayerName")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.HasKey("SaveId", "CountryId", "PlayerName");

                    b.ToTable("CountryPlayers");
                });

            modelBuilder.Entity("Imperator.Save.CountryTechnology", b =>
                {
                    b.Property<int>("SaveId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<double>("Progress")
                        .HasColumnType("double");

                    b.HasKey("SaveId", "CountryId", "Type");

                    b.ToTable("CountryTechnologies");
                });

            modelBuilder.Entity("Imperator.Save.Culture", b =>
                {
                    b.Property<string>("CultureId")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("CultureId");

                    b.ToTable("Cultures");
                });

            modelBuilder.Entity("Imperator.Save.Family", b =>
                {
                    b.Property<int>("SaveId")
                        .HasColumnType("int");

                    b.Property<int>("FamilyId")
                        .HasColumnType("int");

                    b.Property<string>("Culture")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Key")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<double>("Prestige")
                        .HasColumnType("double");

                    b.HasKey("SaveId", "FamilyId");

                    b.HasIndex("SaveId", "OwnerId");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("Imperator.Save.Population", b =>
                {
                    b.Property<int>("SaveId")
                        .HasColumnType("int");

                    b.Property<int>("PopId")
                        .HasColumnType("int");

                    b.Property<string>("CultureId")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<int?>("ProvinceId")
                        .HasColumnType("int");

                    b.Property<string>("ReligionId")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("SaveId", "PopId");

                    b.HasIndex("CultureId");

                    b.HasIndex("ReligionId");

                    b.HasIndex("SaveId", "ProvinceId");

                    b.ToTable("Pops");
                });

            modelBuilder.Entity("Imperator.Save.Province", b =>
                {
                    b.Property<int>("SaveId")
                        .HasColumnType("int");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.Property<double>("CivilizationValue")
                        .HasColumnType("double");

                    b.Property<int?>("ControllerId")
                        .HasColumnType("int");

                    b.Property<string>("CultureId")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<DateTime>("LastControllerChange")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("LastOwnerChange")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("OriginalCultureId")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("OriginalReligionId")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int?>("PreviousControllerId")
                        .HasColumnType("int");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<string>("ReligionId")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("TradeGood")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("SaveId", "ProvinceId");

                    b.HasIndex("CultureId");

                    b.HasIndex("OriginalCultureId");

                    b.HasIndex("OriginalReligionId");

                    b.HasIndex("ProvinceId");

                    b.HasIndex("ReligionId");

                    b.HasIndex("SaveId", "ControllerId");

                    b.HasIndex("SaveId", "OwnerId");

                    b.HasIndex("SaveId", "PreviousControllerId");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("Imperator.Save.ProvinceName", b =>
                {
                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ProvinceId");

                    b.ToTable("ProvinceNames");
                });

            modelBuilder.Entity("Imperator.Save.Religion", b =>
                {
                    b.Property<string>("ReligionId")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ReligionId");

                    b.ToTable("Religions");
                });

            modelBuilder.Entity("Imperator.Save.Save", b =>
                {
                    b.Property<int>("SaveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SaveKey")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("SaveId")
                        .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);

                    b.ToTable("Saves");
                });

            modelBuilder.Entity("Imperator.Save.Army", b =>
                {
                    b.HasOne("Imperator.Save.Save", "Save")
                        .WithMany()
                        .HasForeignKey("SaveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Imperator.Save.Country", "Country")
                        .WithMany("Armies")
                        .HasForeignKey("SaveId", "CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Imperator.Save.Country", b =>
                {
                    b.HasOne("Imperator.Save.Religion", "MainReligion")
                        .WithMany()
                        .HasForeignKey("MainReligionId");

                    b.HasOne("Imperator.Save.Culture", "PrimaryCulture")
                        .WithMany()
                        .HasForeignKey("PrimaryCultureId");

                    b.HasOne("Imperator.Save.Save", "Save")
                        .WithMany("Countries")
                        .HasForeignKey("SaveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Imperator.Save.CountryName", "Name")
                        .WithMany("Countries")
                        .HasForeignKey("Tag");
                });

            modelBuilder.Entity("Imperator.Save.CountryIdea", b =>
                {
                    b.HasOne("Imperator.Save.Country", "Country")
                        .WithMany("Ideas")
                        .HasForeignKey("SaveId", "CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Imperator.Save.CountryPlayer", b =>
                {
                    b.HasOne("Imperator.Save.Country", "Country")
                        .WithMany("Players")
                        .HasForeignKey("SaveId", "CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Imperator.Save.CountryTechnology", b =>
                {
                    b.HasOne("Imperator.Save.Country", "Country")
                        .WithMany("Technologies")
                        .HasForeignKey("SaveId", "CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Imperator.Save.Family", b =>
                {
                    b.HasOne("Imperator.Save.Save", "Save")
                        .WithMany("Families")
                        .HasForeignKey("SaveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Imperator.Save.Country", "Country")
                        .WithMany("Families")
                        .HasForeignKey("SaveId", "OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Imperator.Save.Population", b =>
                {
                    b.HasOne("Imperator.Save.Culture", "Culture")
                        .WithMany("Pops")
                        .HasForeignKey("CultureId");

                    b.HasOne("Imperator.Save.Religion", "Religion")
                        .WithMany("Pops")
                        .HasForeignKey("ReligionId");

                    b.HasOne("Imperator.Save.Save", "Save")
                        .WithMany("Pops")
                        .HasForeignKey("SaveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Imperator.Save.Province", "Province")
                        .WithMany("Pops")
                        .HasForeignKey("SaveId", "ProvinceId");
                });

            modelBuilder.Entity("Imperator.Save.Province", b =>
                {
                    b.HasOne("Imperator.Save.Culture", "Culture")
                        .WithMany()
                        .HasForeignKey("CultureId");

                    b.HasOne("Imperator.Save.Culture", "OriginalCulture")
                        .WithMany()
                        .HasForeignKey("OriginalCultureId");

                    b.HasOne("Imperator.Save.Religion", "OriginalReligion")
                        .WithMany()
                        .HasForeignKey("OriginalReligionId");

                    b.HasOne("Imperator.Save.ProvinceName", "Name")
                        .WithMany("Provinces")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Imperator.Save.Religion", "Religion")
                        .WithMany()
                        .HasForeignKey("ReligionId");

                    b.HasOne("Imperator.Save.Save", "Save")
                        .WithMany("Provinces")
                        .HasForeignKey("SaveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Imperator.Save.Country", "Controller")
                        .WithMany("ProvincesControlled")
                        .HasForeignKey("SaveId", "ControllerId");

                    b.HasOne("Imperator.Save.Country", "Owner")
                        .WithMany("Provinces")
                        .HasForeignKey("SaveId", "OwnerId");

                    b.HasOne("Imperator.Save.Country", "PreviousController")
                        .WithMany("ProvincesPreviouslyControlled")
                        .HasForeignKey("SaveId", "PreviousControllerId");
                });
#pragma warning restore 612, 618
        }
    }
}
