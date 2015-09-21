using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordConverter_v2.Models
{
    public class UserBo
    {
        public long user_id { get; set; }
        public int emp_id { get; set; }
        public string user_name { get; set; }
        public int kengen { get; set; }
        public bool sanka_kahi { get; set; }
        public string mail_id { get; set; }
        public string mail_address { get; set; }
        public string password { get; set; }
        public string cre_date { get; set; }
        public int delete_flg { get; set; }
        public Byte[] version { get; set; }
    }
}
