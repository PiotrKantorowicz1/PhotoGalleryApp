﻿// <auto-generated />
using Gallery.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Gallery.Infrastructure.Migrations
{
    [DbContext(typeof(GalleryContext))]
    partial class GalleryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gallery.Data.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("Gallery.Data.Models.Error", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Message");

                    b.Property<string>("StackTrace");

                    b.HasKey("Id");

                    b.ToTable("Error");
                });

            modelBuilder.Entity("Gallery.Data.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AlbumId");

                    b.Property<DateTime>("DateUploaded");

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.Property<string>("Uri");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("Gallery.Data.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Gallery.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("IsLocked");

                    b.Property<DateTimeOffset?>("LastLoggedIn");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Gallery.Data.Models.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.Property<int>("Id");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Gallery.Data.Models.UserToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("AccessTokenExpiresDateTime");

                    b.Property<string>("AccessTokenHash");

                    b.Property<DateTimeOffset>("RefreshTokenExpiresDateTime");

                    b.Property<string>("RefreshTokenIdHash")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("RefreshTokenIdHashSource")
                        .HasMaxLength(450);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserToken");
                });

            modelBuilder.Entity("Gallery.Data.Models.Photo", b =>
                {
                    b.HasOne("Gallery.Data.Models.Album", "Album")
                        .WithMany("Photos")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Gallery.Data.Models.UserRole", b =>
                {
                    b.HasOne("Gallery.Data.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Gallery.Data.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Gallery.Data.Models.UserToken", b =>
                {
                    b.HasOne("Gallery.Data.Models.User", "User")
                        .WithMany("UserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
