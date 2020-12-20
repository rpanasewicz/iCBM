using Misio.EntityFrameworkCore;

namespace iCBM.Infrastructure
{
    public class CbmContext : DbContextBase
    {
        protected override string GetUser()
        {
            return "TODO";
        }
    }
}
