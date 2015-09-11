using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConverter_v2.Interface;

namespace WordConverter_v2.Models.InBo
{
    public class UserKanriRegistServiceInBo : IBo
    {
        public string empId { get; set; }
        public string userName { get; set; }
        public int kengenSelectedIndex { get; set; }
        public System.Windows.Forms.DataGridView userKanriDataGridView1 { get; set; }
    }
}
