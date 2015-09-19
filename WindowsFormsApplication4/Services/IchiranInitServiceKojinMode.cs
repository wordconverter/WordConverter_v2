using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using WordConverter_v2.Common;
using WordConverter_v2.Interface;
using WordConverter_v2.Models;
using WordConverter_v2.Models.InBo;
using WordConverter_v2.Models.OutBo;

namespace WordConverter_v2.Services
{
    public class IchiranInitServiceKojinMode : IchiranInitServiceBase, IService<IchiranInitServiceInBo, IchiranInitServiceOutBo>
    {

        public void setInBo(IchiranInitServiceInBo inBo)
        {
            base.inBo = inBo;
        }

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
                    using (SQLiteConnection cn = new SQLiteConnection(dbConnectionString))
                    {
                        SQLiteCommand cmd = (SQLiteCommand)this.setQueryCommandSingle(cn, keys);
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
                    using (SQLiteConnection cn = new SQLiteConnection(dbConnectionString))
                    {
                        SQLiteCommand cmd = (SQLiteCommand)this.setQueryCommandMultiple(cn, keys);
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
