using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConvTool.Service;

namespace WordConverter_v2.Models.InBo
{
    class TanitsuTorokuSearchServiceInBo : IBo
    {
        public string ronrimei1TextBox { get; set; }
        public string ronrimei2TextBox { get; set; }
        public string butsurimeiTextBox { get; set; }
    }
}
