using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            Program.ExecuteDDL();
            BaseForm baseForm = new BaseForm();
            Application.Run();
        }


        static void ExecuteDDL()
        {
            var path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "WordConverter_v2.db");

            if (File.Exists(path))
            {
                return;
            }

            System.Data.SQLite.SQLiteConnection.CreateFile(path);
            var cnStr = new System.Data.SQLite.SQLiteConnectionStringBuilder() { DataSource = path };

            //CommonFunction common = new CommonFunction();
            //common.setDbPath(path);

            using (var cn = new System.Data.SQLite.SQLiteConnection(cnStr.ToString()))
            {
                cn.Open();

                //  テーブル名は複数形で指定する(Wordではなく、Words)
                var sql = "CREATE TABLE WORD_DIC( ";
                sql += "  word_id INTEGER PRIMARY KEY AUTOINCREMENT";
                sql += "  , ronri_name1 TEXT";
                sql += "  , ronri_name2 TEXT";
                sql += "  , butsuri_name TEXT";
                sql += "  , user_id INTEGER";
                sql += "  , version INTEGER";
                sql += "  , cre_date TEXT";
                sql += "  , FOREIGN KEY (user_id) REFERENCES USER_MST(user_id)";
                sql += "); ";
                sql += "CREATE TABLE WORD_SHINSEI( ";
                sql += "  shinsei_id INTEGER PRIMARY KEY AUTOINCREMENT";
                sql += "  , ronri_name1 TEXT";
                sql += "  , ronri_name2 TEXT";
                sql += "  , butsuri_name TEXT";
                sql += "  , word_id INTEGER";
                sql += "  , status INTEGER";
                sql += "  , user_id INTEGER";
                sql += "  , version INTEGER";
                sql += "  , cre_date TEXT";
                sql += "  , FOREIGN KEY (user_id) REFERENCES USER_MST(user_id)";
                sql += "); ";
                sql += "CREATE TABLE USER_MST( ";
                sql += "  user_id INTEGER PRIMARY KEY AUTOINCREMENT";
                sql += "  , emp_id INTEGER UNIQUE ";
                sql += "  , user_name TEXT";
                sql += "  , kengen INTEGER";
                sql += "  , mail_id TEXT";
                sql += "  , password TEXT";
                sql += "  , mail_address TEXT";
                sql += "  , sanka_kahi INTEGER";
                sql += "  , delete_flg INTEGER";
                sql += "  , version INTEGER";
                sql += "  , cre_date TEXT";
                sql += "); ";
                sql += "insert into USER_MST(user_id,emp_id,user_name,kengen,mail_id,password,mail_address,sanka_kahi,delete_flg,version) values (1,999, 'Admin',0,'999','admin@co.jp','admin@co.jp',0,0,0);";

                var cmd = new System.Data.SQLite.SQLiteCommand(sql, cn);
                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }
    }
}
