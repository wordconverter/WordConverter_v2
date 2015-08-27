using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordConverter_v2.Models
{
    public class ShinseiBo
    {
        public long shinsei_id { get; set; }
        public string ronri_name1 { get; set; }
        public string ronri_name2 { get; set; }
        public string butsuri_name { get; set; }
        public string status { get; set; }
        public string user_name { get; set; }
        public int version { get; set; }
        public string cre_date { get; set; }

    }
}
