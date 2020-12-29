using iCBM.Domain.Enums;
using iCBM.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace iCBM.Application
{
    public interface ICbmContext
    {
        DbSet<Expense> Expenses { get; }
        DbSet<Supplier> Suppliers { get; }
        DbSet<Category> Categories { get; }
        DbSet<Notification> Notifications { get; }
        DbSet<NotificationReads> NotificationReads { get; }
        DbSet<User> Users { get; }

        DbSet<Currency> Currencies { get; }
        DbSet<Color> Colors { get; }
    }
}
