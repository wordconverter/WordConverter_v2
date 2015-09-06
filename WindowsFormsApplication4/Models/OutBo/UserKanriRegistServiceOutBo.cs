using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConvTool.Service;

namespace WordConverter_v2.Models.OutBo
{
    public class UserKanriRegistServiceOutBo : IBo
    {
        public string errorMessage { get; set; }
        public int empId { get; set; }
    }
}
