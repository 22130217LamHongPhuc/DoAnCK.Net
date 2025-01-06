using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace API.Net.Models;

public partial class DbtestContext : DbContext
{
    public DbtestContext()
    {
    }

    public DbtestContext(DbContextOptions<DbtestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Newtype> Newtypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductReview> ProductReviews { get; set; }

    public virtual DbSet<ProductView> ProductViews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Specification> Specifications { get; set; }

    public virtual DbSet<Subcategory> Subcategories { get; set; }

    public virtual DbSet<Subimage> Subimages { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    public virtual DbSet<Vouchertype> Vouchertypes { get; set; }

 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("category");

            entity.Property(e => e.CategoryId)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("CategoryID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PRIMARY");

            entity.ToTable("contact");

            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'");
            entity.Property(e => e.Fullname)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'");
            entity.Property(e => e.Message)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.NewId).HasName("PRIMARY");

            entity.ToTable("news");

            entity.Property(e => e.NewId)
                .ValueGeneratedOnAdd()
                .HasColumnName("NewID");
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("Create_At");
            entity.Property(e => e.NewTypeId).HasColumnName("NewTypeID");
            entity.Property(e => e.Thumbnail).HasMaxLength(255);
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            entity.HasOne(d => d.New).WithOne(p => p.News)
                .HasForeignKey<News>(d => d.NewId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Newtype>(entity =>
        {
            entity.HasKey(e => e.NewTypeId).HasName("PRIMARY");

            entity.ToTable("newtype");

            entity.Property(e => e.NewTypeId)
                .ValueGeneratedNever()
                .HasColumnName("NewTypeID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("'0'");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.OrderStatusId, "FK_order_order_status");
            entity.HasIndex(e => e.PaymentId, "PaymentID");
            entity.HasIndex(e => e.UserId, "UserID");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Fullname).HasMaxLength(100);
            entity.Property(e => e.OrderStatusId).HasColumnName("OrderStatusID");
            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.TotalPrice)
                .HasPrecision(10, 2)
                .HasColumnName("totalPrice");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            // Ánh xạ các thuộc tính mới
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("Note");
            entity.Property(e => e.fee)
                .HasColumnName("fee");
            entity.Property(e => e.discount)
                .HasColumnName("discount");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_order_order_status");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("orders_ibfk_1");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("order_detail");

            entity.HasIndex(e => e.ProductId, "ProductID");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(100)
                .HasColumnName("ProductID");
            entity.Property(e => e.TotalPrice).HasPrecision(10, 2);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_order_detail_orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_order_detail_products");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.OrderStatusId).HasName("PRIMARY");

            entity.ToTable("order_status");

            entity.Property(e => e.OrderStatusId)
                .ValueGeneratedNever()
                .HasColumnName("OrderStatusID");
            entity.Property(e => e.NameStatus).HasMaxLength(50);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PRIMARY");

            entity.ToTable("payment");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.MethodPayment).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.SubcategoryId, "FK_products_subcategory");

            entity.Property(e => e.ProductId)
                .HasMaxLength(100)
                .HasColumnName("ProductID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.SubcategoryId)
                .HasMaxLength(50)
                .HasDefaultValueSql("'LV-BLV'")
                .HasColumnName("SubcategoryID");
            entity.Property(e => e.Thumbnail).HasMaxLength(255);

            entity.HasOne(d => d.Subcategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.SubcategoryId)
                .HasConstraintName("FK_products_subcategory");
        });

        modelBuilder.Entity<ProductReview>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PRIMARY");

            entity.ToTable("product_reviews");

            entity.HasIndex(e => e.ProductId, "FK_product_reviews_products");

