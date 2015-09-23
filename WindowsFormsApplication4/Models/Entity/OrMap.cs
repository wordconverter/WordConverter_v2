using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordConverter_v2.Models.Entity
{
    [Table("or_map")]
    public class OrMap
    {
        [Key]
        public long or_id { get; set; }
        public string data_type { get; set; }
        public string db_data_type { get; set; }
        public string project_name { get; set; }
        public int yuko_flg { get; set; }
        public int delete_flg { get; set; }
        public int version { get; set; }
        public string cre_date { get; set; }
    }
}
