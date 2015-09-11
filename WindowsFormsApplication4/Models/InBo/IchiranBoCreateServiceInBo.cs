using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConverter_v2.Interface;

namespace WordConverter_v2.Models.InBo
{
    public class IchiranBoCreateServiceInBo : IBo
    {
        public System.Windows.Forms.DataGridView ichiranDataGridView { get; set; }
        public bool annotationFlg { get; set; }
        public bool reverseCreateFlg { get; set; }
        public WordConvTool.Const.PropertyShoriMode shoriMode { get; set; }
    }
}
