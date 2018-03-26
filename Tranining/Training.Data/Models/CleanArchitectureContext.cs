using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Training.Data.Models
{
    public partial class CleanArchitectureContext : DbContext
    {
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=CleanArchitecture;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.HasIndex(e => e.CustomerId)
                    .HasName("IX_Customer_Id");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_Employee_Id");

                entity.HasIndex(e => e.ProductId)
                    .HasName("IX_Product_Id");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_dbo.Sales_dbo.Customers_Customer_Id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_dbo.Sales_dbo.Employees_Employee_Id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_dbo.Sales_dbo.Products_Product_Id");
            });
        }
    }
}
