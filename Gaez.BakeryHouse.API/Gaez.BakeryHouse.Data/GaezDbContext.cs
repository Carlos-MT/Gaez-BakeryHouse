using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Gaez.BakeryHouse.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Gaez.BakeryHouse.Data
{
    public partial class GaezDbContext : DbContext
    {
        public GaezDbContext()
        {
        }

        public GaezDbContext(DbContextOptions<GaezDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<ClientLikesProduct> ClientLikesProducts { get; set; } = null!;
        public virtual DbSet<ClientMakesComment> ClientMakesComments { get; set; } = null!;
        public virtual DbSet<ClientSaveProduct> ClientSaveProducts { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Offert> Offerts { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductBelongsToCategory> ProductBelongsToCategories { get; set; } = null!;
        public virtual DbSet<ProductHasComment> ProductHasComments { get; set; } = null!;
        public virtual DbSet<ProductOffert> ProductOfferts { get; set; } = null!;
        public virtual DbSet<Provider> Providers { get; set; } = null!;
        public virtual DbSet<ProviderProvidesProduct> ProviderProvidesProducts { get; set; } = null!;
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;
        public virtual DbSet<ShoppingCartBelongsToClient> ShoppingCartBelongsToClients { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Gaez;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FatherLastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MotherLastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientLikesProduct>(entity =>
            {
                //entity.HasNoKey();
                entity.HasKey(e => new { e.ClientId, e.ProductCode });

                entity.ToTable("ClientLikesProduct");

                entity.HasOne(d => d.Client)
                    .WithMany()
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientLikesProduct_Client");

                entity.HasOne(d => d.ProductCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ProductCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientLikesProduct_Product");
            });

            modelBuilder.Entity<ClientMakesComment>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.ToTable("ClientMakesComment");

                entity.Property(e => e.CommentId).ValueGeneratedNever();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientMakesComments)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientMakesComment_Client");

                entity.HasOne(d => d.Comment)
                    .WithOne(p => p.ClientMakesComment)
                    .HasForeignKey<ClientMakesComment>(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientMakesComment_Comment");
            });

            modelBuilder.Entity<ClientSaveProduct>(entity =>
            {
                //entity.HasNoKey();
                entity.HasKey(e => new { e.ClientId, e.ProductCode });

                entity.ToTable("ClientSaveProduct");

                entity.HasOne(d => d.Client)
                    .WithMany()
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientSaveProduct_Client");

                entity.HasOne(d => d.ProductCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ProductCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientSaveProduct_Product");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.CommentDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Offert>(entity =>
            {
                entity.ToTable("Offert");

                entity.Property(e => e.Discount).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.FinishDate).HasColumnType("datetime");

                entity.Property(e => e.InitDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductCode);

                entity.ToTable("Product");

                entity.Property(e => e.ProductCode).ValueGeneratedNever();

                entity.Property(e => e.Application)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ExpirityDate).HasColumnType("datetime");

                entity.Property(e => e.ProductImage).HasColumnType("image");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RegularPrice).HasColumnType("decimal(8, 2)");
            });

            modelBuilder.Entity<ProductBelongsToCategory>(entity =>
            {
                entity.HasKey(e => e.ProductCode);

                entity.ToTable("ProductBelongsToCategory");

                entity.Property(e => e.ProductCode).ValueGeneratedNever();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductBelongsToCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductBelongsToCategory_Category");

                entity.HasOne(d => d.ProductCodeNavigation)
                    .WithOne(p => p.ProductBelongsToCategory)
                    .HasForeignKey<ProductBelongsToCategory>(d => d.ProductCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductBelongsToCategory_Product");
            });

            modelBuilder.Entity<ProductHasComment>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.ToTable("ProductHasComment");

                entity.Property(e => e.CommentId).ValueGeneratedNever();

                entity.HasOne(d => d.Comment)
                    .WithOne(p => p.ProductHasComment)
                    .HasForeignKey<ProductHasComment>(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductHasComment_Comment");

                entity.HasOne(d => d.ProductCodeNavigation)
                    .WithMany(p => p.ProductHasComments)
                    .HasForeignKey(d => d.ProductCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductHasComment_Product");
            });

            modelBuilder.Entity<ProductOffert>(entity =>
            {
                entity.HasKey(e => e.OffertId);

                entity.ToTable("ProductOffert");

                entity.Property(e => e.OffertId).ValueGeneratedNever();

                entity.HasOne(d => d.Offert)
                    .WithOne(p => p.ProductOffert)
                    .HasForeignKey<ProductOffert>(d => d.OffertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductOffert_Offert");

                entity.HasOne(d => d.ProductCodeNavigation)
                    .WithMany(p => p.ProductOfferts)
                    .HasForeignKey(d => d.ProductCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductOffert_Product");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.ToTable("Provider");

                entity.Property(e => e.ProviderName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProviderProvidesProduct>(entity =>
            {
                entity.HasKey(e => e.ProductCode);

                entity.ToTable("ProviderProvidesProduct");

                entity.Property(e => e.ProductCode).ValueGeneratedNever();

                entity.HasOne(d => d.ProductCodeNavigation)
                    .WithOne(p => p.ProviderProvidesProduct)
                    .HasForeignKey<ProviderProvidesProduct>(d => d.ProductCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProviderProvidesProduct_Product");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.ProviderProvidesProducts)
                    .HasForeignKey(d => d.ProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProviderProvidesProduct_Provider");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.ToTable("ShoppingCart");

                entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<ShoppingCartBelongsToClient>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.ToTable("ShoppingCartBelongsToClient");

                entity.Property(e => e.ClientId).ValueGeneratedNever();

                entity.HasOne(d => d.Client)
                    .WithOne(p => p.ShoppingCartBelongsToClient)
                    .HasForeignKey<ShoppingCartBelongsToClient>(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShoppingCartBelongsToClient_Client1");

                entity.HasOne(d => d.ShoppingCart)
                    .WithMany(p => p.ShoppingCartBelongsToClients)
                    .HasForeignKey(d => d.ShoppingCartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShoppingCartBelongsToClient_ShoppingCart1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
