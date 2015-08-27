using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Linq;
using System.Text;

namespace WordConverter_v2.Models.Entity
{
    [Table("word_shinsei")]
    public class WordShinsei
    {
        [Key]
        public long shinsei_id { get; set; }
        public string ronri_name1 { get; set; }
        public string ronri_name2 { get; set; }
        public string butsuri_name { get; set; }
        public int word_id { get; set; }
        public int status { get; set; }
        public long user_id { get; set; }
        public int version { get; set; }
        public string cre_date { get; set; }
        public virtual UserMst User { get; set; }
    }
}
