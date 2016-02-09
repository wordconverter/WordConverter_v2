using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordConverter_v2.Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string ToTitleCase(this string self)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(self);
        }

        public static string NullAble(this string self)
        {
            if (String.IsNullOrEmpty(self))
            {
                return "";
            }
            return self;
        }

        public static string AddCondtion(this string self, int i)
        {
            if (String.IsNullOrEmpty(self))
            {
                return "";
            }
            return self.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string ToPascalCase(this string self)
        {
            if (String.IsNullOrEmpty(self))
            {
                return "";
            }

            String butsuriName = "";
            String inParams = Convert.ToString(self);
            string UNDER_SCORE = "_";
            String[] names = inParams.Split(new string[] { UNDER_SCORE }, StringSplitOptions.None);
            if (names.Count() > 1)
            {
                foreach (String s in names)
                {
                    String str = "";
                    str = s.ToLower();
                    str = str.ToTitleCase();
                    butsuriName += str;
                }
                return butsuriName;

            }

            string inStr = names[0];
            butsuriName = Char.ToUpper(inStr[0]) + inStr.Substring(1);

            return butsuriName;
        }

        public static string ToCamelCase(this string self)
        {
            if (String.IsNullOrEmpty(self))
            {
                return "";
            }

            String butsuriName = "";
            String inParams = Convert.ToString(self);
            string UNDER_SCORE = "_";
            String[] names = inParams.Split(new string[] { UNDER_SCORE }, StringSplitOptions.None);
            if (names.Count() > 1)
            {
                foreach (String s in names)
                {
                    String str = "";
                    str = s.ToLower();
                    str = str.ToTitleCase();
                    butsuriName += str;
                }
                butsuriName = Char.ToLower(butsuriName[0]) + butsuriName.Substring(1);
                return butsuriName;
            }
            return self;
        }

        public static string ToSnakeCase(this string self)
        {
            if (String.IsNullOrEmpty(self))
            {
                return "";
            }

            char[] cs = self.ToCharArray();
            string str = "";
            for (int i = 0; i < cs.Length; i++)
            {
                if (char.IsUpper(cs[i]))
                {
                    str += "_" + cs[i];
                }
                else if (char.IsLower(cs[i]))
                {
                    str += char.ToUpper(cs[i]);
                }
            }
            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string CommaSeparatedValue(this String[] self)
        {
            string condition = "";
            foreach (object obj in self)
            {
                string val = (string)obj;
                val = val.Trim();
                if (!String.IsNullOrEmpty(val))
                {
                    condition += "\'" + val + "\'" + ",";
                }
            }
            char[] trimChars = { ',' };
            condition = condition.Remove(condition.Length - 1);
            return condition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static long ToKeyType(this String self)
        {
            long condition = 0L;
            if (!String.IsNullOrEmpty(self))
            {
                try
                {
                    return (long)Convert.ToInt16(self);
                }
                catch
                {
                    return 0L;
                }
            }
            return condition;
        }

        public static int ToIntType(this String self)
        {
            int condition = 0;
            if (!String.IsNullOrEmpty(self))
            {
                try
                {
                    return int.Parse(self);
                }
                catch
                {
                    return 0;
                }
            }
            return condition;
        }

        public static bool IsAlphanumeric(this string self)
        {
            return new Regex("^[0-9a-zA-Z]+$").IsMatch(self);
        }

    }
}
