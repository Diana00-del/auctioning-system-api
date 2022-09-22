using AuctionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AuctionAPI.Contexts
{
    public class AuctionContext : DbContext
    {
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<PasswordReset> PasswordResets { get; set; }
        public DbSet<EmailVerification> EmailVerifications { get; set; }

        public AuctionContext(DbContextOptions<AuctionContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auction>().HasMany(a => a.Bids).WithOne(b => b.Auction).HasForeignKey(b => b.AuctionId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Auction>().HasMany(a => a.Photos).WithOne(p => p.Auction).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>().HasMany(u => u.Auctions).WithOne(a => a.User).HasForeignKey(a => a.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>().HasMany(u => u.Bids).WithOne(b => b.User).HasForeignKey(b => b.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>().HasMany(u => u.Photos).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>().HasMany(u => u.Sessions).WithOne(s => s.User).HasForeignKey(s => s.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>().HasMany(u => u.PasswordResets).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>().HasMany(u => u.EmailVerifications).WithOne(e => e.User).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Cascade);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=26.34.26.212;Database=auction;Username=postgres;Password=1qaz@WSX");
        }
    }
}
