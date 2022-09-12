using ElectronicsStore.Areas.Identity.Data;
using ElectronicsStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicsStore.Areas.Identity.Data;

public class ElectronicsStoreDataContext : IdentityDbContext<ElectronicsStoreUser>
{
    public ElectronicsStoreDataContext(DbContextOptions<ElectronicsStoreDataContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        //builder.ApplyConfiguration(new ApplicationUserEnityConfigration());
        //builder.Entity<ElectronicsStoreUser>().HasIndex(u => u.SellerId).IsUnique();
        //builder.Entity<Items>().HasIndex(u => u.SellerId).IsUnique();

    }

    public DbSet<Items> item { get; set; }
    public DbSet<ElectronicsStoreUser> electronicsStoresUser { get; set; }
   // public DbSet<Sellers> seller { get; set; }

    private class ApplicationUserEnityConfigration : IEntityTypeConfiguration<ElectronicsStoreUser>
    {
        public void Configure(EntityTypeBuilder<ElectronicsStoreUser> builder)
        {
            
            builder.Property(u => u.SellerFname).HasMaxLength(256);
            builder.Property(u => u.SellerLname).HasMaxLength(256);
            builder.Property(u => u.SDOB).HasMaxLength(256);
            builder.Property(u => u.SUsername).HasMaxLength(256);
            builder.Property(u => u.SPassword).HasMaxLength(256);
        }
    }

    
}
