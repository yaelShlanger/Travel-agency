using System;
using System.Collections.Generic;
using Dal.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Dal.Models;

public partial class TheOrganizedTourContext : DbContext
{
    public TheOrganizedTourContext()
    {
    }
    public TheOrganizedTourContext(DbContextOptions<TheOrganizedTourContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OrderTicket> OrderTickets { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<TripType> TripTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }
       
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-E0FAPSB\\SQLEXPRESS;Initial Catalog=TheOrganizedTour; Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderTicket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__orderTic__3214EC07C09DE097");

            entity.ToTable("orderTicket");

            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Hours).HasColumnName("hours");
            entity.Property(e => e.OrderTime).HasColumnName("orderTime");
            entity.Property(e => e.Tickets).HasColumnName("tickets");
            entity.Property(e => e.TripId).HasColumnName("tripId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Trip).WithMany(p => p.OrderTickets)
                .HasForeignKey(d => d.TripId)
                .HasConstraintName("FK__orderTick__tripI__3F466844");

            entity.HasOne(d => d.User).WithMany(p => p.OrderTickets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__orderTick__userI__3E52440B");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Trips__3214EC07D614B7CF");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Departure).HasColumnName("departure");
            entity.Property(e => e.Destination)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("destination");
            entity.Property(e => e.Hours).HasColumnName("hours");
            entity.Property(e => e.Img)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("img");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Trips)
                .HasForeignKey(d => d.Type)
                .HasConstraintName("FK__Trips__Type__3B75D760");
        });

        modelBuilder.Entity<TripType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tripType__3214EC0785CC30CA");

            entity.ToTable("tripType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TripName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3214EC07B392028A");

            entity.ToTable("users");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FirstAidCertificate)
                .HasDefaultValueSql("((0))")
                .HasColumnName("firstAidCertificate");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.Mail)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("mail");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

  
}
