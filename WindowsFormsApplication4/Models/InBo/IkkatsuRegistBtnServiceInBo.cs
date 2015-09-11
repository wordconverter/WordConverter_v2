using System.Windows.Forms;
using WordConverter_v2.Interface;

namespace WordConverter_v2.Models.InBo
{
    public class IkkatsuTorokuIkkatsuRegistServiceInBo : IBo
    {
        public DataGridView ikkatsuDataGridView { get; set; }
        public string clipBoardText { get; set; }
    }
}
