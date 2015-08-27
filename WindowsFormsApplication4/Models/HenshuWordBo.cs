using WordConvTool.Service;

namespace WordConverter_v2.Models
{
    public class HenshuWordBo : IBo
    {
        public long word_id { get; set; }
        public string ronri_name1 { get; set; }
        public string ronri_name2 { get; set; }
        public string butsuri_name { get; set; }
        public string user_name { get; set; }
        public string cre_date { get; set; }
        public int version { get; set; }
        
    }
}
