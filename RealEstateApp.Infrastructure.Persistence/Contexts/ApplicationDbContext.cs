using Microsoft.EntityFrameworkCore;
using RealEstateApp.Core.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace RealEstateApp.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<SaleType> SaleTypes { get; set; }
        public DbSet<Improvement> Improvements { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<PropertyImprovement> PropertyImprovements { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<FavoriteProperty> FavoriteProperties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Property>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Code).IsRequired().HasMaxLength(6);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Description).IsRequired();
            });

            modelBuilder.Entity<PropertyType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired();
            });

            modelBuilder.Entity<SaleType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired();
            });

            modelBuilder.Entity<Improvement>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired();
            });

            modelBuilder.Entity<PropertyImprovement>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Property)
                    .WithMany(e => e.PropertyImprovements)
                    .HasForeignKey(e => e.PropertyId);
                entity.HasOne(e => e.Improvement)
                    .WithMany(e => e.PropertyImprovements)
                    .HasForeignKey(e => e.ImprovementId);
            });

            modelBuilder.Entity<PropertyImage>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Property)
                    .WithMany(e => e.Images)
                    .HasForeignKey(e => e.PropertyId);
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
                entity.HasOne(e => e.Property)
                    .WithMany(e => e.Offers)
                    .HasForeignKey(e => e.PropertyId);
            });

            modelBuilder.Entity<ChatMessage>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Property)
                    .WithMany(e => e.ChatMessages)
                    .HasForeignKey(e => e.PropertyId);
            });

            modelBuilder.Entity<FavoriteProperty>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Property)
                    .WithMany(e => e.FavoriteProperties)
                    .HasForeignKey(e => e.PropertyId);
            });
        }
    }
}