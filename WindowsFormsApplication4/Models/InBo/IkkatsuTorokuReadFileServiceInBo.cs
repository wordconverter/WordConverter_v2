using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConverter_v2.Interface;

namespace WordConverter_v2.Models.InBo
{
    class IkkatsuTorokuReadFileServiceInBo : IBo
    {
        public string Filename { get; set; }
        public bool registeredPairsIkkatsu { get; set; }
    }
}
