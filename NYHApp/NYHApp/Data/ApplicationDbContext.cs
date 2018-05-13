﻿using System;
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
        public DbSet<Country> Countries { get; set; }

        public DbSet<Help> Helps { get; set; }

        public DbSet<Enterprise> Enterprises { get; set; }

        public DbSet<TypeRoad> TypesRoad { get; set; }

        public DbSet<LineProposal> LinesProposals { get; set; }

        public DbSet<Proposal> Proposals { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            UsersConfiguration(modelBuilder);
            EnterpriseConfiguration(modelBuilder);
            HelpConfiguration(modelBuilder);
            PhotoConfiguration(modelBuilder);
            ProposalConfiguration(modelBuilder);
        }

        private void UsersConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>().ToTable("Users").Property(u => u.PasswordHash).HasColumnName("Password");
            modelBuilder.Entity<ApplicationUser>().ToTable("Users").Property(u => u.PasswordHash).HasColumnName("Password");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");

            modelBuilder.Entity<ApplicationUser>().HasOne(f => f.Country).WithMany(z => z.Users).HasForeignKey(f => f.IdCountry);
            modelBuilder.Entity<ApplicationUser>().HasOne(f => f.TypeRoad).WithMany().HasForeignKey(f => f.IdTypeRoad);
            modelBuilder.Entity<ApplicationUser>().HasOne(f => f.Enterprise).WithMany(z => z.Users).HasForeignKey(f => f.IdEnterprise);
        }

        private void EnterpriseConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enterprise>().HasOne(f => f.Country).WithMany(z => z.Enterprises).HasForeignKey(f => f.IdCountry);
            modelBuilder.Entity<Enterprise>().HasOne(f => f.TypeRoad).WithMany().HasForeignKey(f => f.IdTypeRoad);
            modelBuilder.Entity<Enterprise>().HasOne(f => f.UserAdministrator).WithMany().HasForeignKey(f => f.IdUserAdministrator);
            modelBuilder.Entity<Enterprise>().HasOne(f => f.UserLastModified).WithMany().HasForeignKey(f => f.IdUserLastModified);
        }

        private void HelpConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Help>().HasOne(f => f.Country).WithMany(z => z.Helps).HasForeignKey(f => f.IdCountry);
            modelBuilder.Entity<Help>().HasOne(f => f.TypeRoad).WithMany().HasForeignKey(f => f.IdTypeRoad);
            modelBuilder.Entity<Help>().HasOne(f => f.UserHelp).WithMany(f => f.Helps).HasForeignKey(f => f.IdUser).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Help>().HasOne(f => f.UserLastModified).WithMany().HasForeignKey(f => f.IdUserLastModified);
        }

        private void PhotoConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Photo>().HasOne(f => f.Help).WithMany(f => f.Photos).HasForeignKey(f => f.IdHelp).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Photo>().HasOne(f => f.UserLastModified).WithMany().HasForeignKey(f => f.IdUserLastModified);
        }

        private void ProposalConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proposal>().HasOne(f => f.Help).WithMany(z=>z.Proposals).HasForeignKey(f => f.IdHelp).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Proposal>().HasOne(f => f.Enterprise).WithMany(z => z.Proposals).HasForeignKey(f => f.IdEnterprise).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Proposal>().HasOne(f => f.UserLastModified).WithMany().HasForeignKey(f => f.IdUserLastModified);
        }

        private void LineProposalConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LineProposal>().HasOne(f => f.Proposal).WithMany(f => f.LinesProposals).HasForeignKey(f => f.IdProposal).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<LineProposal>().HasOne(f => f.UserLastModified).WithMany().HasForeignKey(f => f.IdUserLastModified);
        }
    }
}
