using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Reservation.Infrastructure.Context;

public partial class ReservationDbContext : DbContext
{
    public ReservationDbContext()
    {
    }

    public ReservationDbContext(DbContextOptions<ReservationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<HotelAdmin> HotelAdmins { get; set; }

    public virtual DbSet<HotelInformation> HotelInformations { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<Qa> Qas { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomFeature> RoomFeatures { get; set; }

    public virtual DbSet<RoomPrice> RoomPrices { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<WorkingRange> WorkingRanges { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Comments_pkey");

            entity.ToTable("Comments", "reservation");

            entity.Property(e => e.Comment1).HasColumnName("Comment");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Comments)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Comments_HotelId_fkey");
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Favorites_pkey");

            entity.ToTable("Favorites", "reservation");

            entity.Property(e => e.UserId).HasMaxLength(255);

            entity.HasOne(d => d.Hotel).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Favorites_HotelId_fkey");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Hotels_pkey");

            entity.ToTable("Hotels", "reservation");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<HotelAdmin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("HotelAdmins_pkey");

            entity.ToTable("HotelAdmins", "reservation");

            entity.Property(e => e.UserEmail).HasMaxLength(100);

            entity.HasOne(d => d.Hotel).WithMany(p => p.HotelAdmins)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("HotelAdmins_HotelId_fkey");
        });

        modelBuilder.Entity<HotelInformation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("HotelInformations_pkey");

            entity.ToTable("HotelInformations", "reservation");

            entity.HasOne(d => d.Hotel).WithMany(p => p.HotelInformations)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("HotelInformations_HotelId_fkey");
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Photos_pkey");

            entity.ToTable("Photos", "reservation");

            entity.Property(e => e.PhotoPath).HasMaxLength(255);

            entity.HasOne(d => d.Hotel).WithMany(p => p.Photos)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Photos_HotelId_fkey");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Promotions_pkey");

            entity.ToTable("Promotions", "reservation");

            entity.Property(e => e.IsGeneral).HasDefaultValue(true);
            entity.Property(e => e.User).HasMaxLength(255);

            entity.HasOne(d => d.Hotel).WithMany(p => p.Promotions)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Promotions_HotelId_fkey");
        });

        modelBuilder.Entity<Qa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("QA_pkey");

            entity.ToTable("QA", "reservation");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Qas)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("QA_HotelId_fkey");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Reservations_pkey");

            entity.ToTable("Reservations", "reservation");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.SpecialRequest).HasMaxLength(255);
            entity.Property(e => e.User).HasMaxLength(255);

            entity.HasOne(d => d.Hotel).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Reservations_HotelId_fkey");

            entity.HasOne(d => d.Room).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Reservations_RoomId_fkey");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Rooms_pkey");

            entity.ToTable("Rooms", "reservation");

            entity.Property(e => e.RoomType).HasMaxLength(100);

            entity.HasOne(d => d.Hotel).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Rooms_HotelId_fkey");
        });

        modelBuilder.Entity<RoomFeature>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("RoomFeatures_pkey");

            entity.ToTable("RoomFeatures", "reservation");

            entity.Property(e => e.Feature).HasMaxLength(255);

            entity.HasOne(d => d.Room).WithMany(p => p.RoomFeatures)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RoomFeatures_RoomId_fkey");
        });

        modelBuilder.Entity<RoomPrice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("RoomPrices_pkey");

            entity.ToTable("RoomPrices", "reservation");

            entity.Property(e => e.Price).HasPrecision(10, 2);

            entity.HasOne(d => d.Room).WithMany(p => p.RoomPrices)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RoomPrices_RoomId_fkey");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Tags_pkey");

            entity.ToTable("Tags", "reservation");

            entity.Property(e => e.Tag1)
                .HasMaxLength(255)
                .HasColumnName("Tag");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Tags)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Tags_HotelId_fkey");
        });

        modelBuilder.Entity<WorkingRange>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("WorkingRanges_pkey");

            entity.ToTable("WorkingRanges", "reservation");

            entity.HasOne(d => d.Hotel).WithMany(p => p.WorkingRanges)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("WorkingRanges_HotelId_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
