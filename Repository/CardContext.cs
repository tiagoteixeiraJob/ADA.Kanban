using Microsoft.EntityFrameworkCore;
using Model;

namespace Repository
{
    public class CardContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "DataSource=cards.db;Cache=Shared");
        }

        public DbSet<Card> Cards { get; set; }
    }
}
