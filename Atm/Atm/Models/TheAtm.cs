﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atm.Models
{
    public class TheAtm
    {
        public int Id { get; set; }
        public List<Receipt> Receipts { get; set; }
    }
}