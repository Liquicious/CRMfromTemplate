using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.DbModels;

public partial class DefaultDbContext : DbContext
{
    public DefaultDbContext()
    {
    }

    public DefaultDbContext(DbContextOptions<DefaultDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookGenre> BookGenres { get; set; }

    public virtual DbSet<BooksAtWarehouse> BooksAtWarehouses { get; set; }

    public virtual DbSet<BooksInOrder> BooksInOrders { get; set; }

    public virtual DbSet<BooksInSupply> BooksInSupplies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerBook> CustomerBooks { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrdersByMonth> OrdersByMonths { get; set; }

    public virtual DbSet<OrdersOfCustomer> OrdersOfCustomers { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StoredBook> StoredBooks { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Supply> Supplies { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<WarehouseStaff> WarehouseStaffs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-AE5QJIA\\SQLEXPRESS01;Initial Catalog=dammmn;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.IdBook)
                .HasName("PK_Books_id_book")
                .IsClustered(false);

            entity.Property(e => e.IdBook).HasColumnName("id_book");
            entity.Property(e => e.Author)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("author");
            entity.Property(e => e.BookName)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("book_name");
            entity.Property(e => e.Country)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("country");
            entity.Property(e => e.YearOfWriting).HasColumnName("year_of_writing");
        });

        modelBuilder.Entity<BookGenre>(entity =>
        {
            entity.HasKey(e => new { e.IdBook, e.Genre })
                .HasName("PK_Book_genres_book_genre")
                .IsClustered(false);

            entity.ToTable("Book_genres");

            entity.Property(e => e.IdBook).HasColumnName("id_book");
            entity.Property(e => e.Genre)
                .HasMaxLength(15)
                .HasColumnName("genre");

            entity.HasOne(d => d.IdBookNavigation).WithMany(p => p.BookGenres)
                .HasForeignKey(d => d.IdBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book_genres_id_book");
        });

        modelBuilder.Entity<BooksAtWarehouse>(entity =>
        {
            entity.HasKey(e => new { e.IdWarehouse, e.IdBook })
                .HasName("PK_Books_at_warehouse_book_at_warehouse")
                .IsClustered(false);

            entity.ToTable("Books_at_warehouse");

            entity.Property(e => e.IdWarehouse).HasColumnName("id_warehouse");
            entity.Property(e => e.IdBook).HasColumnName("id_book");
            entity.Property(e => e.QuantityInStock).HasColumnName("quantity_in_stock");

            entity.HasOne(d => d.IdBookNavigation).WithMany(p => p.BooksAtWarehouses)
                .HasForeignKey(d => d.IdBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_at_warehouse_id_book");

            entity.HasOne(d => d.IdWarehouseNavigation).WithMany(p => p.BooksAtWarehouses)
                .HasForeignKey(d => d.IdWarehouse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_at_warehouse_id_warehouse");
        });

        modelBuilder.Entity<BooksInOrder>(entity =>
        {
            entity.HasKey(e => new { e.IdOrder, e.IdBook })
                .HasName("PK_Books_in_order_book_in_order")
                .IsClustered(false);

            entity.ToTable("Books_in_order");

            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.IdBook).HasColumnName("id_book");
            entity.Property(e => e.IdSupply).HasColumnName("id_supply");
            entity.Property(e => e.QuantityInOrder).HasColumnName("quantity_in_order");

            entity.HasOne(d => d.IdBookNavigation).WithMany(p => p.BooksInOrders)
                .HasForeignKey(d => d.IdBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_in_order_id_book");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.BooksInOrders)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_in_order_id_order");

            entity.HasOne(d => d.IdSupplyNavigation).WithMany(p => p.BooksInOrders)
                .HasForeignKey(d => d.IdSupply)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_in_order_id_supply");
        });

        modelBuilder.Entity<BooksInSupply>(entity =>
        {
            entity.HasKey(e => new { e.IdSupply, e.IdBook })
                .HasName("PK_Books_in_supply_book_in_supply")
                .IsClustered(false);

            entity.ToTable("Books_in_supply");

            entity.Property(e => e.IdSupply).HasColumnName("id_supply");
            entity.Property(e => e.IdBook).HasColumnName("id_book");
            entity.Property(e => e.BookPrice).HasColumnName("book_price");
            entity.Property(e => e.QuantityInSupply).HasColumnName("quantity_in_supply");

            entity.HasOne(d => d.IdBookNavigation).WithMany(p => p.BooksInSupplies)
                .HasForeignKey(d => d.IdBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_in_supply_id_book");

            entity.HasOne(d => d.IdSupplyNavigation).WithMany(p => p.BooksInSupplies)
                .HasForeignKey(d => d.IdSupply)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_in_supply_id_supply");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.IdCustomer)
                .HasName("PK_Customers_id_customer")
                .IsClustered(false);

            entity.Property(e => e.IdCustomer).HasColumnName("id_customer");
            entity.Property(e => e.CustomerAge).HasColumnName("customer_age");
            entity.Property(e => e.CustomerName)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("customer_name");
            entity.Property(e => e.CustomerSex)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("customer_sex");
        });

        modelBuilder.Entity<CustomerBook>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Customer_books");

            entity.Property(e => e.Book)
                .IsRequired()
                .HasMaxLength(30);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder)
                .HasName("PK_id_order")
                .IsClustered(false);

            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.DateOfOrder)
                .HasColumnType("datetime")
                .HasColumnName("date_of_order");
            entity.Property(e => e.IdCustomer).HasColumnName("id_customer");
            entity.Property(e => e.IdWarehouse).HasColumnName("id_warehouse");
            entity.Property(e => e.OrderAssemblyTime).HasColumnName("order_assembly_time");
            entity.Property(e => e.OrderCost).HasColumnName("order_cost");

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_id_customer");

            entity.HasOne(d => d.IdWarehouseNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdWarehouse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_id_warehouse");
        });

        modelBuilder.Entity<OrdersByMonth>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Orders_by_months");
        });

