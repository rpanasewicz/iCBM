using iCBM.Application;
using iCBM.Domain.Enums;
using iCBM.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Misio.Common.Auth.Abstractions;
using Misio.EntityFrameworkCore;
using System;

namespace iCBM.Infrastructure
{
    public class CbmContext : DbContextBase, ICbmContext
    {
        private readonly IAuthProvider _authProvider;
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationReads> NotificationReads { get; set; }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Color> Colors { get; set; }

        public CbmContext(DbContextOptions<CbmContext> options, IAuthProvider authProvider) : base(options)
        {
            _authProvider = authProvider;

            try
            {
                UserId = _authProvider?.UserId ?? Guid.Empty;
            }
            catch (NullReferenceException)
            {
            }
        }

        protected override Guid GetUser() => _authProvider?.UserId ?? Guid.Empty;
    }

    internal class CbmContextFactory : IDesignTimeDbContextFactory<CbmContext>
    {
        public CbmContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CbmContext>();
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NOT_EXISTING_DATABASE;Integrated Security=True;");

            return new CbmContext(optionsBuilder.Options, new EmptyAuthProvider());
        }

        private class EmptyAuthProvider : IAuthProvider
        {
            public Guid UserId => Guid.Empty;
        }
    }
}
