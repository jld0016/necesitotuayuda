using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NYHApp.Models;

namespace NYHApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Province> Provinces { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Help> Helps { get; set; }

        public DbSet<ApplicationRoleGroup> RolesGroups { get; set; }

        public DbSet<ApplicationGroup> Groups { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        public static ApplicationDbContext Create() => new ApplicationDbContext();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            UsersConfiguration(modelBuilder);
            EnterpriseConfiguration(modelBuilder);
        }

        private void UsersConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>().ToTable("Users").Property(u => u.PasswordHash).HasColumnName("Password");
            modelBuilder.Entity<ApplicationUser>().ToTable("Users").Property(u => u.PasswordHash).HasColumnName("Password");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");

            modelBuilder.Entity<ApplicationUser>().HasOne(z => z.Group).WithMany(z => z.Users).HasForeignKey(z => z.IdGroup).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationRoleGroup>().HasKey(f => new { f.IdGroup, f.IdRole });
            modelBuilder.Entity<ApplicationRoleGroup>().HasOne(f => f.Role).WithMany().HasForeignKey(f => f.IdRole).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ApplicationRoleGroup>().HasOne(f => f.Group).WithMany(z => z.RolesGroups).HasForeignKey(f => f.IdGroup).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationUser>().HasOne(f => f.Province).WithMany(z => z.Users).HasForeignKey(z => z.IdProvince);
            modelBuilder.Entity<ApplicationUser>().HasOne(f => f.Country).WithMany(z => z.Users).HasForeignKey(f => f.IdCountry);
            modelBuilder.Entity<ApplicationUser>().HasOne(f => f.TypeRoad).WithMany().HasForeignKey(f => f.IdTypeRoad);
            modelBuilder.Entity<ApplicationUser>().HasOne(f => f.Enterprise).WithMany(z => z.Users).HasForeignKey(f => f.IdEnterprise);
        }

        private void EnterpriseConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enterprise>().HasOne(f => f.Province).WithMany(z => z.Enterprises).HasForeignKey(z => z.IdProvince);
            modelBuilder.Entity<Enterprise>().HasOne(f => f.Country).WithMany(z => z.Enterprises).HasForeignKey(f => f.IdCountry);
            modelBuilder.Entity<Enterprise>().HasOne(f => f.TypeRoad).WithMany().HasForeignKey(f => f.IdTypeRoad);
            modelBuilder.Entity<Enterprise>().HasOne(f => f.UserAdministrator).WithMany().HasForeignKey(f => f.IdUserAdministrator);
            modelBuilder.Entity<Enterprise>().HasOne(f => f.UserLastModified).WithMany().HasForeignKey(f => f.IdUserLastModified);
        }

        private void HelpConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Help>().HasOne(f => f.UserHelp).WithMany(f => f.Helps).HasForeignKey(f => f.IdUser).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Help>().HasOne(f => f.UserLastModified).WithMany().HasForeignKey(f => f.IdUserLastModified);
        }
    }
}
