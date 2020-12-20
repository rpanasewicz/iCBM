using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCBM.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace iCBM.Application
{
    public interface ICbmContext
    {
        DbSet<Expense> Expenses { get; set; }
        DbSet<Currency> Currencies { get; set; }
    }
}
