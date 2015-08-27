using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace WordConverter_v2.Models.Entity
{
    [Table("word_dic")]
    public class WordDic
    {
        [Key]
        public long word_id { get; set; }
        public string ronri_name1 { get; set; }
        public string ronri_name2 { get; set; }
        public string butsuri_name { get; set; }
        public long user_id { get; set; }
        public Int64 version { get; set; }
        public string cre_date { get; set; }
        public virtual UserMst User { get; set; }
    }
}
