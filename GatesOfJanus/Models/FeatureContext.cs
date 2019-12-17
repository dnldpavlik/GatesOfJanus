using Microsoft.EntityFrameworkCore;

namespace GatesOfJanus.Models
{
    public class FeatureContext : DbContext
    {
        public FeatureContext(DbContextOptions<FeatureContext> options)
            : base(options)
        {
        }

        public DbSet<Feature> Feature { get; set; }
    }
}
