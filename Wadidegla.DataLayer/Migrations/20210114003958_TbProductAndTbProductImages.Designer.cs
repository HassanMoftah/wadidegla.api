﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wadidegla.DataLayer;

namespace Wadidegla.DataLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210114003958_TbProductAndTbProductImages")]
    partial class TbProductAndTbProductImages
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Wadidegla.DataLayer.Models.TbCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<int>("ParentId");

                    b.HasKey("Id");

                    b.ToTable("TbCategories");
                });

            modelBuilder.Entity("Wadidegla.DataLayer.Models.TbCategoryAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("TbCategoryAttributes");
                });

            modelBuilder.Entity("Wadidegla.DataLayer.Models.TbCategoryAttributeOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryAttributeId");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(MAX)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryAttributeId");

                    b.ToTable("TbCategoryAttributeOptions");
                });

            modelBuilder.Entity("Wadidegla.DataLayer.Models.TbProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<int>("DefaultProductImageId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("TbProducts");
                });

            modelBuilder.Entity("Wadidegla.DataLayer.Models.TbProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("TbProductImages");
                });

            modelBuilder.Entity("Wadidegla.DataLayer.Models.TbCategoryAttribute", b =>
                {
                    b.HasOne("Wadidegla.DataLayer.Models.TbCategory", "Category")
                        .WithMany("CategoryAttributes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Wadidegla.DataLayer.Models.TbCategoryAttributeOption", b =>
                {
                    b.HasOne("Wadidegla.DataLayer.Models.TbCategoryAttribute", "CategoryAttribute")
                        .WithMany("CategoryAttributeOptions")
                        .HasForeignKey("CategoryAttributeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Wadidegla.DataLayer.Models.TbProduct", b =>
                {
                    b.HasOne("Wadidegla.DataLayer.Models.TbCategory", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Wadidegla.DataLayer.Models.TbProductImage", b =>
                {
                    b.HasOne("Wadidegla.DataLayer.Models.TbProduct", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
