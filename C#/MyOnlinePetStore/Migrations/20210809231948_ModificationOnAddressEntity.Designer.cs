﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyOnlinePetStore.Data;

namespace MyOnlinePetStore.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210809231948_ModificationOnAddressEntity")]
    partial class ModificationOnAddressEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyOnlinePetStore.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MyOnlinePetStore.Entities.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("OrderFulfilled")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderPlaced")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MyOnlinePetStore.Entities.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MyOnlinePetStore.Entities.ProductOrder", b =>
                {
                    b.Property<int>("ProductOrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductOrderID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductOrders");
                });

            modelBuilder.Entity("MyOnlinePetStore.Entities.Customer", b =>
                {
                    b.OwnsOne("MyOnlinePetStore.Entities.Address", "Address", b1 =>
                        {
                            b1.Property<int>("AddressID")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)");

                            b1.Property<int>("CustomerID")
                                .HasColumnType("int");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasMaxLength(5)
                                .HasColumnType("nvarchar(5)");

                            b1.Property<string>("StateOrProvinceAbbr")
                                .IsRequired()
                                .HasMaxLength(3)
                                .HasColumnType("nvarchar(3)");

                            b1.Property<string>("StreetAddress")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)");

                            b1.HasKey("AddressID");

                            b1.HasIndex("CustomerID")
                                .IsUnique();

                            b1.ToTable("Addresses");

                            b1.WithOwner("Customer")
                                .HasForeignKey("CustomerID");

                            b1.Navigation("Customer");
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("MyOnlinePetStore.Entities.Order", b =>
                {
                    b.HasOne("MyOnlinePetStore.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("MyOnlinePetStore.Entities.ProductOrder", b =>
                {
                    b.HasOne("MyOnlinePetStore.Entities.Order", "Order")
                        .WithMany("ProductOrders")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyOnlinePetStore.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MyOnlinePetStore.Entities.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("MyOnlinePetStore.Entities.Order", b =>
                {
                    b.Navigation("ProductOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
