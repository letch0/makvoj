using System;
using System.Collections.Generic;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Context;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Destination> Destinations { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Package> Packages { get; set; }

    public virtual DbSet<PackageSchedule> PackageSchedules { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=127.0.0.1;uid=user;pwd=password;database=db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("addresses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(128)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(64)
                .HasColumnName("country");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .HasColumnName("postal_code");
            entity.Property(e => e.Street)
                .HasMaxLength(128)
                .HasColumnName("street");
            entity.Property(e => e.Street2)
                .HasMaxLength(128)
                .HasColumnName("street2");
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("admin");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CanDelete).HasColumnName("can_delete");
            entity.Property(e => e.CanEdit).HasColumnName("can_edit");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Admin)
                .HasForeignKey<Admin>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("admin_ibfk_1");
        });

        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("branches");

            entity.HasIndex(e => e.Address, "address");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");

            entity.HasOne(d => d.AddressNavigation).WithMany(p => p.Branches)
                .HasForeignKey(d => d.Address)
                .HasConstraintName("branches_ibfk_1");
        });

        modelBuilder.Entity<Destination>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("destinations");

            entity.HasIndex(e => e.Address, "address");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Availible).HasColumnName("availible");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasColumnName("name");
            entity.Property(e => e.Rating).HasColumnName("rating");

            entity.HasOne(d => d.AddressNavigation).WithMany(p => p.Destinations)
                .HasForeignKey(d => d.Address)
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
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("employees");

            entity.HasIndex(e => e.Branch, "branch");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Branch).HasColumnName("branch");

            entity.HasOne(d => d.BranchNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Branch)
                .HasConstraintName("employees_ibfk_2");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Employee)
                .HasForeignKey<Employee>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employees_ibfk_1");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => new { e.PackageSchedules, e.UserId }).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.UserId, "userId");

            entity.Property(e => e.PackageSchedules).HasColumnName("package_schedules");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.HasBeenPaid).HasColumnName("has_been_paid");

            entity.HasOne(d => d.PackageSchedulesNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PackageSchedules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_ibfk_2");
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("packages");

            entity.HasIndex(e => e.CreatedBy, "created_by");

            entity.HasIndex(e => e.Room, "room");

            entity.HasIndex(e => e.RootPackageId, "root_package_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Availible)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("availible");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Room).HasColumnName("room");
            entity.Property(e => e.RootPackageId).HasColumnName("root_package_id");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Packages)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("packages_ibfk_2");

            entity.HasOne(d => d.RoomNavigation).WithMany(p => p.Packages)
                .HasForeignKey(d => d.Room)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("packages_ibfk_1");

            entity.HasOne(d => d.RootPackage).WithMany(p => p.InverseRootPackage)
                .HasForeignKey(d => d.RootPackageId)
                .HasConstraintName("packages_ibfk_3");
        });

        modelBuilder.Entity<PackageSchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("package_schedules");

            entity.HasIndex(e => e.PackageId, "package_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateStart)
                .HasColumnType("date")
                .HasColumnName("date_start");
            entity.Property(e => e.Days).HasColumnName("days");
            entity.Property(e => e.PackageId).HasColumnName("package_id");

            entity.HasOne(d => d.Package).WithMany(p => p.PackageSchedules)
                .HasForeignKey(d => d.PackageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("package_schedules_ibfk_1");
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("photos");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Photo1)
                .HasColumnType("blob")
                .HasColumnName("photo");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Photo)
                .HasForeignKey<Photo>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("photos_ibfk_1");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("rooms");

            entity.HasIndex(e => e.Destination, "destination");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AmountAvailible).HasColumnName("amount_availible");
            entity.Property(e => e.Availible)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("availible");
            entity.Property(e => e.Beds)
                .HasColumnType("json")
                .HasColumnName("beds");
            entity.Property(e => e.CostPerNight)
                .HasPrecision(15)
                .HasColumnName("cost_per_night");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Destination).HasColumnName("destination");

            entity.HasOne(d => d.DestinationNavigation).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.Destination)
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

            entity.ToTable("tags");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Decription)
                .HasColumnType("text")
                .HasColumnName("decription");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .HasColumnName("name");

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
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Addresses, "addresses");

            entity.HasIndex(e => e.Email, "users_index_0");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Addresses).HasColumnName("addresses");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(64)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNum)
                .HasMaxLength(255)
                .HasColumnName("phone_num");
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .HasColumnName("surname");

            entity.HasOne(d => d.AddressesNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Addresses)
                .HasConstraintName("users_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
