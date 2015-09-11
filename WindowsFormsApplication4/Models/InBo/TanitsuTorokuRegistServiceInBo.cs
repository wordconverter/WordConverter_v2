using System.Windows.Forms;
using WordConverter_v2.Interface;

namespace WordConverter_v2.Models.InBo
{
    public class TanitsuTorokuRegistServiceInBo : IBo
    {
        public DataGridView tanitsuDataGridView { get; set; }
        public string clipboardText { get; set; }
    }
}
