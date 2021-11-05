using Microsoft.EntityFrameworkCore;

namespace ApiKeyAuth.Api
{
    public class EfContext : DbContext
    {
        public EfContext(DbContextOptions<EfContext> options)
            : base(options)
        {
        }

        public DbSet<ApiKey> ApiKeys { get; set; }
    }
}