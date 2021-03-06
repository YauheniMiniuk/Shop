// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.Models;

namespace Shop.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210809150838_Subcategory")]
    partial class Subcategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Shop.Models.CartLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("CartLine");
                });

            modelBuilder.Entity("Shop.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("GiftWrap")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Line1")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Line2")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Line3")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Shipped")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Zip")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Shop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Subcategory")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("isAvailable")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Shop.Models.CartLine", b =>
                {
                    b.HasOne("Shop.Models.Order", null)
                        .WithMany("Lines")
                        .HasForeignKey("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}
