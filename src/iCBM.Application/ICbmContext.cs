using iCBM.Domain.Enums;
using iCBM.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace iCBM.Application
{
    public interface ICbmContext
    {
        DbSet<Expense> Expenses { get; set; }
        DbSet<Supplier> Suppliers { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<User> Users { get; set; }

        DbSet<Currency> Currencies { get; set; }
        DbSet<Color> Colors { get; set; }
    }
}
