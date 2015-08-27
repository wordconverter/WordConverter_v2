using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordConverter_v2.Common;

namespace WordConverter_v2.Forms
{
    public partial class DbConnect : Form
    {
        private static CommonFunction common = new CommonFunction();
        private static readonly DbConnect _instance = new DbConnect();

        public static DbConnect Instance
        {
            get
            {
                return _instance;
            }
        }

        private DbConnect()
        {
            InitializeComponent();
            this.Show();
            this.Activate();
        }

        private void sqliteTestConnectBtn_Click(object sender, EventArgs e)
        {

        }

        private void sqliteSaveBtn_Click(object sender, EventArgs e)
        {

        }

        private void sqliteOpenFileBtn_Click(object sender, EventArgs e)
        {

        }

        private void testConnectBtn_Click(object sender, EventArgs e)
        {

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            common.tabDrawItem(ref sender, ref e);
        }
    }
}
