using CourseProject.DAL.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.DAL.Context;

public class ApplicationDbContext : IdentityDbContext<UserInfo>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }


    public DbSet<Carousel> Carousel { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<CustomBanner> CustomBanner { get; set; }
    public DbSet<Feedback> Feedback { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<UserInfo> UserInfo { get; set; }
    public DbSet<UserAddress> UserAddress { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<OrdersItems> OrdersItems { get; set; }
    public DbSet<OrdersDetail> OrdersDetail { get; set; }


}
