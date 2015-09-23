using System.Collections.Generic;
using System.Linq;
using WordConverter_v2.Forms;
using WordConverter_v2.Interface;
using WordConverter_v2.Models;
using WordConverter_v2.Models.Dao;
using WordConverter_v2.Models.InBo;
using WordConverter_v2.Models.OutBo;
using WordConvTool.Const;

namespace WordConverter_v2.Services
{
    class ShinseiInitService : IService<ShinseiInitServiceInBo, ShinseiInitServiceOutBo>
    {
        /// <summary>
        /// 
        /// </summary>
        private ShinseiInitServiceInBo inBo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inBo"></param>
        public void setInBo(ShinseiInitServiceInBo inBo)
        {
            this.inBo = inBo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ShinseiInitServiceOutBo execute()
        {
            ShinseiInitServiceOutBo shinseiInitOutBo = new ShinseiInitServiceOutBo();
            List<ShinseiBo> dispShinseiList = null;

            using (var context = new MyContext(BaseForm.UserInfo.dbType))
            {
                IQueryable<ShinseiBo> shinseiWords = from a in context.WordShinsei
                                                     join b in context.UserMst on a.user_id equals b.user_id into tmpUser
                                                     from u in tmpUser.DefaultIfEmpty()
                                                     where a.status == 0
                                                     select new ShinseiBo
                                                     {
                                                         shinsei_id = a.shinsei_id,
                                                         ronri_name1 = a.ronri_name1,
                                                         ronri_name2 = a.ronri_name2,
                                                         butsuri_name = a.butsuri_name,
                                                         user_name = null != u ? u.user_name : "",
                                                         cre_date = a.cre_date,
                                                         status = ((ShinseiKbn)a.status).ToString(),
                                                         //version = a.version
                                                     };

                dispShinseiList = shinseiWords.Where(a => a.shinsei_id != 0).ToList();
            }
            shinseiInitOutBo.dispShinseiList = dispShinseiList;
            return shinseiInitOutBo;
        }
    }
}
