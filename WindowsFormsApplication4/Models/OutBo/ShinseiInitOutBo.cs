﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConverter_v2.Interface;

namespace WordConverter_v2.Models.OutBo
{
    public class ShinseiInitServiceOutBo : IBo
    {
        public List<ShinseiBo> dispShinseiList { get; set; }
    }
}
