using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atm.Models
{
    public class ClickLog
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string TurnOut { get; set; }
        public double Amount { get; set; }
        public string EventType { get; set; }
    }
}