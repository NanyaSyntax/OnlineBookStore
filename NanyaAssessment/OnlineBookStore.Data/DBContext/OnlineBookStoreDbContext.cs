using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineBookStore.Model.Entities;

namespace OnlineBookStore.Data.Context
{
    public class OnlineBookStoreDbContext : IdentityDbContext<User>
    {
        public OnlineBookStoreDbContext(DbContextOptions<OnlineBookStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<PurchaseHistory> PurchaseHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User - Book relationship
            modelBuilder.Entity<Book>()
                .HasOne(b => b.User)
                .WithMany(u => u.Books)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict); 

            // Cart - Book many-to-many relationship
            modelBuilder.Entity<Cart>()
                .HasMany(c => c.Books)
                .WithMany(b => b.Carts)
                .UsingEntity<Dictionary<string, object>>(
                    "CartBook",
                    j => j.HasOne<Book>().WithMany().HasForeignKey("BookId"),
                    j => j.HasOne<Cart>().WithMany().HasForeignKey("CartId"),
                    j => { j.HasKey("CartId", "BookId"); });

            // User - Cart relationship
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany(u => u.Carts)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict); 

            //PurchaseHistory relationships
            modelBuilder.Entity<PurchaseHistory>()
                .HasOne(ph => ph.User)
                .WithMany(u => u.PurchaseHistories)
                .HasForeignKey(ph => ph.UserId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<PurchaseHistory>()
                .HasOne(ph => ph.Book)
                .WithMany(b => b.PurchaseHistories)
                .HasForeignKey(ph => ph.BookId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
