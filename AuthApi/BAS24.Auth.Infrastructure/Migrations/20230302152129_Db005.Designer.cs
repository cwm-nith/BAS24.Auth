﻿// <auto-generated />
using System;
using BAS24.Auth.Infrastructure.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BAS24.Auth.Infrastructure.Migrations
{
    [DbContext(typeof(PostgresDbContext))]
    [Migration("20230302152129_Db005")]
    partial class Db005
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BAS24.Auth.Infrastructure.Postgres.Media.MediaTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("file_name");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("link");

                    b.Property<Guid>("MasterId")
                        .HasColumnType("uuid")
                        .HasColumnName("master_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("MasterId")
                        .IsUnique();

                    b.ToTable("medias");
                });

            modelBuilder.Entity("BAS24.Auth.Infrastructure.Postgres.SocialLink.SocialLinkTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("social_links");
                });

            modelBuilder.Entity("BAS24.Auth.Infrastructure.Postgres.SocialLink.SocialUserLinkTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("link");

                    b.Property<Guid>("SocialLinkId")
                        .HasColumnType("uuid")
                        .HasColumnName("social_link_id");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uuid")
                        .HasColumnName("store_id");

                    b.Property<Guid>("StoreOwnerId")
                        .HasColumnType("uuid")
                        .HasColumnName("store_owner_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("SocialLinkId");

                    b.HasIndex("StoreId");

                    b.ToTable("social_user_links");
                });

            modelBuilder.Entity("BAS24.Auth.Infrastructure.Postgres.Store.StoreMemberTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uuid")
                        .HasColumnName("member_id");

                    b.Property<int>("Permission")
                        .HasColumnType("integer")
                        .HasColumnName("permission");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uuid")
                        .HasColumnName("store_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.HasIndex("UserId");

                    b.ToTable("store_members");
                });

            modelBuilder.Entity("BAS24.Auth.Infrastructure.Postgres.Store.StoreTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean")
                        .HasColumnName("active");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<Guid[]>("CategoryIds")
                        .IsRequired()
                        .HasColumnType("uuid[]")
                        .HasColumnName("categoryIds");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string[]>("Emails")
                        .IsRequired()
                        .HasColumnType("text[]")
                        .HasColumnName("emails");

                    b.Property<DateTime>("EndWorkingTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_working_time");

                    b.Property<string[]>("KeyWords")
                        .IsRequired()
                        .HasColumnType("text[]")
                        .HasColumnName("key_words");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid")
                        .HasColumnName("owner_id");

                    b.Property<string[]>("Phones")
                        .IsRequired()
                        .HasColumnType("text[]")
                        .HasColumnName("phones");

                    b.Property<int>("PriceRating")
                        .HasColumnType("integer")
                        .HasColumnName("price_rating");

                    b.Property<DateTime>("StartWorkingTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_working_time");

                    b.Property<int>("StoreRating")
                        .HasColumnType("integer")
                        .HasColumnName("store_rating");

                    b.Property<string[]>("Tags")
                        .IsRequired()
                        .HasColumnType("text[]")
                        .HasColumnName("tags");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("stores");
                });

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

                    b.ToTable("users");
                });

            modelBuilder.Entity("BAS24.Auth.Infrastructure.Postgres.Media.MediaTable", b =>
                {
                    b.HasOne("BAS24.Auth.Infrastructure.Postgres.SocialLink.SocialLinkTable", null)
                        .WithMany("Medias")
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BAS24.Auth.Infrastructure.Postgres.Store.StoreTable", null)
                        .WithMany("Medias")
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BAS24.Auth.Infrastructure.Postgres.User.UserTable", null)
                        .WithOne("Media")
                        .HasForeignKey("BAS24.Auth.Infrastructure.Postgres.Media.MediaTable", "MasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BAS24.Auth.Infrastructure.Postgres.SocialLink.SocialUserLinkTable", b =>
                {
                    b.HasOne("BAS24.Auth.Infrastructure.Postgres.SocialLink.SocialLinkTable", "SocialLink")
                        .WithMany("SocialUserLinks")
                        .HasForeignKey("SocialLinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BAS24.Auth.Infrastructure.Postgres.Store.StoreTable", "Store")
                        .WithMany("SocialUserLinks")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SocialLink");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("BAS24.Auth.Infrastructure.Postgres.Store.StoreMemberTable", b =>
                {
                    b.HasOne("BAS24.Auth.Infrastructure.Postgres.Store.StoreTable", "Store")
                        .WithMany("StoreMembers")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BAS24.Auth.Infrastructure.Postgres.User.UserTable", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Store");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BAS24.Auth.Infrastructure.Postgres.Store.StoreTable", b =>
                {
                    b.HasOne("BAS24.Auth.Infrastructure.Postgres.User.UserTable", "Owner")
                        .WithMany("Stores")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("BAS24.Auth.Infrastructure.Postgres.SocialLink.SocialLinkTable", b =>
                {
                    b.Navigation("Medias");

                    b.Navigation("SocialUserLinks");
                });

            modelBuilder.Entity("BAS24.Auth.Infrastructure.Postgres.Store.StoreTable", b =>
                {
                    b.Navigation("Medias");

                    b.Navigation("SocialUserLinks");

                    b.Navigation("StoreMembers");
                });

            modelBuilder.Entity("BAS24.Auth.Infrastructure.Postgres.User.UserTable", b =>
                {
                    b.Navigation("Media");

                    b.Navigation("Stores");
                });
#pragma warning restore 612, 618
        }
    }
}
