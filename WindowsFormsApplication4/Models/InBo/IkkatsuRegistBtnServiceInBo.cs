using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WordConvTool.Service;

namespace WordConverter_v2.Models.InBo
{
    public class IkkatsuTorokuIkkatsuRegistServiceInBo : IBo
    {
        public DataGridView ikkatsuDataGridView { get; set; }
        public string clipBoardText { get; set; }
    }
}