            entity.HasIndex(e => e.UserId, "FK_product_reviews_user");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.Comment).HasColumnType("text");
            entity.Property(e => e.CreatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.Fullname).HasMaxLength(50);
            entity.Property(e => e.ProductId)
                .HasMaxLength(100)
                .HasColumnName("ProductID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductReviews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_reviews_products");

            entity.HasOne(d => d.User).WithMany(p => p.ProductReviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_reviews_user");
        });

        modelBuilder.Entity<ProductView>(entity =>
        {
            entity.HasKey(e => e.ProductViewId).HasName("PRIMARY");

            entity.ToTable("product_views");

            entity.HasIndex(e => e.ProductId, "FK_product_views_products");

            entity.Property(e => e.ProductViewId).HasColumnName("ProductViewID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(100)
                .HasColumnName("ProductID");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductViews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_views_products");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity.ToTable("role");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("RoleID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<Specification>(entity =>
        {
            entity.HasKey(e => e.SpecificationId).HasName("PRIMARY");

            entity.ToTable("specifications");

            entity.HasIndex(e => e.ProductId, "FK_specifications_products");

            entity.Property(e => e.SpecificationId)
                .HasMaxLength(100)
                .HasColumnName("SpecificationID");
            entity.Property(e => e.Dimensions)
                .HasMaxLength(255)
                .HasDefaultValueSql("'Dài 192cm x Rộng 132cm x Cao 72cm'")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Material)
                .HasMaxLength(255)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Original)
                .HasMaxLength(100)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ProductId)
                .HasMaxLength(100)
                .HasColumnName("ProductID");
            entity.Property(e => e.Standard)
                .HasMaxLength(255)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            entity.HasOne(d => d.SpecificationNavigation).WithOne(p => p.Specification)
                .HasForeignKey<Specification>(d => d.SpecificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_1_1_spec_pro");
        });

        modelBuilder.Entity<Subcategory>(entity =>
        {
            entity.HasKey(e => e.SubcategoryId).HasName("PRIMARY");

            entity.ToTable("subcategory");

            entity.HasIndex(e => e.CategoryId, "FK_subcategory_category");

            entity.Property(e => e.SubcategoryId)
                .HasMaxLength(50)
                .HasColumnName("SubcategoryID");
            entity.Property(e => e.CategoryId)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("CategoryID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("NAME")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Thumbnail).HasMaxLength(255);

            entity.HasOne(d => d.Category).WithMany(p => p.Subcategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_subcategory_category");
        });

        modelBuilder.Entity<Subimage>(entity =>
        {
            entity.HasKey(e => e.SubImagesId).HasName("PRIMARY");

            entity.ToTable("subimages");

            entity.HasIndex(e => e.ProductId, "FK_subimages_products");

            entity.Property(e => e.SubImagesId).HasColumnName("SubImagesID");
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.ProductId)
                .HasMaxLength(100)
                .HasColumnName("ProductID");

            entity.HasOne(d => d.Product).WithMany(p => p.Subimages)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_subimages_products");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.RoleId, "FK_user_role");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreateAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_role");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.VoucherId).HasName("PRIMARY");

            entity.ToTable("voucher");

            entity.HasIndex(e => e.Code, "Code").IsUnique();

            entity.HasIndex(e => e.TypeId, "FK_voucher_vouchertype");

            entity.Property(e => e.VoucherId).HasColumnName("VoucherID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.TypeId).HasColumnName("TypeID");
            entity.Property(e => e.VoucherPercent).HasColumnName("VoucherPercent")
            .HasColumnType("int");

            entity.Property(e => e.VoucherCash)
           .HasColumnName("VoucherCash")
           .HasColumnType("int");

            entity.Property(e => e.MaximumValue)
                .HasColumnName("MaximumValue")
                .HasColumnType("int");

            entity.Property(e => e.StartDate)
                .HasColumnName("StartDate")
                .HasColumnType("date");

            entity.Property(e => e.EndDate)
                .HasColumnName("EndDate")
                .HasColumnType("date");

            entity.Property(e => e.MinOrderValue)
                .HasColumnName("MinOrderValue")
                .HasColumnType("int");

            entity.HasOne(d => d.Type).WithMany(p => p.Vouchers)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK_voucher_vouchertype");
        });

        modelBuilder.Entity<Vouchertype>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PRIMARY");

            entity.ToTable("vouchertype");

            entity.Property(e => e.TypeId)
                .ValueGeneratedNever()
                .HasColumnName("TypeID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
