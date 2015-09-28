using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Atm.Models
{
    public class Money
    {
        public int Id { get; set; }
        [Display(Name = "Valör")]
        public int Denominator { get; set; }
        [Display(Name = "Återstående sedlar")]
        public int RemainingPieces { get; set; }

    }
}