using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConvTool.Service;

namespace WordConverter_v2.Models.InBo
{
    /// <summary>
    /// 単一登録検索サービスInBo
    /// </summary>
    class TanitsuTorokuSearchServiceInBo : IBo
    {
        public string ronrimei1TextBox { get; set; }
        public string butsurimeiTextBox { get; set; }
        public string dataType { get; set; }
    }
}
