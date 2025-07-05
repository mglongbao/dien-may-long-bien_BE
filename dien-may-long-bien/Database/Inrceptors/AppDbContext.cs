using DienMayLongBien.Domain.Entities;
using DienMayLongBien.Domain.Entities.Settings;
using Microsoft.EntityFrameworkCore;

namespace DienMayLongBien.Database.Inrceptors;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Brand> Brands { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<CustomerEditHistory> CustomerEditHistories { get; set; } = null!;
    public DbSet<ImportHistory> ImportHistories { get; set; } = null!;
    public DbSet<InstallmentPayment> InstallmentPayments { get; set; }
    public DbSet<InstallmentPlan> InstallmentPlans { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<ProductEditHistory> ProductEditHistories { get; set; } = null!;
    public DbSet<ProductOrder> ProductOrders { get; set; } = null!;
    public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<SupplierEditHistory> SupplierEditHistories { get; set; } = null!;
    public DbSet<User> Users { get; set; }
    public DbSet<UserAction> UserActions { get; set; }

    // Setting
    public DbSet<StoreSetting> StoreSettings { get; set; } = null!;
    public DbSet<SystemSetting> SystemSettings { get; set; } = null!;
}
