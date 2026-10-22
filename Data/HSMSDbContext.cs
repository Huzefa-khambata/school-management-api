using Microsoft.EntityFrameworkCore;

namespace HSMS.API.Data
{
    public class HSMSDbContext : DbContext
    {
        public HSMSDbContext(DbContextOptions<HSMSDbContext> options)
            : base(options)
        {
        }
    }
}