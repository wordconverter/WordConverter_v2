using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordConverter_v2.Models
{
    class WordDicDispBo
    {
        public long word_id { get; set; }
        public string ronri_name1 { get; set; }
        public string ronri_name2 { get; set; }
        public string butsuri_name { get; set; }
        public string user_name { get; set; }
        public Int64 version { get; set; }
        public Int64 cre_date { get; set; }
    }
}
