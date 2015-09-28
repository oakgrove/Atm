using Atm.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Atm.DAL
{
    public class AtmDbContext : DbContext
    {
        public DbSet<ClickLog> ClickLogs { get; set; }

        public DbSet<BankAccount> Accounts { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}