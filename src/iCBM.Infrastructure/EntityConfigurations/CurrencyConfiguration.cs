using iCBM.Domain.Models;
using Misio.EntityFrameworkCore;

namespace iCBM.Infrastructure.EntityConfigurations
{
    public class CurrencyConfiguration : BaseEnumerationConfiguration<Currency>
    {
        public override string TableName => "Currencies";
        public override string PrimaryKeyColumnName => "Id";
    }
}
