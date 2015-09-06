using System.Data.Entity;
using WordConverter_v2.Models.Entity;
using System.Data.Linq;

namespace WordConverter_v2.Models.Dao
{
    public class MyContext : DbContext
    {
        public DbSet<UserMst> UserMst { get; set; }
        public DbSet<WordDic> WordDic { get; set; }
        public DbSet<WordShinsei> WordShinsei { get; set; }
        public DbSet<OrMap> OrMap { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
        }
    }
}
