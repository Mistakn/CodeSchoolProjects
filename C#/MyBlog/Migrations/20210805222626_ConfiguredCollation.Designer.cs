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
    [Migration("20210805222626_ConfiguredCollation")]
    partial class ConfiguredCollation
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

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                    b.HasKey("BlogID");

                    b.ToTable("Blog");
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

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                    b.HasKey("PostID");

                    b.HasIndex("BlogID");

                    b.ToTable("Post");
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
#pragma warning restore 612, 618
        }
    }
}
