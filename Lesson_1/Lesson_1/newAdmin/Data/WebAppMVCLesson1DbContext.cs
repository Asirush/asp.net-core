using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using newAdmin.Modals;

namespace newAdmin.Data;

public partial class WebAppMVCLesson1DbContext : DbContext
{
    public WebAppMVCLesson1DbContext()
    {
    }

    public WebAppMVCLesson1DbContext(DbContextOptions<WebAppMVCLesson1DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carusel> Carusels { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomProperty> RoomProperties { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<SliderArea> SliderAreas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=ASIRUSH-NTBOOK;Database=hotel;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carusel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Carusel");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreateUser)
                .HasMaxLength(500)
                .IsFixedLength();
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsFixedLength();
            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
            entity.Property(e => e.PictureUrl)
                .HasMaxLength(500)
                .IsFixedLength();
            entity.Property(e => e.Tirle)
                .HasMaxLength(500)
                .IsFixedLength();
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.ToTable("Room");

            entity.Property(e => e.HasTv).HasColumnName("HasTV");
            entity.Property(e => e.IsFullAc).HasColumnName("IsFullAC");
            entity.Property(e => e.Square).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.RoomType).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.RoomTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Room_RoomType");
        });

        modelBuilder.Entity<RoomProperty>(entity =>
        {
            entity.ToTable("RoomProperty");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(500);
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.ToTable("RoomType");

            entity.Property(e => e.Imagepath).HasMaxLength(1000);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.RoomTypeDescription).HasMaxLength(1000);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("Service");

            entity.Property(e => e.ServiceDescription).HasMaxLength(500);
            entity.Property(e => e.ServiceIconPath).HasMaxLength(500);
            entity.Property(e => e.ServiceImagePath).HasMaxLength(500);
            entity.Property(e => e.ServiceName).HasMaxLength(50);
        });

        modelBuilder.Entity<SliderArea>(entity =>
        {
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.Header).HasMaxLength(100);
            entity.Property(e => e.PathImg).HasMaxLength(500);
            entity.Property(e => e.Url).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
