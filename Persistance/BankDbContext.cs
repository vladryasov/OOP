using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Entities.Accounts;
using Persistance.Configurations;
using Persistence.Configurations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Persistance
{
    public class BankDbContext : DbContext
    {
        public BankDbContext()
        {

        }
        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<SalaryProject> SalaryProjects { get; set; }
        public DbSet<MyTransaction> MyTransactions { get; set; }
        public DbSet<Credit> Credits { get; set; }
        public DbSet<Installment> Installments { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<BaseAccount> BaseAccounts { get; set; }
        public DbSet<CreditAccount> CreditAccounts { get; set; }
        public DbSet<EnterpriseAccount> EnterpriseAccounts { get; set; }
        public DbSet<SavingsAccount> SavingsAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BankConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CreditAccountConfiguration());
            modelBuilder.ApplyConfiguration(new CreditConfiguration());
            modelBuilder.ApplyConfiguration(new EnterpriseAccountConfiguration());
            modelBuilder.ApplyConfiguration(new EnterpriseConfiguration());
            modelBuilder.ApplyConfiguration(new BaseAccountConfiguration());
            modelBuilder.ApplyConfiguration(new SalaryProjectConfiguration());
            modelBuilder.ApplyConfiguration(new MyTransactionConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                optionsBuilder.UseSqlite($"Data Source = D:\\laba\\OOP\\BankConsole\\Persistance\\bank.db");
            }
        }
    }
}
