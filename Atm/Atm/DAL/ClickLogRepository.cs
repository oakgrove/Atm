using Atm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atm.DAL
{
    public class ClickLogRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public void WriteToClickLog(ClickLog clickLogEntry)
        {
            context.ClickLogs.Add(clickLogEntry);
            context.SaveChanges();
        }
    }
}