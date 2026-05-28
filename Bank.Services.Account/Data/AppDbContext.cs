using Bank.Services.AccountAPI.Models;
using Microsoft.EntityFrameworkCore;



namespace Bank.Services.AccountAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Accounts> Accounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Accounts>().HasData(
                new Accounts
                { Id = 1, Number = "1FFF4567890", Balance = 1000.00, OwnerId = 18726482 });
            modelBuilder.Entity<Accounts>().HasData(
                new Accounts
                { Id = 2, Number = "0987GTF321", Balance = 2000.00, OwnerId = 00483258 });

        }
    }
}
