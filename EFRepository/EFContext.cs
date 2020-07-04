using EFRepository.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFRepository
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options)
            : base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(u =>
            {
                u.HasKey(e => e.UserId);
                u.Property(e => e.Email).IsRequired();
                u.HasIndex(e => e.Email).IsUnique();
            });

            builder.Entity<Account>(a =>
            {
                a.HasOne(e => e.User).WithOne(p => p.Account).HasForeignKey<Account>(f => f.UserId);
                a.HasKey(e => e.AccountId);
            });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
