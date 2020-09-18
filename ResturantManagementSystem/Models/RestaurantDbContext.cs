using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ResturantManagementSystem.Models
{
    public partial class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext()
        {
        }

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CusineRestaurant> CusineRestaurant { get; set; }
        public virtual DbSet<FoodResturant> FoodResturant { get; set; }
        public virtual DbSet<TblCusine> TblCusine { get; set; }
        public virtual DbSet<TblFood> TblFood { get; set; }
        public virtual DbSet<TblResturant> TblResturant { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=vssql\\SQLEXPRESS;Database=RestaurantDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CusineRestaurant>(entity =>
            {
                entity.HasOne(d => d.Cusine)
                    .WithMany(p => p.CusineRestaurant)
                    .HasForeignKey(d => d.CusineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CusineRes__Cusin__3B75D760");

                //entity.HasOne(d => d.Rest)
                //    .WithMany(p => p.CusineRestaurant)
                //    .HasForeignKey(d => d.RestId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__CusineRes__RestI__3C69FB99");
            });

            modelBuilder.Entity<FoodResturant>(entity =>
            {
                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.FoodResturant)
                    .HasForeignKey(d => d.FoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FoodRestu__FoodI__412EB0B6");

                entity.HasOne(d => d.Rest)
                    .WithMany(p => p.FoodResturant)
                    .HasForeignKey(d => d.RestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FoodRestu__RestI__4222D4EF");
            });

            modelBuilder.Entity<TblCusine>(entity =>
            {
                entity.HasKey(e => e.CusineId);

                entity.ToTable("tblCusine");

                entity.Property(e => e.CusineType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblFood>(entity =>
            {
                entity.HasKey(e => e.FoodId);

                entity.ToTable("tblFood");

                entity.Property(e => e.FoodName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<TblResturant>(entity =>
            {
                entity.HasKey(e => e.RestId);

                entity.ToTable("tblResturant");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnName("location")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RestName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
