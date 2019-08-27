using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Panda.Domain;
using System;

namespace Panda.Data
{
    public class PandaDbContext : IdentityDbContext<PandaUser, PandaUserRole, string>
    {
        public PandaDbContext(DbContextOptions<PandaDbContext> options) : base(options)
        {

        }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Receipt> Receipts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PandaUser>()
                .HasKey(user => user.Id);

            builder.Entity<PandaUser>()
                .HasMany(user => user.Packages)
                .WithOne(package => package.Recipient)
                .HasForeignKey(package => package.RecipientId);

            builder.Entity<PandaUser>()
                .HasMany(user => user.Receipts)
                .WithOne(receipt => receipt.Recipient)
                .HasForeignKey(receipt => receipt.RecipientId);

            builder.Entity<Package>()
                .HasOne(package => package.Receipt)
                .WithOne(receipt => receipt.Package)
                .HasForeignKey<Receipt>(receipt => receipt.PackageId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
