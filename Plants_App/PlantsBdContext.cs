using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Plants_App;

public partial class PlantsBdContext : DbContext
{
    public PlantsBdContext()
    {
    }

    public PlantsBdContext(DbContextOptions<PlantsBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnerProduct> PartnerProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-SKPH1KP\\SQLEXPRESS;Database=Plants_BD;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.ToTable("Material_type");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.MaterialType1)
                .HasMaxLength(50)
                .HasColumnName("Material_type");
            entity.Property(e => e.ProcentBrakaMateriala)
                .HasMaxLength(50)
                .HasColumnName("Procent_braka_materiala");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Director).HasMaxLength(50);
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .HasColumnName("Email_address");
            entity.Property(e => e.Inn).HasColumnName("INN");
            entity.Property(e => e.ParterUrAddress)
                .HasMaxLength(100)
                .HasColumnName("Parter_ur_address");
            entity.Property(e => e.PartnerName)
                .HasMaxLength(50)
                .HasColumnName("Partner_name");
            entity.Property(e => e.PartnerPhone)
                .HasMaxLength(50)
                .HasColumnName("Partner_phone");
            entity.Property(e => e.PartnerType)
                .HasMaxLength(50)
                .HasColumnName("Partner_type");
        });

        modelBuilder.Entity<PartnerProduct>(entity =>
        {
            entity.ToTable("Partner_products");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateOfBuy).HasColumnName("Date_of_buy");
            entity.Property(e => e.PartnerId).HasColumnName("Partner_id");
            entity.Property(e => e.PartnerName)
                .HasMaxLength(50)
                .HasColumnName("Partner_name");
            entity.Property(e => e.Product).HasMaxLength(100);
            entity.Property(e => e.ProductCount).HasColumnName("Product_count");
            entity.Property(e => e.ProductId).HasColumnName("Product_id");

            entity.HasOne(d => d.Partner).WithMany(p => p.PartnerProducts)
                .HasForeignKey(d => d.PartnerId)
                .HasConstraintName("FK_Partner_products_Partners");

            entity.HasOne(d => d.ProductNavigation).WithMany(p => p.PartnerProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Partner_products_Products");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.MaterialType)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("Material_type");
            entity.Property(e => e.MinimumCoastForPartner).HasColumnName("Minimum_coast_for_partner");
            entity.Property(e => e.ProductMaterialId).HasColumnName("Product_material_id");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .HasColumnName("Product_name");
            entity.Property(e => e.ProductType)
                .HasMaxLength(50)
                .HasColumnName("Product_type");
            entity.Property(e => e.ProductTypeId).HasColumnName("Product_type_id");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Product)
                .HasForeignKey<Product>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Material_type");

            entity.HasOne(d => d.ProductTypeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductTypeId)
                .HasConstraintName("FK_Products_Product_type");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.ToTable("Product_type");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.KoefProductType).HasColumnName("Koef_product_type");
            entity.Property(e => e.ProductType1)
                .HasMaxLength(50)
                .HasColumnName("Product_type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
