using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordConverter_v2.Forms;
using WordConverter_v2.Models.Dao;
using WordConverter_v2.Models.Entity;
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

        public string getPostgresDbConnectionString()
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

        public string getSqliteDbConnectionString()
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
                    if (n.Attributes.GetNamedItem("name").Value == "MyContextSqlite")
                    {
                        return n.Attributes.GetNamedItem("connectionString").Value;
                    }
                }
            }
            return "";
        }

        public string makeSqliteDbPath()
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
                    if (n.Attributes.GetNamedItem("name").Value == "MyContextSqlite")
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
                    if (n.Attributes.GetNamedItem("name").Value == "MyContextSqlite")
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
                    if (n.Attributes.GetNamedItem("name").Value == "MyContextPostgres")
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


        public bool isExistPostgresDb(string dbConnectionString)
        {
            try
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(dbConnectionString))
                {
                    cn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool isExistPostgresDbTable(string dbConnectionString)
        {
            try
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(dbConnectionString))
                {
                    cn.Open();
                    DbCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM WORD_DIC";
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
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

        public void ExecuteSqliteDDL()
        {
            var path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "WordConverter_v2.db");
            WordConverter_v2.Settings1.Default.SqliteContextString = path;
            WordConverter_v2.Settings1.Default.Save();
            System.Data.SQLite.SQLiteConnection.CreateFile(path);
            var cnStr = new System.Data.SQLite.SQLiteConnectionStringBuilder() { DataSource = path };

            using (var cn = new System.Data.SQLite.SQLiteConnection(cnStr.ToString()))
            {
                cn.Open();

                //  テーブル名は複数形で指定する(Wordではなく、Words)
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("CREATE TABLE user_mst( ");
                sb.AppendLine("  user_id INTEGER PRIMARY KEY AUTOINCREMENT");
                sb.AppendLine("  , emp_id INTEGER UNIQUE");
                sb.AppendLine("  , user_name TEXT");
                sb.AppendLine("  , kengen INTEGER");
                sb.AppendLine("  , mail_id TEXT");
                sb.AppendLine("  , password TEXT");
                sb.AppendLine("  , mail_address TEXT");
                sb.AppendLine("  , sanka_kahi INTEGER");
                sb.AppendLine("  , delete_flg INTEGER");
                sb.AppendLine("  , version INTEGER");
                sb.AppendLine("  , cre_date TEXT");
                sb.AppendLine("); ");
                sb.AppendLine("CREATE TABLE word_dic( ");
                sb.AppendLine("  word_id INTEGER PRIMARY KEY AUTOINCREMENT");
                sb.AppendLine("  , ronri_name1 TEXT");
                sb.AppendLine("  , ronri_name2 TEXT");
                sb.AppendLine("  , butsuri_name TEXT");
                sb.AppendLine("  , data_type text");
                sb.AppendLine("  , user_id INTEGER");
                sb.AppendLine("  , version INTEGER");
                sb.AppendLine("  , cre_date TEXT");
                sb.AppendLine("  , FOREIGN KEY (user_id) REFERENCES USER_MST(user_id)");
                sb.AppendLine("); ");
                sb.AppendLine("CREATE TABLE word_shinsei( ");
                sb.AppendLine("  shinsei_id INTEGER PRIMARY KEY AUTOINCREMENT");
                sb.AppendLine("  , ronri_name1 TEXT");
                sb.AppendLine("  , ronri_name2 TEXT");
                sb.AppendLine("  , butsuri_name TEXT");
                sb.AppendLine("  , word_id INTEGER");
                sb.AppendLine("  , status INTEGER");
                sb.AppendLine("  , user_id INTEGER");
                sb.AppendLine("  , version INTEGER");
                sb.AppendLine("  , cre_date TEXT");
                sb.AppendLine("  , FOREIGN KEY (user_id) REFERENCES USER_MST(user_id)");
                sb.AppendLine("); ");
                sb.AppendLine("CREATE TABLE or_map( ");
                sb.AppendLine("  or_id INTEGER PRIMARY KEY AUTOINCREMENT");
                sb.AppendLine("  , data_type TEXT UNIQUE");
                sb.AppendLine("  , db_data_type TEXT");
                sb.AppendLine("  , project_name TEXT");
                sb.AppendLine("  , yuko_flg INTEGER");
                sb.AppendLine("  , delete_flg INTEGER");
                sb.AppendLine("  , version INTEGER");
                sb.AppendLine("  , cre_date TEXT");
                sb.AppendLine("); ");
                sb.AppendLine("INSERT ");
                sb.AppendLine("INTO user_mst( ");
                sb.AppendLine("  user_id");
                sb.AppendLine("  , emp_id");
                sb.AppendLine("  , user_name");
                sb.AppendLine("  , kengen");
                sb.AppendLine("  , mail_id");
                sb.AppendLine("  , password");
                sb.AppendLine("  , mail_address");
                sb.AppendLine("  , sanka_kahi");
                sb.AppendLine("  , delete_flg");
                sb.AppendLine("  , version");
                sb.AppendLine("  , cre_date");
                sb.AppendLine(") ");
                sb.AppendLine("VALUES ( ");
                sb.AppendLine("  1");
                sb.AppendLine("  , 999");
                sb.AppendLine("  , 'Admin'");
                sb.AppendLine("  , 0");
                sb.AppendLine("  , 'admin'");
                sb.AppendLine("  , 'admin@co.jp'");
                sb.AppendLine("  , 'admin@co.jp'");
                sb.AppendLine("  , 0");
                sb.AppendLine("  , 0");
                sb.AppendLine("  , 0");
                sb.AppendLine("  , NULL");
                sb.AppendLine("); ");
                sb.AppendLine("insert into or_map(or_id,data_type,db_data_type,project_name,yuko_flg,delete_flg,version,cre_date) values (1,'String','VARCHAR',null,0,0,0,null);");
                sb.AppendLine("insert into or_map(or_id,data_type,db_data_type,project_name,yuko_flg,delete_flg,version,cre_date) values (2,'Integer','INTEGER',null,0,0,0,null);");
                sb.AppendLine("insert into or_map(or_id,data_type,db_data_type,project_name,yuko_flg,delete_flg,version,cre_date) values (3,'Date','DATE',null,0,0,0,null);");
                sb.AppendLine("insert into or_map(or_id,data_type,db_data_type,project_name,yuko_flg,delete_flg,version,cre_date) values (4,'Timestamp','TIMESTAMP',null,0,0,0,null);");
                string sqliteDdlText = sb.ToString();
                var cmd = new System.Data.SQLite.SQLiteCommand(sqliteDdlText, cn);
                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }

        public void ExecutePostgresDDL(string dbConnectionString)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CREATE TABLE USER_MST( ");
            sb.AppendLine("  user_id SERIAL PRIMARY KEY");
            sb.AppendLine("  , emp_id INTEGER UNIQUE");
            sb.AppendLine("  , user_name TEXT");
            sb.AppendLine("  , kengen INTEGER");
            sb.AppendLine("  , mail_id TEXT");
            sb.AppendLine("  , password TEXT");
            sb.AppendLine("  , mail_address TEXT");
            sb.AppendLine("  , sanka_kahi INTEGER");
            sb.AppendLine("  , delete_flg INTEGER");
            sb.AppendLine("  , version timestamp");
            sb.AppendLine("  , cre_date TEXT");
            sb.AppendLine("); ");
            sb.AppendLine("");
            sb.AppendLine("CREATE TABLE WORD_DIC( ");
            sb.AppendLine("  word_id SERIAL PRIMARY KEY");
            sb.AppendLine("  , ronri_name1 TEXT");
            sb.AppendLine("  , ronri_name2 TEXT");
            sb.AppendLine("  , butsuri_name TEXT");
            sb.AppendLine("  , data_type text");
            sb.AppendLine("  , user_id INTEGER");
            sb.AppendLine("  , version timestamp");
            sb.AppendLine("  , cre_date TEXT");
            sb.AppendLine("  , FOREIGN KEY (user_id) REFERENCES USER_MST(user_id)");
            sb.AppendLine("); ");
            sb.AppendLine("");
            sb.AppendLine("CREATE TABLE WORD_SHINSEI( ");
            sb.AppendLine("  shinsei_id SERIAL PRIMARY KEY");
            sb.AppendLine("  , ronri_name1 TEXT");
            sb.AppendLine("  , ronri_name2 TEXT");
            sb.AppendLine("  , butsuri_name TEXT");
            sb.AppendLine("  , word_id INTEGER");
            sb.AppendLine("  , status INTEGER");
            sb.AppendLine("  , user_id INTEGER");
            sb.AppendLine("  , version timestamp");
            sb.AppendLine("  , cre_date TEXT");
            sb.AppendLine("  , FOREIGN KEY (user_id) REFERENCES USER_MST(user_id)");
            sb.AppendLine("); ");
            sb.AppendLine("CREATE TABLE or_map( ");
            sb.AppendLine("  or_id SERIAL PRIMARY KEY");
            sb.AppendLine("  , data_type text");
            sb.AppendLine("  , db_data_type text");
            sb.AppendLine("  , project_name text");
            sb.AppendLine("  , yuko_flg INTEGER");
            sb.AppendLine("  , delete_flg INTEGER");
            sb.AppendLine("  , version timestamp");
            sb.AppendLine("  , cre_date text");
            sb.AppendLine(");");
            sb.AppendLine("insert ");
            sb.AppendLine("into USER_MST( ");
            sb.AppendLine("  user_id");
            sb.AppendLine("  , emp_id");
            sb.AppendLine("  , user_name");
            sb.AppendLine("  , kengen");
            sb.AppendLine("  , mail_id");
            sb.AppendLine("  , password");
            sb.AppendLine("  , mail_address");
            sb.AppendLine("  , sanka_kahi");
            sb.AppendLine("  , delete_flg");
            sb.AppendLine("  , version");
            sb.AppendLine(") ");
            sb.AppendLine("values ( ");
            sb.AppendLine("  1");
            sb.AppendLine("  , 999");
            sb.AppendLine("  , 'Admin'");
            sb.AppendLine("  , 0");
            sb.AppendLine("  , '999'");
            sb.AppendLine("  , 'admin@co.jp'");
            sb.AppendLine("  , 'admin@co.jp'");
            sb.AppendLine("  , 0");
            sb.AppendLine("  , 0");
            sb.AppendLine("  , transaction_timestamp()");
            sb.AppendLine("); ");
            sb.AppendLine("insert into or_map(or_id,data_type,db_data_type,project_name,yuko_flg,delete_flg,version,cre_date) values (1,'String','VARCHAR',null,0,0,0,null);");
            sb.AppendLine("insert into or_map(or_id,data_type,db_data_type,project_name,yuko_flg,delete_flg,version,cre_date) values (2,'Integer','INTEGER',null,0,0,0,null);");
            sb.AppendLine("insert into or_map(or_id,data_type,db_data_type,project_name,yuko_flg,delete_flg,version,cre_date) values (3,'Date','DATE',null,0,0,0,null);");
            sb.AppendLine("insert into or_map(or_id,data_type,db_data_type,project_name,yuko_flg,delete_flg,version,cre_date) values (4,'Timestamp','TIMESTAMP',null,0,0,0,null);");
            string postgresDdlText = sb.ToString();

            using (NpgsqlConnection cn = new NpgsqlConnection(dbConnectionString))
            {
                cn.Open();
                NpgsqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = postgresDdlText;
                cmd.ExecuteNonQuery();
            }
        }

        internal bool isExistSqliteDb(string path)
        {
            try
            {
                using (SQLiteConnection cn = new SQLiteConnection(path))
                {
                    cn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        internal bool isExistSqliteDbTable(string path)
        {
            try
            {
                using (SQLiteConnection cn = new SQLiteConnection(path))
                {
                    cn.Open();
                    SQLiteCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM WORD_DIC";
                    cmd.ExecuteReader();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                return false;
            }
        }
    }
}
