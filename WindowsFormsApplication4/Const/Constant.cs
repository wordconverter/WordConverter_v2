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
        一般 = 1
    }

    public enum SankaKahi
    {
        参加 = 0,
        不参加 = 1
    }

}
