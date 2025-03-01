using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Entities.Accounts;

namespace Persistance
{
    public class BankDbContext : DbContext
    {
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
    }
}
