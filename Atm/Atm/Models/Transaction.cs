using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Atm.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        [Display(Name = "Tid")]
        public DateTime TransactionTime { get; set; }
        [Display(Name = "Typ av transaktion")]
        public string TransactionType { get; set; }
        [Display(Name = "Saldo")]
        public double Balance { get; set; }
        [Display(Name = "Belopp")]
        public double Amount { get; set; }

        public BankAccount Account { get; set; }
    }
}