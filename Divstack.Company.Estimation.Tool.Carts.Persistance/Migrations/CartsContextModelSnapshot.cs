﻿// <auto-generated />
using System;
using Divstack.Company.Estimation.Tool.Carts.Persistance.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Divstack.Company.Estimation.Tool.Carts.Persistance.Migrations
{
    [DbContext(typeof(CartsContext))]
    partial class CartsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Carts")
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Divstack.Company.Estimation.Tool.Carts.Domain.Carts.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastActivity")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Divstack.Company.Estimation.Tool.Carts.Domain.Carts.Cart", b =>
                {
                    b.OwnsMany("Divstack.Company.Estimation.Tool.Carts.Domain.Carts.CartItem", "Items", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("CartId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id");

                            b1.HasIndex("CartId");

                            b1.ToTable("Items");

                            b1.WithOwner()
                                .HasForeignKey("CartId");
                        });

                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
