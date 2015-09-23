using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordConverter_v2.Models.Entity
{
    [Table("user_mst")]
    public class UserMst
    {
        [Key]
        public long user_id { get; set; }
        public int emp_id { get; set; }
        public string user_name { get; set; }
        public int kengen { get; set; }
        public string mail_id { get; set; }
        public string password { get; set; }
        public string mail_address { get; set; }
        public int sanka_kahi { get; set; }
        public int delete_flg { get; set; }
        public int version { get; set; }
        public string cre_date { get; set; }
        public virtual ICollection<WordDic> Words { get; set; }
        public virtual ICollection<WordShinsei> Shinseis { get; set; }
    }
}
