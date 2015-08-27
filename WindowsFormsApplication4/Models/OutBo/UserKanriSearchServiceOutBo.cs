using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConvTool.Service;

namespace WordConverter_v2.Models.OutBo
{
    class UserKanriSearchServiceOutBo : IBo
    {
        public List<UserBo> usersList { get; set; }
    }
}
