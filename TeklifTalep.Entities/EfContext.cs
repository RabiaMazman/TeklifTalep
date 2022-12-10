using Microsoft.EntityFrameworkCore;
using TeklifTalep.Entities.DAL;

namespace TeklifTalep.Entities
{
    public class EfContext : DbContext
    {
        public EfContext(DbContextOptions<EfContext> options)
        : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        public DbSet<Teklifler> Teklifler { get; set; }
    }
}
