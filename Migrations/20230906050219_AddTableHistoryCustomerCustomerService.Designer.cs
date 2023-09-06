﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using appflow.Contexts;

#nullable disable

namespace appflow.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230906050219_AddTableHistoryCustomerCustomerService")]
    partial class AddTableHistoryCustomerCustomerService
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("ColumnFlow", b =>
                {
                    b.Property<int>("ColumnFlowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("userId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ColumnFlowId");

                    b.HasIndex("userId");

                    b.ToTable("ColumnFlows");
                });

            modelBuilder.Entity("CustomerService", b =>
                {
                    b.Property<int>("CustomerServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ColumnFlowId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Protocol")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("CustomerServiceId");

                    b.HasIndex("ColumnFlowId");

                    b.ToTable("CustomerServices");
                });

            modelBuilder.Entity("HistoryCustomerService", b =>
                {
                    b.Property<int>("HistoryCustomerServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("CustomerServiceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FromColumn")
                        .HasColumnType("TEXT");

                    b.Property<string>("ToColumn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("HistoryCustomerServiceId");

                    b.HasIndex("CustomerServiceId");

                    b.ToTable("HistoryCustomerServices");
                });

            modelBuilder.Entity("QuickMessage", b =>
                {
                    b.Property<int>("QuickMessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("QuickMessageId");

                    b.HasIndex("UserId");

                    b.ToTable("QuickMessages");
                });

            modelBuilder.Entity("Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TagId");

                    b.HasIndex("UserId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isOwner")
                        .HasColumnType("INTEGER");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ColumnFlow", b =>
                {
                    b.HasOne("User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CustomerService", b =>
                {
                    b.HasOne("ColumnFlow", "ColumnFlow")
                        .WithMany("customerServices")
                        .HasForeignKey("ColumnFlowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ColumnFlow");
                });

            modelBuilder.Entity("HistoryCustomerService", b =>
                {
                    b.HasOne("CustomerService", "CustomerService")
                        .WithMany("HistoryCustomerServices")
                        .HasForeignKey("CustomerServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerService");
                });

            modelBuilder.Entity("QuickMessage", b =>
                {
                    b.HasOne("User", "User")
                        .WithMany("QuickMessages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tag", b =>
                {
                    b.HasOne("User", "User")
                        .WithMany("Tags")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ColumnFlow", b =>
                {
                    b.Navigation("customerServices");
                });

            modelBuilder.Entity("CustomerService", b =>
                {
                    b.Navigation("HistoryCustomerServices");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Navigation("QuickMessages");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
