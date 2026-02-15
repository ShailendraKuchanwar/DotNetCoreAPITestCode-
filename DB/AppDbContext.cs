using ATMDotNetCoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ATMDotNetCoreApp.DB

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<LoginModel> Logins { get; set; }
        public DbSet<AtmTransactionModel> AtmTransactionModels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LoginModel>().ToTable("TblLoginMaster");
            modelBuilder.Entity<AtmTransactionModel>().ToTable("TblAtmTransaction");
        }
    }
}
