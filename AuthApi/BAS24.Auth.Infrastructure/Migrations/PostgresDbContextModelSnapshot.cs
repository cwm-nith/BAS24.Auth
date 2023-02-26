﻿// <auto-generated />
using System;
using BAS24.Auth.Infrastructure.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BAS24.Auth.Infrastructure.Postgres
{
    [DbContext(typeof(PostgresDbContext))]
    partial class PostgresDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BAS24.Auth.Infrastructure.Postgres.User.UserTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool?>("Active")
                        .HasColumnType("boolean")
                        .HasColumnName("active");

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("Code")
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Fullname")
                        .HasColumnType("text")
                        .HasColumnName("fullname");

                    b.Property<bool>("IsApprove")
                        .HasColumnType("boolean")
                        .HasColumnName("is_approve");

                    b.Property<bool?>("IsLock")
                        .HasColumnType("boolean")
                        .HasColumnName("is_lock");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string[]>("Phones")
                        .HasColumnType("text[]")
                        .HasColumnName("phones");

                    b.Property<string>("RegionName")
                        .HasColumnType("text")
                        .HasColumnName("region_name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}