        modelBuilder.Entity<OrdersOfCustomer>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Orders_of_customer");

            entity.Property(e => e.DateOfOrder)
                .HasColumnType("datetime")
                .HasColumnName("date_of_order");
            entity.Property(e => e.IdCustomer).HasColumnName("id_customer");
            entity.Property(e => e.OrderCost).HasColumnName("order_cost");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.IdEmployee)
                .HasName("PK_Staff_id_employee")
                .IsClustered(false);

            entity.Property(e => e.IdEmployee).HasColumnName("id_employee");
            entity.Property(e => e.EmployeeName)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("employee_name");
            entity.Property(e => e.EmployeeSex)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("employee_sex");
            entity.Property(e => e.Experience).HasColumnName("experience");
            entity.Property(e => e.IdWarehouse).HasColumnName("id_warehouse");
            entity.Property(e => e.JobTitle)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("job_title");

            entity.HasOne(d => d.IdWarehouseNavigation).WithMany(p => p.Staff)
                .HasForeignKey(d => d.IdWarehouse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Staff_id_warehouse");
        });

        modelBuilder.Entity<StoredBook>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Stored_Books");

            entity.Property(e => e.Book)
                .IsRequired()
                .HasMaxLength(30);
            entity.Property(e => e.BookId).HasColumnName("Book_ID");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.IdSupplier)
                .HasName("PK_Suppliers_id_supplier")
                .IsClustered(false);

            entity.Property(e => e.IdSupplier).HasColumnName("id_supplier");
            entity.Property(e => e.SupplierName)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("supplier_name");
        });

        modelBuilder.Entity<Supply>(entity =>
        {
            entity.HasKey(e => e.IdSupply)
                .HasName("PK_Supplies_id_supply")
                .IsClustered(false);

            entity.Property(e => e.IdSupply).HasColumnName("id_supply");
            entity.Property(e => e.DateOfDelivery)
                .HasColumnType("date")
                .HasColumnName("date_of_delivery");
            entity.Property(e => e.IdSupplier).HasColumnName("id_supplier");
            entity.Property(e => e.IdWarehouse).HasColumnName("id_warehouse");

            entity.HasOne(d => d.IdSupplierNavigation).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.IdSupplier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Supplies_id_supplier");

            entity.HasOne(d => d.IdWarehouseNavigation).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.IdWarehouse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Supplies_id_warehouse");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Login, "Unique_Users_Login").IsUnique();

            entity.Property(e => e.Login)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.Password).IsRequired();
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.IdWarehouse)
                .HasName("PK_Warehouses_id_warehouse")
                .IsClustered(false);

            entity.Property(e => e.IdWarehouse).HasColumnName("id_warehouse");
            entity.Property(e => e.AdressWarehouse)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("adress_warehouse");
        });

        modelBuilder.Entity<WarehouseStaff>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Warehouse_staff");

            entity.Property(e => e.Employee).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
