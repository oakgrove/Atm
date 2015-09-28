using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atm.Models
{
    public class BankAccount
    {

        public int Id { get; set; }

        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public List<Transaction> Transactions { get; set; }


    }
}