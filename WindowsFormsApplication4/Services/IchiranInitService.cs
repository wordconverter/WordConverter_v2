using Npgsql;
using SQLite.Services;
using System;
using System.Collections.Generic;
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
    class IchiranInitService : IService<IchiranInitServiceInBo, IchiranInitServiceOutBo>
    {
        /// <summary>
        /// 
        /// </summary>
        private IchiranInitServiceInBo inBo = new IchiranInitServiceInBo();
        private static CommonFunction common = new CommonFunction();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inBo"></param>
        public void setInBo(IchiranInitServiceInBo inBo)
        {
            this.inBo = inBo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IchiranInitServiceOutBo execute()
        {
            IchiranInitServiceOutBo outBo = new IchiranInitServiceOutBo();
            List<IchiranWordBo> wordList = new List<IchiranWordBo>();
            IchiranWordBo word = new IchiranWordBo();

            if (!String.IsNullOrEmpty(this.inBo.clipboardText))
            {
                CommonFunction common = new CommonFunction();
                string dbConnectionString = common.getDbConnectionString();
                string key = this.inBo.clipboardText;
                string nl = Environment.NewLine;
                String[] keys = key.Split(new string[] { nl }, StringSplitOptions.None);

                if (keys.Count() == 1)
                {
                    using (NpgsqlConnection cn = new NpgsqlConnection(dbConnectionString))
                    {
                        cn.Open();
                        NpgsqlCommand cmd = cn.CreateCommand();

                        string[] sp = { " ", "　" };
                        String[] keyStrs = keys[0].Split(sp, StringSplitOptions.None);
                        String condition = keyStrs.CommaSeparatedValue();
                        condition = condition.Replace("\'", "");
                        condition = "\'" + condition.Replace(",", "%") + "%\'";

                        cmd.CommandText = "SELECT * FROM WORD_DIC where ronri_name1 like (" + condition + ")";

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (!isContains(reader["butsuri_name"].ToString(), wordList))
                                {
                                    if (!reader["butsuri_name"].ToString().IsAlphanumeric())
                                    {
                                        word = new IchiranWordBo();
                                        word.ronri_name1 = reader["ronri_name1"].ToString();
                                        word.butsuri_name = reader["butsuri_name"].ToString();
                                        wordList.Add(word);
                                        continue;
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
                            }
                        }
                        cn.Close();
                    }
                }
                else
                {
                    using (NpgsqlConnection cn = new NpgsqlConnection(dbConnectionString))
                    {
                        cn.Open();
                        NpgsqlCommand cmd = cn.CreateCommand();
                        string condition = keys.CommaSeparatedValue();
                        cmd.CommandText = "SELECT * FROM WORD_DIC where ronri_name1 in (" + condition + ")";

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                word = new IchiranWordBo();
                                word.ronri_name1 = reader["ronri_name1"].ToString();
                                word.butsuri_name = reader["butsuri_name"].ToString();
                                wordList.Add(word);
                            }
                        }
                        cn.Close();
                    }
                }
            }

            if (wordList.Count == 0 || String.IsNullOrEmpty(this.inBo.clipboardText))
            {
                word.ronri_name1 = "-";
                word.butsuri_name = Constant.NONE_WORD;
                wordList.Add(word);
            }

            outBo.wordList = this.toIchiranDispList(wordList, this.inBo.dispNumber);
            return outBo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wordList"></param>
        /// <param name="dispNumber"></param>
        /// <returns></returns>
        private List<IchiranWordBo> toIchiranDispList(List<IchiranWordBo> wordList, int dispNumber)
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
        private bool isContains(string tango, List<IchiranWordBo> wordList)
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
