using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Atm.Models
{
    public class WithdrawViewModel
    {
        [Required]
        [Display(Name = "Belopp")]
        public int Amount { get; set; }
        [Display(Name = "Skriv ut kvitto")]
        public bool PrintReceipt { get; set; } = false;
        [Display(Name = "Maila kvitto")]
        public bool EmailReceipt { get; set; } = false;
    }
}