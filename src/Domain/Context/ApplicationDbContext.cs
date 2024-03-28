using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Domain.Context;

public partial class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Destination> Destinations { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
         modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.AddressNavigation).WithMany(p => p.Branches).HasConstraintName("branches_ibfk_1");
        });

        modelBuilder.Entity<Destination>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.AddressNavigation).WithMany(p => p.Destinations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("destinations_ibfk_1");

            entity.HasMany(d => d.Photos).WithMany(p => p.Destinations)
                .UsingEntity<Dictionary<string, object>>(
                    "DestinationsPhoto",
                    r => r.HasOne<Photo>().WithMany()
                        .HasForeignKey("PhotosId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("destinations_photos_ibfk_2"),
                    l => l.HasOne<Destination>().WithMany()
                        .HasForeignKey("DestinationsId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("destinations_photos_ibfk_1"),
                    j =>
                    {
                        j.HasKey("DestinationsId", "PhotosId").HasName("PRIMARY");
                        j.ToTable("destinations_photos");
                        j.HasIndex(new[] { "PhotosId" }, "photos_id");
                        j.IndexerProperty<int>("DestinationsId").HasColumnName("destinations_id");
                        j.IndexerProperty<int>("PhotosId").HasColumnName("photos_id");
                    });
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasOne(d => d.BranchNavigation).WithMany(p => p.Employees).HasConstraintName("employees_ibfk_2");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => new { e.PackageSchedules, e.UserId }).HasName("PRIMARY");

            entity.HasOne(d => d.PackageSchedulesNavigation).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_ibfk_2");
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Availible).HasDefaultValueSql("'1'");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Packages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("packages_ibfk_2");

            entity.HasOne(d => d.RoomNavigation).WithMany(p => p.Packages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("packages_ibfk_1");

            entity.HasOne(d => d.RootPackage).WithMany(p => p.InverseRootPackage).HasConstraintName("packages_ibfk_3");
        });

        modelBuilder.Entity<PackageSchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Package).WithMany(p => p.PackageSchedules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("package_schedules_ibfk_1");
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Photo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("photos_ibfk_1");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Availible).HasDefaultValueSql("'1'");

            entity.HasOne(d => d.DestinationNavigation).WithMany(p => p.Rooms)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rooms_ibfk_1");

            entity.HasMany(d => d.Photos).WithMany(p => p.Rooms)
                .UsingEntity<Dictionary<string, object>>(
                    "RoomsPhoto",
                    r => r.HasOne<Photo>().WithMany()
                        .HasForeignKey("PhotosId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("rooms_photos_ibfk_2"),
                    l => l.HasOne<Room>().WithMany()
                        .HasForeignKey("RoomsId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("rooms_photos_ibfk_1"),
                    j =>
                    {
                        j.HasKey("RoomsId", "PhotosId").HasName("PRIMARY");
                        j.ToTable("rooms_photos");
                        j.HasIndex(new[] { "PhotosId" }, "photos_id");
                        j.IndexerProperty<int>("RoomsId").HasColumnName("rooms_id");
                        j.IndexerProperty<int>("PhotosId").HasColumnName("photos_id");
                    });
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasMany(d => d.Destinations).WithMany(p => p.Tags)
                .UsingEntity<Dictionary<string, object>>(
                    "TagsDestination",
                    r => r.HasOne<Destination>().WithMany()
                        .HasForeignKey("DestinationsId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("tags_destinations_ibfk_2"),
                    l => l.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("tags_destinations_ibfk_1"),
                    j =>
                    {
                        j.HasKey("TagsId", "DestinationsId").HasName("PRIMARY");
                        j.ToTable("tags_destinations");
                        j.HasIndex(new[] { "DestinationsId" }, "destinations_id");
                        j.IndexerProperty<int>("TagsId").HasColumnName("tags_id");
                        j.IndexerProperty<int>("DestinationsId").HasColumnName("destinations_id");
                    });

            entity.HasMany(d => d.Packages).WithMany(p => p.Tags)
                .UsingEntity<Dictionary<string, object>>(
                    "TagsPackage",
                    r => r.HasOne<Package>().WithMany()
                        .HasForeignKey("PackagesId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("tags_packages_ibfk_2"),
                    l => l.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("tags_packages_ibfk_1"),
                    j =>
                    {
                        j.HasKey("TagsId", "PackagesId").HasName("PRIMARY");
                        j.ToTable("tags_packages");
                        j.HasIndex(new[] { "PackagesId" }, "packages_id");
                        j.IndexerProperty<int>("TagsId").HasColumnName("tags_id");
                        j.IndexerProperty<int>("PackagesId").HasColumnName("packages_id");
                    });

            entity.HasMany(d => d.Rooms).WithMany(p => p.Tags)
                .UsingEntity<Dictionary<string, object>>(
                    "TagsRoom",
                    r => r.HasOne<Room>().WithMany()
                        .HasForeignKey("RoomsId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("tags_rooms_ibfk_2"),
                    l => l.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("tags_rooms_ibfk_1"),
                    j =>
                    {
                        j.HasKey("TagsId", "RoomsId").HasName("PRIMARY");
                        j.ToTable("tags_rooms");
                        j.HasIndex(new[] { "RoomsId" }, "rooms_id");
                        j.IndexerProperty<int>("TagsId").HasColumnName("tags_id");
                        j.IndexerProperty<int>("RoomsId").HasColumnName("rooms_id");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.AddressesNavigation).WithMany(p => p.Users).HasConstraintName("users_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
