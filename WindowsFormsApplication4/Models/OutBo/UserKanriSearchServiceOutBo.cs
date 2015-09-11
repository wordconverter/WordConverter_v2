using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConverter_v2.Interface;

namespace WordConverter_v2.Models.OutBo
{
    class UserKanriSearchServiceOutBo : IBo
    {
        public List<UserBo> usersList { get; set; }
    }
}
