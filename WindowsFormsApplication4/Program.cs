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
    }
}
