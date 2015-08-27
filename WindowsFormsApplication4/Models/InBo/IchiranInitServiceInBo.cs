using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConvTool.Service;

namespace WordConverter_v2.Models.InBo
{
    public class IchiranInitServiceInBo : IBo
    {
        public String clipboardText { get; set; }
        public int dispNumber { get; set; }
    }
}
