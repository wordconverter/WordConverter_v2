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
                string dbConnectionString = common.getCurrentDbConnectionString();
                string key = this.inBo.clipboardText;
                string nl = Environment.NewLine;
                String[] keys = key.Split(new string[] { nl }, StringSplitOptions.None);

                if (keys.Count() == 1)
                {
                    using (NpgsqlConnection cn = new NpgsqlConnection(dbConnectionString))
                    {
                        NpgsqlCommand cmd = (NpgsqlCommand)this.setQueryCommandSingle(cn, keys);
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
                    using (NpgsqlConnection cn = new NpgsqlConnection(dbConnectionString))
                    {
                        NpgsqlCommand cmd = (NpgsqlCommand)this.setQueryCommandMultiple(cn, keys);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.makeMultipleWordList(reader, ref wordList, ref word);
                            }
                        }
                        cn.Close();
                    }
                }
            }
            this.makeIchiranDispList(ref outBo, this.inBo, wordList, word);
            return outBo;
        }
    }
}
