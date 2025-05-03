using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Master_Paul_App
{
    public partial class MasterPaulBDContext : DbContext
    {
        public MasterPaulBDContext()
        {
        }

        public MasterPaulBDContext(DbContextOptions<MasterPaulBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaterialTypeImport> MaterialTypeImports { get; set; } = null!;
        public virtual DbSet<PartnerProductsImport> PartnerProductsImports { get; set; } = null!;
        public virtual DbSet<PartnersImport> PartnersImports { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductType> ProductTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDb;Database=Master_Paul_BD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaterialTypeImport>(entity =>
            {
                entity.ToTable("Material_type_import");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TypeOfMaterial)
                    .HasMaxLength(50)
                    .HasColumnName("Type_of_material");

                entity.Property(e => e.TypeOfMaterial2)
                    .HasMaxLength(50)
                    .HasColumnName("Type_of_material2");
            });

            modelBuilder.Entity<PartnerProductsImport>(entity =>
            {
                entity.ToTable("Partner_products_import");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateOfSale)
                    .HasColumnType("date")
                    .HasColumnName("Date_of_sale");

                entity.Property(e => e.NumberOfProducts).HasColumnName("Number_of_products");

                entity.Property(e => e.PartnerNameId).HasColumnName("Partner_name_Id");

                entity.Property(e => e.PartnerSName)
                    .HasMaxLength(50)
                    .HasColumnName("Partner_s_name");

                entity.Property(e => e.Products).HasMaxLength(100);

                entity.Property(e => e.ProudctId).HasColumnName("Proudct_Id");

                entity.HasOne(d => d.PartnerName)
                    .WithMany(p => p.PartnerProductsImports)
                    .HasForeignKey(d => d.PartnerNameId)
                    .HasConstraintName("FK_Partner_products_import_Partners_import");

                entity.HasOne(d => d.Proudct)
                    .WithMany(p => p.PartnerProductsImports)
                    .HasForeignKey(d => d.ProudctId)
                    .HasConstraintName("FK_Partner_products_import_Products");
            });

            modelBuilder.Entity<PartnersImport>(entity =>
            {
                entity.ToTable("Partners_import");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Director).HasMaxLength(50);

                entity.Property(e => e.Inn).HasColumnName("INN");

                entity.Property(e => e.PartnerEmailAddress)
                    .HasMaxLength(50)
                    .HasColumnName("Partner_email_address");

                entity.Property(e => e.PartnerLegalAddress)
                    .HasMaxLength(100)
                    .HasColumnName("Partner_legal_address");

                entity.Property(e => e.PartnerName)
                    .HasMaxLength(50)
                    .HasColumnName("Partner_name");

                entity.Property(e => e.PartnerPhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("Partner_phone_number");

                entity.Property(e => e.PartnerType)
                    .HasMaxLength(50)
                    .HasColumnName("Partner_Type");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ArticleNumber).HasColumnName("Article_number");

                entity.Property(e => e.Material).HasMaxLength(100);

                entity.Property(e => e.MaterialTypeId).HasColumnName("Material_Type_Id");

                entity.Property(e => e.MinimumCostForAPartner).HasColumnName("Minimum_cost_for_a_partner");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(200)
                    .HasColumnName("Product_Name");

                entity.Property(e => e.ProductType)
                    .HasMaxLength(50)
                    .HasColumnName("Product_Type");

                entity.Property(e => e.ProductTypeId).HasColumnName("Product_Type_Id");

                entity.HasOne(d => d.MaterialType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.MaterialTypeId)
                    .HasConstraintName("FK_Products_Material_type_import");

                entity.HasOne(d => d.ProductTypeNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTypeId)
                    .HasConstraintName("FK_Products_Product_type");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("Product_type");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ProductType1)
                    .HasMaxLength(50)
                    .HasColumnName("Product_Type");

                entity.Property(e => e.ProductTypeCoefficient).HasColumnName("Product_type_coefficient");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
