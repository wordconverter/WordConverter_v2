using System;
using WordConverter_v2.Interface;

namespace WordConverter_v2.Models
{
    public class HenshuWordBo : IBo
    {
        public long word_id { get; set; }
        public string ronri_name1 { get; set; }
        public string butsuri_name { get; set; }
        public string data_type { get; set; }
        public string user_name { get; set; }
        public string cre_date { get; set; }
        public Byte[] version { get; set; }
        
    }
}
