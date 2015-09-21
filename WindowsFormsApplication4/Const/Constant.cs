using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordConvTool.Const
{
    public static class Constant
    {
        public static string NONE_WORD = "変換候補がありません。";
        public static int TANITSU_TOROKU = 0;
        public static int IKKATSU_TOROKU = 1;
        public static int KANRI = 0;
        public static int IPPAN = 1;
        public static string SQLITE_CONNECT = "MyContextSqlite";
        public static string POSTGRES_CONNECT = "MyContext";
        public static System.Drawing.Color CHECK_BOX_ON_COLOR = Color.WhiteSmoke;
        public static System.Drawing.Color CHECK_BOX_OFF_COLOR = Color.White;
    }

    public enum ShinseiKbn
    {
        申請中 = 0,
        承認 = 1,
        却下 = 2
    }

    public enum KengenKbn
    {
        管理 = 0,
        一般 = 1,
        メーリングリスト = 2
    }

    public enum SankaKahi
    {
        参加 = 0,
        不参加 = 1
    }

    public enum StartUpMode
    {
        複数人 = 0,
        個人 = 1
    }

    public enum PropertyShoriMode
    {
        プロパティ作成 = 0,
        プロパティ作成アノテーションあり = 1,
        物理名からプロパティ作成 = 2,
        物理名からプロパティ作成アノテーションあり = 3
    }

}
