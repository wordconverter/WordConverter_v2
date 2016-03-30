using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using WordConverter_v2.Common;
using WordConverter_v2.Forms;
using WordConverter_v2.Interface;
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
    class IchiranInitServiceFukusuninMode : IchiranInitServiceBase, IService<IchiranInitServiceInBo, IchiranInitServiceOutBo>
    {

        private static CommonFunction common = new CommonFunction();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inBo"></param>
        public void setInBo(IchiranInitServiceInBo inBo)
        {
            base.inBo = inBo;
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

            if (!String.IsNullOrEmpty(base.inBo.clipboardText))
            {
                CommonFunction common = new CommonFunction();
                string dbConnectionString = common.getPostgresDbConnectionString();
                string key = this.inBo.clipboardText;
                string nl = Environment.NewLine;
                String[] keys = key.Split(new string[] { nl }, StringSplitOptions.None);
                List<string> list = this.makeList(keys);

                if (keys.Count() == 1)
                {
                    using (NpgsqlConnection cn = new NpgsqlConnection(dbConnectionString))
                    {
                        NpgsqlCommand cmd = (NpgsqlCommand)this.setQueryCommandSingle(cn, list);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (!this.makeSingleWordList(reader, ref wordList, ref word)) { continue; };
                            }
                        }
                        cn.Close();
                    }
                }
                else
                {
                    Dictionary<String, String> dict = new Dictionary<String, String>();
                    using (NpgsqlConnection cn = new NpgsqlConnection(dbConnectionString))
                    {
                        NpgsqlCommand cmd = (NpgsqlCommand)this.setQueryCommandMultiple(cn, list);
                        List<IchiranWordBo> dbWordList = new List<IchiranWordBo>();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dict.Add(reader["ronri_name1"].ToString(), reader["butsuri_name"].ToString());
                            }
                        }
                        cn.Close();
                    }
                    if (dict.Count != 0)
                    {
                        int keyIndex = 0;
                        while (!String.IsNullOrEmpty(list[keyIndex]))
                        {
                            word = new IchiranWordBo();
                            word.ronri_name1 = list[keyIndex];
                            if (dict.ContainsKey(list[keyIndex]))
                            {
                                word.butsuri_name = dict[list[keyIndex]];
                            }
                            else
                            {
                                word.butsuri_name = "-";
                            }
                            wordList.Add(word);
                            keyIndex++;
                        }
                    }
                }
            }
            this.makeIchiranDispList(ref outBo, this.inBo, wordList, word);
            return outBo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        private List<string> makeList(String[] keys)
        {

            List<string> list = new List<string>();
            list.AddRange(keys);

            List<string> ret = new List<string>();

            foreach (String str in list)
            {
                if (String.IsNullOrEmpty(str))
                {
                    continue;
                }
                ret.Add(str);
            }

            return ret;
        }
    }
}
