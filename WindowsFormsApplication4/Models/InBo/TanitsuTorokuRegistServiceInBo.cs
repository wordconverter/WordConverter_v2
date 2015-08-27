using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WordConvTool.Service;

namespace WordConverter_v2.Models.InBo
{
    public class TanitsuTorokuRegistServiceInBo : IBo
    {
        public DataGridView tanitsuDataGridView { get; set; }
        public string clipboardText { get; set; }
    }
}
