using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazorDDL.Shared.Models
{
    public partial class ApplicationInventoryContext : DbContext
    {
        public ApplicationInventoryContext()
        {
        }

        public ApplicationInventoryContext(DbContextOptions<ApplicationInventoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Servers> Servers { get; set; }
        public virtual DbSet<ServerTypes> ServerTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=vmsqlclstdev;Initial Catalog=ApplicationInventory;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servers>(entity =>
            {
                entity.HasKey(e => e.ServerId);

                entity.HasIndex(e => e.ComputerName)
                    .HasName("UK_ServersComputerName")
                    .IsUnique();

                entity.HasIndex(e => e.Ipaddress)
                    .HasName("UK_ServersIPAddress")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("UK_ServersName")
                    .IsUnique();

                entity.Property(e => e.ServerId).ValueGeneratedNever();

                entity.Property(e => e.ComputerName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Domain).HasMaxLength(50);

                entity.Property(e => e.Ipaddress)
                    .IsRequired()
                    .HasColumnName("IPAddress")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.ServerType)
                    .WithMany(p => p.Servers)
                    .HasForeignKey(d => d.ServerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Servers_ServerType");
            });

            modelBuilder.Entity<ServerTypes>(entity =>
            {
                entity.HasKey(e => e.ServerTypeId);

                entity.HasIndex(e => e.Name)
                    .HasName("UK_ServerTypesNAME")
                    .IsUnique();

                entity.HasIndex(e => e.SortOrder)
                    .HasName("UK_ServerTypesUnique")
                    .IsUnique();

                entity.Property(e => e.ServerTypeId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
