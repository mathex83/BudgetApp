﻿// <auto-generated />
using BudgetApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BudgetApp.Data.Migrations
{
    [DbContext(typeof(BudgetAppContext))]
    [Migration("20220425190700_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BudgetApp.Models.Account", b =>
                {
                    b.Property<int>("AccountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountID"), 1L, 1);

                    b.Property<double>("AccountBalance")
                        .HasColumnType("float");

                    b.Property<string>("AccountName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountID");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("BudgetApp.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryTypeId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.HasIndex("CategoryTypeId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("BudgetApp.Models.CategoryType", b =>
                {
                    b.Property<int>("CategoryTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryTypeId"), 1L, 1);

                    b.Property<string>("CategoryTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryTypeId");

                    b.ToTable("CategoryType");
                });

            modelBuilder.Entity("BudgetApp.Models.Subcategory", b =>
                {
                    b.Property<int>("SubcategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubcategoryId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("SubcategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubcategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Subcategory");
                });

            modelBuilder.Entity("BudgetApp.Models.Category", b =>
                {
                    b.HasOne("BudgetApp.Models.CategoryType", "CategoryType")
                        .WithMany("Categories")
                        .HasForeignKey("CategoryTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryType");
                });

            modelBuilder.Entity("BudgetApp.Models.Subcategory", b =>
                {
                    b.HasOne("BudgetApp.Models.Category", "Category")
                        .WithMany("Subcategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BudgetApp.Models.Category", b =>
                {
                    b.Navigation("Subcategories");
                });

            modelBuilder.Entity("BudgetApp.Models.CategoryType", b =>
                {
                    b.Navigation("Categories");
                });
#pragma warning restore 612, 618
        }
    }
}