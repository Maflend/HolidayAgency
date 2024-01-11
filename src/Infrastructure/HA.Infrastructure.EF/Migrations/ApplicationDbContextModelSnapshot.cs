﻿// <auto-generated />
using System;
using System.Collections.Generic;
using HA.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HA.Infrastructure.EF.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "hstore");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HA.Domain.Categories.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("PriceOfHourse")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("HA.Domain.Clients.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("HA.Domain.Files.EventFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CompletedOrderId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("Name")
                        .HasColumnType("uuid");

                    b.Property<string>("OriginalName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompletedOrderId");

                    b.ToTable("EventFiles");
                });

            modelBuilder.Entity("HA.Domain.Orders.BaseOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<double>("CountHours")
                        .HasColumnType("double precision");

                    b.Property<int>("CountPeople")
                        .HasColumnType("integer");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ClientId");

                    b.ToTable("Orders", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseOrder");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("HA.Domain.Orders.CompletedOrder", b =>
                {
                    b.HasBaseType("HA.Domain.Orders.BaseOrder");

                    b.Property<string>("EventPlan")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Dictionary<string, string>>("Peoples")
                        .IsRequired()
                        .HasColumnType("hstore");

                    b.HasDiscriminator().HasValue("CompletedOrder");
                });

            modelBuilder.Entity("HA.Domain.Orders.ConfirmedOrder", b =>
                {
                    b.HasBaseType("HA.Domain.Orders.BaseOrder");

                    b.Property<string>("EventPlan")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Dictionary<string, string>>("Peoples")
                        .IsRequired()
                        .HasColumnType("hstore");

                    b.ToTable("Orders", t =>
                        {
                            t.Property("EventPlan")
                                .HasColumnName("ConfirmedOrder_EventPlan");

                            t.Property("Peoples")
                                .HasColumnName("ConfirmedOrder_Peoples");
                        });

                    b.HasDiscriminator().HasValue("ConfirmedOrder");
                });

            modelBuilder.Entity("HA.Domain.Orders.UnprocessedOrder", b =>
                {
                    b.HasBaseType("HA.Domain.Orders.BaseOrder");

                    b.HasDiscriminator().HasValue("UnprocessedOrder");
                });

            modelBuilder.Entity("HA.Domain.Files.EventFile", b =>
                {
                    b.HasOne("HA.Domain.Orders.CompletedOrder", null)
                        .WithMany("Files")
                        .HasForeignKey("CompletedOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HA.Domain.Orders.BaseOrder", b =>
                {
                    b.HasOne("HA.Domain.Categories.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HA.Domain.Clients.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("HA.Domain.Orders.CompletedOrder", b =>
                {
                    b.Navigation("Files");
                });
#pragma warning restore 612, 618
        }
    }
}
