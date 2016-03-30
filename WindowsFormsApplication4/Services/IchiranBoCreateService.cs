using System;
using System.Text;
using WordConverter_v2.Common;
using WordConverter_v2.Interface;
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
                    switch (this.inBo.shoriMode)
                    {
                        case WordConvTool.Const.PropertyShoriMode.プロパティ作成:
                            sb.AppendLine("/** " + ronriName + " */");
                            sb.AppendLine("private " + dataType + " " + butsuriName.ToCamelCase() + ";");
                            sb.AppendLine("");
                            break;

                        case WordConvTool.Const.PropertyShoriMode.プロパティ作成アノテーションあり:
                            sb.AppendLine("/** " + ronriName + " */");
                            sb.AppendLine("@Column(name = \"" + butsuriName.ToSnakeCase().ToLower() + "\")");
                            sb.AppendLine("private " + dataType + " " + butsuriName.ToCamelCase() + ";");
                            sb.AppendLine("");
                            break;

                        case WordConvTool.Const.PropertyShoriMode.物理名からプロパティ作成:
                            sb.AppendLine("/** " + butsuriName + " */");
                            sb.AppendLine("private " + dataType + " " + ronriName.ToCamelCase() + ";");
                            sb.AppendLine("");
                            break;

                        case WordConvTool.Const.PropertyShoriMode.物理名からプロパティ作成アノテーションあり:
                            sb.AppendLine("/** " + butsuriName + " */");
                            sb.AppendLine("@Column(name = \"" + ronriName + "\")");
                            sb.AppendLine("private " + dataType + " " + ronriName.ToCamelCase() + ";");
                            sb.AppendLine("");
                            break;

                        case WordConvTool.Const.PropertyShoriMode.ゲッター作成:
                            sb.AppendLine("get" + butsuriName + "();");
                            sb.AppendLine("");
                            break;
                    }
                    str += sb.ToString();
                }
            }
            outBo.boText = str;
            return outBo;
        }
    }
}
