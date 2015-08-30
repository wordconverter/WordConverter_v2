using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordConvertTool;
using WordConvTool.Const;

namespace WordConverter_v2.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class CommonFunction
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        public void executeQuery(string sql)
        {
            using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings.Get("DataSource")))
            {
                conn.Open();
                using (var sqlt = conn.BeginTransaction())
                {
                    using (NpgsqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = sql;
                        command.ExecuteNonQuery();
                    }
                    sqlt.Commit();
                }
                conn.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView"></param>
        public void addCheckBox(ref DataGridView dataGridView, int index)
        {
            Boolean isExistChecBox = false;
            int id = 0;
            foreach (Object obj in dataGridView.Columns)
            {
                if (obj is DataGridViewCheckBoxColumn && id == index)
                {
                    isExistChecBox = true;
                }
                id++;
            }
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            if (!isExistChecBox)
            {
                dataGridView.Columns.Insert(index, chk);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="checkBoxObjWidth"></param>
        /// <param name="textBoxObjWidth"></param>
        internal void checkBoxWidthSetting(ref DataGridView dataGridView, int checkBoxObjWidth, int textBoxObjWidth)
        {
            int j = 0;
            foreach (Object obj in dataGridView.Columns)
            {
                if (j == 0)
                {
                    DataGridViewCheckBoxColumn checkBoxObj = (DataGridViewCheckBoxColumn)obj;
                    checkBoxObj.Width = checkBoxObjWidth;
                }
                if (obj is DataGridViewTextBoxColumn)
                {
                    DataGridViewTextBoxColumn textBoxObj = (DataGridViewTextBoxColumn)obj;
                    textBoxObj.Width = textBoxObjWidth;
                }
                j++;
            }
        }

        internal System.Drawing.Color switchRowBackColor(DataGridViewRow dataGridViewRow)
        {
            return dataGridViewRow.DefaultCellStyle.BackColor == Constant.CHECK_BOX_ON_COLOR ? Constant.CHECK_BOX_OFF_COLOR : Constant.CHECK_BOX_ON_COLOR;

        }

        public string getDbConnectionString()
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string appConfigPath;
            appConfigPath = System.IO.Path.GetDirectoryName(asm.Location) + @"\" + asm.GetName().Name + ".exe.config";
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(appConfigPath);
            System.Xml.XmlNode node = doc["configuration"]["connectionStrings"];
            foreach (System.Xml.XmlNode n in doc["configuration"]["connectionStrings"])
            {
                if (n.Name == "add")
                {
                    if (n.Attributes.GetNamedItem("name").Value == "MyContext")
                    {
                        return n.Attributes.GetNamedItem("connectionString").Value;
                    }
                }
            }
            return "";
        }

        public string getDbProviderName()
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string appConfigPath;
            appConfigPath = System.IO.Path.GetDirectoryName(asm.Location) + @"\" + asm.GetName().Name + ".exe.config";
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(appConfigPath);
            System.Xml.XmlNode node = doc["configuration"]["connectionStrings"];
            foreach (System.Xml.XmlNode n in doc["configuration"]["connectionStrings"])
            {
                if (n.Name == "add")
                {
                    if (n.Attributes.GetNamedItem("name").Value == "MyContext")
                    {
                        return n.Attributes.GetNamedItem("providerName").Value;
                    }
                }
            }
            return "";
        }

        public string getSqliteDbPath()
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string appConfigPath;
            appConfigPath = System.IO.Path.GetDirectoryName(asm.Location) + @"\" + asm.GetName().Name + ".exe.config";
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(appConfigPath);
            System.Xml.XmlNode node = doc["configuration"]["connectionStrings"];
            string dbPath = "";
            foreach (System.Xml.XmlNode n in doc["configuration"]["connectionStrings"])
            {
                if (n.Name == "add")
                {
                    if (n.Attributes.GetNamedItem("name").Value == "MyContext")
                    {
                        dbPath = n.Attributes.GetNamedItem("connectionString").Value;
                        break;
                    }
                }
            }
            dbPath = dbPath.Replace("Data Source=", "");
            dbPath = dbPath.Replace(";foreign keys=true;", "");
            return dbPath;
        }

        public void setSqliteDbContextPath(string path)
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string appConfigPath;
            appConfigPath = System.IO.Path.GetDirectoryName(asm.Location) + @"\WordConverter_v2.exe.config";
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(appConfigPath);
            System.Xml.XmlNode node = doc["configuration"]["connectionStrings"];
            foreach (System.Xml.XmlNode n in doc["configuration"]["connectionStrings"])
            {
                if (n.Name == "add")
                {
                    if (n.Attributes.GetNamedItem("name").Value == "MyContext")
                    {
                        n.Attributes.GetNamedItem("connectionString").Value = path;
                        n.Attributes.GetNamedItem("providerName").Value = "System.Data.SQLite.EF6";
                        break;
                    }
                }
            }
            doc.Save(appConfigPath);
        }


        public void setPostgresDbContext(string path)
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string appConfigPath;
            appConfigPath = System.IO.Path.GetDirectoryName(asm.Location) + @"\WordConverter_v2.exe.config";
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(appConfigPath);
            System.Xml.XmlNode node = doc["configuration"]["connectionStrings"];
            foreach (System.Xml.XmlNode n in doc["configuration"]["connectionStrings"])
            {
                if (n.Name == "add")
                {
                    if (n.Attributes.GetNamedItem("name").Value == "MyContext")
                    {
                        n.Attributes.GetNamedItem("connectionString").Value = path;
                        n.Attributes.GetNamedItem("providerName").Value = "Npgsql";
                        break;
                    }
                }
            }
            doc.Save(appConfigPath);
        }


        public string nullAble(string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return "";
            }
            return str;
        }

        public string nullAble(object p)
        {
            if (p == null)
            {
                return "";
            }
            if (String.IsNullOrEmpty(p.ToString()))
            {
                return "";
            }
            return p.ToString();
        }


        public int nullAbleInt(object p)
        {
            if (p == null)
            {
                return 0;
            }
            if (p.ToString().ToIntType() < 0)
            {
                return 0;
            }
            return p.ToString().ToIntType();
        }

        internal void tabDrawItem(ref object sender, ref DrawItemEventArgs e)
        {
            //対象のTabControlを取得
            TabControl tab = (TabControl)sender;
            //タブページのテキストを取得
            string txt = tab.TabPages[e.Index].Text;

            //タブのテキストと背景を描画するためのブラシを決定する
            Brush foreBrush, backBrush;
            SolidBrush b = new SolidBrush(Color.FromArgb(215, 228, 242));

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                //選択されているタブのテキストを赤、背景を青とする
                foreBrush = Brushes.Black;
                backBrush = b;
            }
            else
            {
                //選択されていないタブのテキストは灰色、背景を白とする
                foreBrush = Brushes.Black;
                backBrush = Brushes.AliceBlue;
            }

            //StringFormatを作成
            StringFormat sf = new StringFormat();
            //中央に表示する
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            //背景の描画
            e.Graphics.FillRectangle(backBrush, e.Bounds);
            //Textの描画
            e.Graphics.DrawString(txt, e.Font, foreBrush, e.Bounds, sf);

            b.Dispose();
        }

        internal void resetDbContextPath(string dbConnectionString, string dbProviderName)
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string appConfigPath;
            appConfigPath = System.IO.Path.GetDirectoryName(asm.Location) + @"\WordConverter_v2.exe.config";
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(appConfigPath);
            System.Xml.XmlNode node = doc["configuration"]["connectionStrings"];
            foreach (System.Xml.XmlNode n in doc["configuration"]["connectionStrings"])
            {
                if (n.Name == "add")
                {
                    if (n.Attributes.GetNamedItem("name").Value == "MyContext")
                    {
                        n.Attributes.GetNamedItem("connectionString").Value = dbConnectionString;
                        n.Attributes.GetNamedItem("providerName").Value = dbProviderName;
                        break;
                    }
                }
            }
            doc.Save(appConfigPath);
        }
    }
}
