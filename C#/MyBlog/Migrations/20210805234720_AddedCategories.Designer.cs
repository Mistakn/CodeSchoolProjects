﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBlog.Data;

namespace MyBlog.Migrations
{
    [DbContext(typeof(MyBlogContext))]
    [Migration("20210805234720_AddedCategories")]
    partial class AddedCategories
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyBlog.Entities.Blog", b =>
                {
                    b.Property<int>("BlogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int?>("Rating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(3);

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                    b.HasKey("BlogID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("MyBlog.Entities.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                    b.HasKey("CategoryID");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            Name = "Sports"
                        },
                        new
                        {
                            CategoryID = 2,
                            Name = "Climate"
                        },
                        new
                        {
                            CategoryID = 3,
                            Name = "Traffic"
                        });
                });

            modelBuilder.Entity("MyBlog.Entities.Post", b =>
                {
                    b.Property<int?>("PostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BlogID")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                    b.Property<DateTime>("PublishedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                    b.HasKey("PostID");

                    b.HasIndex("BlogID");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("MyBlog.Entities.Blog", b =>
                {
                    b.HasOne("MyBlog.Entities.Category", "Category")
                        .WithMany("Blogs")
                        .HasForeignKey("CategoryID");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MyBlog.Entities.Post", b =>
                {
                    b.HasOne("MyBlog.Entities.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogID");

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("MyBlog.Entities.Blog", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("MyBlog.Entities.Category", b =>
                {
                    b.Navigation("Blogs");
                });
#pragma warning restore 612, 618
        }
    }
}