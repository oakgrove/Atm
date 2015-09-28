using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Atm.Models
{
    public class BankAccount
    {

        public int Id { get; set; }
        [Display(Name = "Kontonummer")]
        public int AccountNumber { get; set; }
        [Display(Name = "Kontonamn")]
        public string Name { get; set; }
        [Display(Name = "Saldo")]
        public double Balance { get; set; }
        public List<Transaction> Transactions { get; set; }

        public ApplicationUser User { get; set; }

    }
}