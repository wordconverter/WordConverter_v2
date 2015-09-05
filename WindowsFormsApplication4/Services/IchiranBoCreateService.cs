using SQLite.Services;
using System;
using System.Text;
using WordConverter_v2.Common;
using WordConverter_v2.Models.InBo;
using WordConverter_v2.Models.OutBo;

namespace WordConverter_v2.Services
{
    class IchiranBoCreateService : IService<IchiranBoCreateServiceInBo, IchiranBoCreateServiceOutBo>
    {
        private static CommonFunction common = new CommonFunction();

        /// <summary>
        /// 
        /// </summary>
        private IchiranBoCreateServiceInBo inBo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inBo"></param>
        public void setInBo(IchiranBoCreateServiceInBo inBo)
        {
            this.inBo = inBo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IchiranBoCreateServiceOutBo execute()
        {
            IchiranBoCreateServiceOutBo outBo = new IchiranBoCreateServiceOutBo();
            String str = "";
            for (int i = 0; i < this.inBo.ichiranDataGridView.Rows.Count; i++)
            {
                string ronriName = Convert.ToString(this.inBo.ichiranDataGridView.Rows[i].Cells["ronri_name1"].Value);
                string butsuriName = Convert.ToString(this.inBo.ichiranDataGridView.Rows[i].Cells["butsuri_name"].Value);
                string dataType = Convert.ToString(this.inBo.ichiranDataGridView.Rows[i].Cells["data_type"].Value);

                if (!String.IsNullOrEmpty(ronriName) && !String.IsNullOrEmpty(butsuriName))
                {
                    StringBuilder sb = new StringBuilder();
                    if (this.inBo.reverseCreateFlg)
                    {
                        this.makeWord(sb, butsuriName, ronriName, dataType);
                    }
                    else
                    {
                        this.makeWord(sb, ronriName, butsuriName, dataType);
                    }
                    str += sb.ToString();
                }
            }
            outBo.boText = str;
            return outBo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="dataType"></param>
        private void makeWord(StringBuilder sb, string first, string second, string dataType)
        {
            sb.AppendLine("/** " + first + " */");
            if (this.inBo.annotationFlg)
            {
                sb.AppendLine("@Column(name = \"" + first.ToSnakeCase().ToLower() + "\")");
            }
            sb.AppendLine("private " + dataType + " " + second + ";");
            sb.AppendLine("");
            sb.AppendLine("");
        }
    }
}
