using AnimeEntity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeDAL.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Anime> Animes { get; set; }
        public DbSet<AnimeDetail> AnimeDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Many-to-many  --->  Category-Anime

            modelBuilder.Entity<AnimeCategory>()
                .HasKey(ac => new { ac.CategoryId, ac.AnimeId });

            modelBuilder.Entity<AnimeCategory>()
                .HasOne(ac => ac.Anime)
                .WithMany(a => a.Categories)
                .HasForeignKey(ac => ac.AnimeId);

            modelBuilder.Entity<AnimeCategory>()
                .HasOne(ac => ac.Category)
                .WithMany(a => a.Animes)
                .HasForeignKey(ac => ac.CategoryId);


            //Many-to-many   --->   Blog-Category

            modelBuilder.Entity<BlogCategory>()
                .HasKey(bc => new { bc.CategoryId, bc.BlogId });

            modelBuilder.Entity<BlogCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.Blogs)
                .HasForeignKey(bc => bc.CategoryId);

            modelBuilder.Entity<BlogCategory>()
                .HasOne(bc => bc.Blog)
                .WithMany(c => c.Categories)
                .HasForeignKey(bc => bc.BlogId);

        }

    }
}
