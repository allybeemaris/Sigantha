﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sigantha.Data.Contexts;

namespace Sigantha.Data.Migrations
{
    [DbContext(typeof(SiganthaContext))]
    partial class SiganthaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("Sigantha.Data.Entities.Era", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("End")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Start")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TimelineId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.HasIndex("TimelineId");

                    b.ToTable("Eras");
                });

            modelBuilder.Entity("Sigantha.Data.Entities.EraLegacy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EraId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("LegacyId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EraId");

                    b.HasIndex("LegacyId");

                    b.ToTable("EraLegacies");
                });

            modelBuilder.Entity("Sigantha.Data.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("End")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("EraId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Start")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TimelineId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EraId");

                    b.HasIndex("Name");

                    b.HasIndex("TimelineId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Sigantha.Data.Entities.EventLegacy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EventId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("LegacyId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("LegacyId");

                    b.ToTable("EventLegacies");
                });

            modelBuilder.Entity("Sigantha.Data.Entities.Legacy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SymbolPath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TimelineId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.HasIndex("TimelineId");

                    b.ToTable("Legacies");
                });

            modelBuilder.Entity("Sigantha.Data.Entities.Scene", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("End")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("EventId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Start")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TimelineId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("Name");

                    b.HasIndex("TimelineId");

                    b.ToTable("Scenes");
                });

            modelBuilder.Entity("Sigantha.Data.Entities.SceneLegacy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("LegacyId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SceneId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LegacyId");

                    b.HasIndex("SceneId");

                    b.ToTable("SceneLegacies");
                });

            modelBuilder.Entity("Sigantha.Data.Entities.Timeline", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Timelines");
                });

            modelBuilder.Entity("Sigantha.Data.Entities.Era", b =>
                {
                    b.HasOne("Sigantha.Data.Entities.Timeline", "Timeline")
                        .WithMany("Eras")
                        .HasForeignKey("TimelineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sigantha.Data.Entities.EraLegacy", b =>
                {
                    b.HasOne("Sigantha.Data.Entities.Era", "Era")
                        .WithMany("EraLegacies")
                        .HasForeignKey("EraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sigantha.Data.Entities.Legacy", "Legacy")
                        .WithMany("EraLegacies")
                        .HasForeignKey("LegacyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sigantha.Data.Entities.Event", b =>
                {
                    b.HasOne("Sigantha.Data.Entities.Era", "Era")
                        .WithMany("Events")
                        .HasForeignKey("EraId");

                    b.HasOne("Sigantha.Data.Entities.Timeline", "Timeline")
                        .WithMany("Events")
                        .HasForeignKey("TimelineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sigantha.Data.Entities.EventLegacy", b =>
                {
                    b.HasOne("Sigantha.Data.Entities.Event", "Event")
                        .WithMany("EventLegacies")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sigantha.Data.Entities.Legacy", "Legacy")
                        .WithMany("EventLegacies")
                        .HasForeignKey("LegacyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sigantha.Data.Entities.Legacy", b =>
                {
                    b.HasOne("Sigantha.Data.Entities.Timeline", "Timeline")
                        .WithMany("Legacies")
                        .HasForeignKey("TimelineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sigantha.Data.Entities.Scene", b =>
                {
                    b.HasOne("Sigantha.Data.Entities.Event", "Event")
                        .WithMany("Scenes")
                        .HasForeignKey("EventId");

                    b.HasOne("Sigantha.Data.Entities.Timeline", "Timeline")
                        .WithMany("Scenes")
                        .HasForeignKey("TimelineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sigantha.Data.Entities.SceneLegacy", b =>
                {
                    b.HasOne("Sigantha.Data.Entities.Legacy", "Legacy")
                        .WithMany("SceneLegacies")
                        .HasForeignKey("LegacyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sigantha.Data.Entities.Scene", "Scene")
                        .WithMany("SceneLegacies")
                        .HasForeignKey("SceneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
