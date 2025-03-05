using Domain;
using System.Drawing;
using DatabaseContextSeedworks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class DatabaseContext : BaseDbContextIdentity<User, Role, string>
{
#pragma warning disable CS8618
    public DatabaseContext
#pragma warning restore CS8618
        (DbContextOptions options)
        : base(options)
    {
    }

    public override DbSet<Role> Roles { get; set; }
    public override DbSet<User> Users { get; set; }
    
    public DbSet<OprationPage> OprationPages { get; set; }
    public DbSet<SubSystem> SubSystems { get; set; }
    public DbSet<SubSystemPage> SubSystemPages { get; set; }
    public DbSet<SubSystemPageOpration> SubSystemPageOprations { get; set; }
    public DbSet<UserRoleSubSystemPage> UserRoleSubSystemPages { get; set; }

    public DbSet<Captcha> Captchas { get; set; }

    public DbSet<City> Cities { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<TokenManager> TokenManagers { get; set; }
    public DbSet<MarketPlaceProfile> MarketPlaceProfiles { get; set; }

    #region OnConfiguring

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseLazyLoadingProxies();
    }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Settings relations and domains

        // modelBuilder.ApplyConfigurationsFromAssembly
        //     (assembly: typeof(Configurations.UserEntityTypeConfiguration).Assembly);

        modelBuilder.Entity<MarketPlaceProfile>()
            .HasOne(p => p.User)
            .WithOne(p => p.MarketPlaceProfile)
            .HasForeignKey<MarketPlaceProfile>(m => m.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<User>()
            .HasOne(p => p.MarketPlaceProfile)
            .WithOne(p => p.User)
            .HasForeignKey<User>(m => m.MarketPlaceProfileId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<MarketPlaceProfile>()
            .HasOne(p => p.Gender)
            .WithMany(p => p.MarketPlaceProfiles)
            .HasForeignKey(m => m.GenderId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<City>()
            .HasOne(p => p.Province)
            .WithMany(p => p.Cities)
            .HasForeignKey(p => p.ProvinceId)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<Captcha>()
            .HasOne(p => p.User)
            .WithMany(p => p.Captchas)
            .HasForeignKey(m => m.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<SubSystemPage>()
            .HasOne(p => p.SubSystem)
            .WithMany(p => p.SubSystemPage)
            .HasForeignKey(m => m.SubSystemId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<SubSystemPageOpration>()
            .HasOne(p => p.OprationPage)
            .WithMany(p => p.SubSystemPageOprations)
            .HasForeignKey(m => m.OprationPageId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<SubSystemPageOpration>()
            .HasOne(p => p.UserRoleSubSystemPage)
            .WithMany(p => p.SubSystemPageOprations)
            .HasForeignKey(m => m.UserRoleSubSystemPageId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity
                .HasMany(ur => ur.UserRoleSubSystemPages)
                .WithOne(ursp => ursp.UserRole)
                .HasForeignKey(ursp => new { ursp.UserId, ursp.RoleId})
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<UserRoleSubSystemPage>()
            .HasOne(x => x.SubSystemPage)
            .WithMany(x => x.UserRoleSubSystemPages)
            .HasForeignKey(x => x.SubSystemPageId)
            .OnDelete(DeleteBehavior.NoAction);

        base.OnModelCreating(modelBuilder);
    }
}