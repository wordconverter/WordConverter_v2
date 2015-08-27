using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConvTool.Service;

namespace WordConverter_v2.Models.OutBo
{
    public class TanitsuTorokuAddServiceOutBo : IBo
    {
        public List<HenshuWordBo> wordList { get; set; }
        public string errorMessage { get; set; }
    }
}
