﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using YelpcampNet.Infrastructure.Data;

#nullable disable

namespace YelpcampNet.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220714170705_CreateCampgroundSchema")]
    partial class CreateCampgroundSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("YelpcampNet.ApplicationCore.Entities.Campground", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("HeaderImage")
                        .HasColumnType("text");

                    b.Property<string[]>("SlideshowImages")
                        .HasColumnType("text[]");

                    b.Property<string>("Teaser")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Campgrounds");
                });
#pragma warning restore 612, 618
        }
    }
}