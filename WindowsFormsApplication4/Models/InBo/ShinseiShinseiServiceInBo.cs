using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConverter_v2.Interface;

namespace WordConverter_v2.Models.InBo
{
    class ShinseiShinseiServiceInBo : IBo
    {
        public string clipboardText { get; set; }
        public string ronrimei1TextBox { get; set; }
        public string ronrimei2TextBox { get; set; }
        public string butsurimeiTextBox { get; set; }
    }
}
