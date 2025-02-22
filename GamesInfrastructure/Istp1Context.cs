using System;
using System.Collections.Generic;
using GamesDomain.Model;
using Microsoft.EntityFrameworkCore;

namespace GamesInfrastructure;

public partial class Istp1Context : DbContext
{
    public Istp1Context()
    {
    }

    public Istp1Context(DbContextOptions<Istp1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Oleksandr;Database=ISTP1;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__countrie__3213E83F764E1D9B");

            entity.ToTable("countries");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__games__3213E83F76A506E2");

            entity.ToTable("games");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .HasColumnName("name");
            entity.Property(e => e.PublisherId).HasColumnName("publisher_id");

            entity.HasOne(d => d.Genre).WithMany(p => p.Games)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__games__genre_id__3F466844");

            entity.HasOne(d => d.Publisher).WithMany(p => p.Games)
                .HasForeignKey(d => d.PublisherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__games__publisher__3E52440B");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__genres__3213E83F83FE6981");

            entity.ToTable("genres");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__publishe__3213E83FA0E9EE8D");

            entity.ToTable("publishers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CountryOfOrigin).HasColumnName("country_of_origin");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .HasColumnName("name");

            entity.HasOne(d => d.CountryOfOriginNavigation).WithMany(p => p.Publishers)
                .HasForeignKey(d => d.CountryOfOrigin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__publisher__count__398D8EEE");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reviews__3213E83FE2BD971B");

            entity.ToTable("reviews");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Review1).HasColumnName("review");

            entity.HasOne(d => d.Game).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reviews__game_id__48CFD27E");
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__shops__3213E83F8F8B9349");

            entity.ToTable("shops");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => new { e.GameId, e.ShopId }).HasName("PK__stock__85319EB7B2EE012B");

            entity.ToTable("stock");

            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.ShopId).HasColumnName("shop_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Game).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__stock__game_id__5FB337D6");

            entity.HasOne(d => d.Shop).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.ShopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__stock__shop_id__60A75C0F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
