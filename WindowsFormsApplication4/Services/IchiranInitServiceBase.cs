using Npgsql;
using SQLite.Services;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using WordConverter_v2.Common;
using WordConverter_v2.Forms;
using WordConverter_v2.Models;
using WordConverter_v2.Models.InBo;
using WordConverter_v2.Models.OutBo;
using WordConvertTool;
using WordConvTool.Const;

namespace WordConverter_v2.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class IchiranInitServiceBase
    {
        /// <summary>
        /// 
        /// </summary>
        protected IchiranInitServiceInBo inBo = new IchiranInitServiceInBo();
        private static CommonFunction common = new CommonFunction();

        protected void makeIchiranDispList(ref IchiranInitServiceOutBo outBo, IchiranInitServiceInBo ichiranInitServiceInBo, List<IchiranWordBo> wordList, IchiranWordBo word)
        {
            if (wordList.Count == 0 || String.IsNullOrEmpty(ichiranInitServiceInBo.clipboardText))
            {
                word.ronri_name1 = "-";
                word.butsuri_name = Constant.NONE_WORD;
                wordList.Add(word);
            }
            outBo.wordList = this.toIchiranDispList(wordList, this.inBo.dispNumber);
        }

        protected void makeMultipleWordList(DbDataReader reader, ref List<IchiranWordBo> wordList, ref IchiranWordBo word)
        {
            word = new IchiranWordBo();
            word.ronri_name1 = reader["ronri_name1"].ToString();
            word.butsuri_name = reader["butsuri_name"].ToString();
            wordList.Add(word);
        }

        protected DbCommand setQueryCommandMultiple(DbConnection cn, string[] keys)
        {
            cn.Open();
            DbCommand cmd = cn.CreateCommand();
            string condition = keys.CommaSeparatedValue();
            cmd.CommandText = "SELECT * FROM WORD_DIC where ronri_name1 in (" + condition + ")";
            return cmd;
        }

        protected DbCommand setQueryCommandSingle(DbConnection cn, string[] keys)
        {
            cn.Open();
            DbCommand cmd = cn.CreateCommand();
            string[] sp = { " ", "　" };
            String[] keyStrs = keys[0].Split(sp, StringSplitOptions.None);
            String condition = keyStrs.CommaSeparatedValue();
            condition = condition.Replace("\'", "");
            condition = "\'" + condition.Replace(",", "%") + "%\'";
            cmd.CommandText = "SELECT * FROM WORD_DIC where ronri_name1 like (" + condition + ")";
            return cmd;
        }

        protected bool makeSingleWordList(DbDataReader reader, ref List<IchiranWordBo> wordList, ref IchiranWordBo word)
        {
            if (!isContains(reader["butsuri_name"].ToString(), wordList))
            {
                if (!reader["butsuri_name"].ToString().IsAlphanumeric())
                {
                    word = new IchiranWordBo();
                    word.ronri_name1 = reader["ronri_name1"].ToString();
                    word.butsuri_name = reader["butsuri_name"].ToString();
                    wordList.Add(word);
                    return false;
                }
                bool isDoneRonriNameDisp = false;
                if (BaseForm.UserInfo.pascal)
                {
                    word = new IchiranWordBo();
                    word.ronri_name1 = reader["ronri_name1"].ToString();
                    word.butsuri_name = reader["butsuri_name"].ToString().ToPascalCase();
                    wordList.Add(word);
                    isDoneRonriNameDisp = true;
                }
                if (BaseForm.UserInfo.camel)
                {
                    word = new IchiranWordBo();
                    word.ronri_name1 = isDoneRonriNameDisp ? "" : reader["ronri_name1"].ToString();
                    word.butsuri_name = reader["butsuri_name"].ToString().ToCamelCase();
                    wordList.Add(word);
                    isDoneRonriNameDisp = true;
                }
                if (BaseForm.UserInfo.snake)
                {
                    word = new IchiranWordBo();
                    word.ronri_name1 = isDoneRonriNameDisp ? "" : reader["ronri_name1"].ToString();
                    word.butsuri_name = reader["butsuri_name"].ToString().ToSnakeCase();
                    wordList.Add(word);
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wordList"></param>
        /// <param name="dispNumber"></param>
        /// <returns></returns>
        protected List<IchiranWordBo> toIchiranDispList(List<IchiranWordBo> wordList, int dispNumber)
        {
            if (wordList.Count > 0)
            {
                if (dispNumber == 0)
                {
                    return wordList;
                }
                return wordList.Take(dispNumber).ToList();
            }
            return wordList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tango"></param>
        /// <param name="wordList"></param>
        /// <returns></returns>
        protected bool isContains(string tango, List<IchiranWordBo> wordList)
        {
            if (wordList.Count > 0)
            {
                foreach (IchiranWordBo obj in wordList)
                {
                    if (obj.butsuri_name == tango)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
