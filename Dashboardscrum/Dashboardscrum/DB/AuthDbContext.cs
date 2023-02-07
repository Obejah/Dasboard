using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Dashboardscrum.Models;
using Dashboardscrum.Repositories;

namespace Dashboardscrum.DB;

public class AuthDbContext : IdentityDbContext<ApplicationUser>
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Standup> Standup { get; set; } = null!;
    public DbSet<Team> Team { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //Data seeding
        builder.Entity<IdentityRole>().HasData(new List<IdentityRole>
        {
            new() { Name = "Docent", NormalizedName = "DOCENT" },
            new() { Name = "Student", NormalizedName = "STUDENT" },
        });
        //Renaming
        builder.Entity<ApplicationUser>(entity => { entity.ToTable("User"); });
        builder.Entity<IdentityRole>(entity => { entity.ToTable("Role"); });
        builder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("UserRoles"); });
        builder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("UserClaims"); });
        builder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("UserLogins"); });
        builder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("RoleClaims"); });
        builder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("UserTokens"); });
    }
}