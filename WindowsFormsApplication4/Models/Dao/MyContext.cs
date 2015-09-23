using System.Data.Entity;
using WordConverter_v2.Models.Entity;
using System.Data.Linq;
using System.Data.Common;

namespace WordConverter_v2.Models.Dao
{
    public class MyContext : DbContext
    {
        public MyContext(string connection)
            : base(@connection)
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<UserMst> UserMst { get; set; }
        public DbSet<WordDic> WordDic { get; set; }
        public DbSet<WordShinsei> WordShinsei { get; set; }
        public DbSet<OrMap> OrMap { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MyContext>(null);
            modelBuilder.HasDefaultSchema("public");
        }
    }
}
