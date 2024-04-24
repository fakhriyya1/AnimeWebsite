﻿// <auto-generated />
using System;
using AnimeDAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AnimeDAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AnimeEntity.Entities.Anime", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImageId")
                        .IsUnique();

                    b.ToTable("Animes");
                });

            modelBuilder.Entity("AnimeEntity.Entities.AnimeCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<Guid>("AnimeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoryId", "AnimeId");

                    b.HasIndex("AnimeId");

                    b.ToTable("AnimeCategory");
                });

            modelBuilder.Entity("AnimeEntity.Entities.AnimeDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("AnimeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAired")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Studio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnimeId")
                        .IsUnique();

                    b.ToTable("AnimeDetails");
                });

            modelBuilder.Entity("AnimeEntity.Entities.Blog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId")
                        .IsUnique();

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("AnimeEntity.Entities.BlogCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<Guid>("BlogId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoryId", "BlogId");

                    b.HasIndex("BlogId");

                    b.ToTable("BlogCategory");
                });

            modelBuilder.Entity("AnimeEntity.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AnimeEntity.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("AnimeEntity.Entities.Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("AnimeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AnimeId")
                        .IsUnique();

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("AnimeEntity.Entities.Anime", b =>
                {
                    b.HasOne("AnimeEntity.Entities.Image", "Image")
                        .WithOne("Anime")
                        .HasForeignKey("AnimeEntity.Entities.Anime", "ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");
                });

            modelBuilder.Entity("AnimeEntity.Entities.AnimeCategory", b =>
                {
                    b.HasOne("AnimeEntity.Entities.Anime", "Anime")
                        .WithMany("Categories")
                        .HasForeignKey("AnimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnimeEntity.Entities.Category", "Category")
                        .WithMany("Animes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anime");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("AnimeEntity.Entities.AnimeDetail", b =>
                {
                    b.HasOne("AnimeEntity.Entities.Anime", "Anime")
                        .WithOne("AnimeDetail")
                        .HasForeignKey("AnimeEntity.Entities.AnimeDetail", "AnimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anime");
                });

            modelBuilder.Entity("AnimeEntity.Entities.Blog", b =>
                {
                    b.HasOne("AnimeEntity.Entities.Image", "Image")
                        .WithOne("Blog")
                        .HasForeignKey("AnimeEntity.Entities.Blog", "ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");
                });

            modelBuilder.Entity("AnimeEntity.Entities.BlogCategory", b =>
                {
                    b.HasOne("AnimeEntity.Entities.Blog", "Blog")
                        .WithMany("Categories")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnimeEntity.Entities.Category", "Category")
                        .WithMany("Blogs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("AnimeEntity.Entities.Slider", b =>
                {
                    b.HasOne("AnimeEntity.Entities.Anime", "Anime")
                        .WithOne("Slider")
                        .HasForeignKey("AnimeEntity.Entities.Slider", "AnimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anime");
                });

            modelBuilder.Entity("AnimeEntity.Entities.Anime", b =>
                {
                    b.Navigation("AnimeDetail")
                        .IsRequired();

                    b.Navigation("Categories");

                    b.Navigation("Slider");
                });

            modelBuilder.Entity("AnimeEntity.Entities.Blog", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("AnimeEntity.Entities.Category", b =>
                {
                    b.Navigation("Animes");

                    b.Navigation("Blogs");
                });

            modelBuilder.Entity("AnimeEntity.Entities.Image", b =>
                {
                    b.Navigation("Anime");

                    b.Navigation("Blog");
                });
#pragma warning restore 612, 618
        }
    }
}
