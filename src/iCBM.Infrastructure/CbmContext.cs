using iCBM.Application;
using iCBM.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Misio.EntityFrameworkCore;

namespace iCBM.Infrastructure
{
    public class CbmContext : DbContextBase, ICbmContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        public CbmContext(DbContextOptions<CbmContext> options) : base(options)
        {

        }

        protected override string GetUser()
        {
            return "TODO";
        }
    }

    internal class CbmContextFactory : IDesignTimeDbContextFactory<CbmContext>
    {
        public CbmContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CbmContext>();
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NOT_EXISTING_DATABASE;Integrated Security=True;");

            return new CbmContext(optionsBuilder.Options);
        }
    }
}
