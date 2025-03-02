﻿using identity_signup.Areas.Instructor.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace identity_singup.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Education> Education { get; set; }
        public DbSet<PermissionRequest> PermissionRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PermissionRequest>()
                .Property(p => p.RequestDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Education>()
                .Property(e => e.EduPrice)
                .HasPrecision(9, 2);  // 9 toplam basamak, 2 ondalık basamak
        }
    }
}
