﻿// <auto-generated />
using System;
using BAS24.Product.Infrastructure.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BAS24.Product.Infrastructure.Migrations
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

            modelBuilder.Entity("BAS24.Product.Infrastructure.Postgres.Currency.CurrencyTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean")
                        .HasColumnName("active");

                    b.Property<bool>("BaseCurrency")
                        .HasColumnType("boolean")
                        .HasColumnName("base_currency");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("LocalCurrency")
                        .HasColumnType("boolean")
                        .HasColumnName("local_currency");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uuid")
                        .HasColumnName("store_id");

                    b.Property<Guid>("StoreOwnerId")
                        .HasColumnType("uuid")
                        .HasColumnName("store_owner_id");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("symbol");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("currencies");
                });

            modelBuilder.Entity("BAS24.Product.Infrastructure.Postgres.ExchangeRate.ExchangeRateTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<decimal>("BaseSetRate")
                        .HasColumnType("numeric")
                        .HasColumnName("base_set_rate");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid>("CurrencyId")
                        .HasColumnType("uuid")
                        .HasColumnName("currency_id");

                    b.Property<decimal>("LocalSetRate")
                        .HasColumnType("numeric")
                        .HasColumnName("local_set_rate");

                    b.Property<decimal>("Rate")
                        .HasColumnType("numeric")
                        .HasColumnName("rate");

                    b.Property<decimal>("SetRate")
                        .HasColumnType("numeric")
                        .HasColumnName("set_rate");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId")
                        .IsUnique();

                    b.ToTable("exchange_rate");
                });

            modelBuilder.Entity("BAS24.Product.Infrastructure.Postgres.Store.StoreMemberTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("LocalStoreId")
                        .HasColumnType("uuid")
                        .HasColumnName("local_store_id");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uuid")
                        .HasColumnName("member_id");

                    b.Property<int>("Permission")
                        .HasColumnType("integer")
                        .HasColumnName("permission");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uuid")
                        .HasColumnName("store_id");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("store_members");
                });

            modelBuilder.Entity("BAS24.Product.Infrastructure.Postgres.Store.StoreTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean")
                        .HasColumnName("active");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid")
                        .HasColumnName("owner_id");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uuid")
                        .HasColumnName("store_id");

                    b.HasKey("Id");

                    b.ToTable("stores");
                });

            modelBuilder.Entity("BAS24.Product.Infrastructure.Postgres.ExchangeRate.ExchangeRateTable", b =>
                {
                    b.HasOne("BAS24.Product.Infrastructure.Postgres.Currency.CurrencyTable", "Currency")
                        .WithOne()
                        .HasForeignKey("BAS24.Product.Infrastructure.Postgres.ExchangeRate.ExchangeRateTable", "CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("BAS24.Product.Infrastructure.Postgres.Store.StoreMemberTable", b =>
                {
                    b.HasOne("BAS24.Product.Infrastructure.Postgres.Store.StoreTable", "Store")
                        .WithMany("StoreMembers")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("BAS24.Product.Infrastructure.Postgres.Store.StoreTable", b =>
                {
                    b.Navigation("StoreMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
