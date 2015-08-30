namespace WordConvertTool
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using WordConvTool.Model;

    public class MyContext : DbContext
    {
        public System.Data.Entity.DbSet<WordDic> WordDic { get; set; }
        public System.Data.Entity.DbSet<WordShinsei> WordShinsei { get; set; }
        public System.Data.Entity.DbSet<UserMst> UserMst { get; set; }
     }

}