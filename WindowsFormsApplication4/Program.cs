using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordConverter_v2.Common;
using WordConverter_v2.Forms;
using WordConvertTool;

namespace WordConverter_v2
{
    static class Program
    {
        private static System.Threading.Mutex _mutex;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Mutexクラスの作成
            _mutex = new System.Threading.Mutex(false, "WordConverter");
            //ミューテックスの所有権を要求する
            if (_mutex.WaitOne(0, false) == false)
            {
                //すでに起動していると判断して終了
                MessageBox.Show("WordConverter_v2の多重起動はできません。");
                return;
            }

            //ThreadExceptionイベントハンドラを追加
            //Application.ThreadException +=
            //    new System.Threading.ThreadExceptionEventHandler(
            //        Application_ThreadException);


            //Program.ExecutePostgresDDL();
            Program.ExecuteSqliteDDL();
            Program.eraseCredentialsBeforeCommit();
            BaseForm baseForm = new BaseForm();
            Application.Run();
        }

        private static void eraseCredentialsBeforeCommit()
        {
            if (!"Response status code does not Indicate success: 403 Forbidden".Equals(""))
            {
                System.Diagnostics.Debug.WriteLine("rundll32.exe keymgr.dll,KRShowKeyMgr");
            }
        }



        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            try
            {
                //エラーメッセージを表示する
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(e.Exception.Message);
                sb.AppendLine(e.Exception.StackTrace);
                MessageBox.Show(sb.ToString(), "エラー");
            }
            finally
            {
                //アプリケーションを終了する
                Application.Exit();
            }
        }


        static void ExecuteSqliteDDL()
        {
            var path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "WordConverter_v2.db");
            if (File.Exists(path))
            {
                return;
            }

            WordConverter_v2.Settings1.Default.SqliteContextString = path;
            WordConverter_v2.Settings1.Default.Save();
            System.Data.SQLite.SQLiteConnection.CreateFile(path);
            var cnStr = new System.Data.SQLite.SQLiteConnectionStringBuilder() { DataSource = path };

            using (var cn = new System.Data.SQLite.SQLiteConnection(cnStr.ToString()))
            {
                cn.Open();

                //  テーブル名は複数形で指定する(Wordではなく、Words)
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("CREATE TABLE USER_MST( ");
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
                sb.AppendLine("CREATE TABLE WORD_DIC( ");
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
                sb.AppendLine("CREATE TABLE WORD_SHINSEI( ");
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
                sb.AppendLine("CREATE TABLE OR_MAP( ");
                sb.AppendLine("  or_id INTEGER PRIMARY KEY AUTOINCREMENT");
                sb.AppendLine("  , data_type INTEGER UNIQUE");
                sb.AppendLine("  , db_data_type TEXT");
                sb.AppendLine("  , project_name TEXT");
                sb.AppendLine("  , yuko_flg INTEGER");
                sb.AppendLine("  , delete_flg INTEGER");
                sb.AppendLine("  , version INTEGER");
                sb.AppendLine("  , cre_date TEXT");
                sb.AppendLine("); ");
                sb.AppendLine("INSERT ");
                sb.AppendLine("INTO USER_MST( ");
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
                string sqliteDdlText = sb.ToString();
                var cmd = new System.Data.SQLite.SQLiteCommand(sqliteDdlText, cn);
                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }
    }
}
