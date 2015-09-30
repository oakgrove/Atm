using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Atm.Models
{
    public class ClickLog
    {
        public int Id { get; set; }
        [Display(Name = "Tid")]
        public DateTime Time { get; set; }
        [Display(Name = "Utfall")]
        public string TurnOut { get; set; }
        [Display(Name = "Belopp")]
        public double Amount { get; set; }
        [Display(Name = "Typ av transaktion")]
        public string EventType { get; set; }

        public string UserName { get; set; }
    }
}