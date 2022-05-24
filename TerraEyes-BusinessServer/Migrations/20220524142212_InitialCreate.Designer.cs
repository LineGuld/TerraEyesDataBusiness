﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TerraEyes_BusinessServer.UserRepository;

namespace TerraEyes_BusinessServer.Migrations
{
    [DbContext(typeof(Repository))]
    [Migration("20220524142212_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("TerraEyes_BusinessServer.UserRepository.Connection", b =>
                {
                    b.Property<string>("ConnectionId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Connected")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserAgent")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("ConnectionId");

                    b.HasIndex("UserId");

                    b.ToTable("Connections");
                });

            modelBuilder.Entity("TerraEyes_BusinessServer.UserRepository.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TerraEyes_BusinessServer.UserRepository.UserGroups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserType")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("UserUserGroups", b =>
                {
                    b.Property<int>("GroupsId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UsersUserId")
                        .HasColumnType("TEXT");

                    b.HasKey("GroupsId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("UserUserGroups");
                });

            modelBuilder.Entity("TerraEyes_BusinessServer.UserRepository.Connection", b =>
                {
                    b.HasOne("TerraEyes_BusinessServer.UserRepository.User", null)
                        .WithMany("Connections")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("UserUserGroups", b =>
                {
                    b.HasOne("TerraEyes_BusinessServer.UserRepository.UserGroups", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TerraEyes_BusinessServer.UserRepository.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TerraEyes_BusinessServer.UserRepository.User", b =>
                {
                    b.Navigation("Connections");
                });
#pragma warning restore 612, 618
        }
    }
}