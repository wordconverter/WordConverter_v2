using SQLite.Services;
using System.Collections.Generic;
using System.Linq;
using WordConverter_v2.Common;
using WordConverter_v2.Models;
using WordConverter_v2.Models.Dao;
using WordConverter_v2.Models.InBo;
using WordConverter_v2.Models.OutBo;

namespace WordConverter_v2.Services
{
    class UserKanriSearchService : IService<UserKanriSearchServiceInBo, UserKanriSearchServiceOutBo>
    {
        private UserKanriSearchServiceInBo inBo;
        private static CommonFunction common = new CommonFunction();

        public void setInBo(UserKanriSearchServiceInBo inBo)
        {
            this.inBo = inBo;
        }

        public UserKanriSearchServiceOutBo execute()
        {
            UserKanriSearchServiceOutBo outBo = new UserKanriSearchServiceOutBo();
            using (var context = new MyContext())
            {
                IQueryable<UserBo> users = from a in context.UserMst
                                           where a.delete_flg == 0
                                           select new UserBo
                                           {
                                               user_id = a.user_id,
                                               emp_id = a.emp_id,
                                               user_name = a.user_name,
                                               kengen = a.kengen,
                                               mail_id = a.mail_id,
                                               mail_address = a.mail_address,
                                               password = a.password,
                                               cre_date = a.cre_date,
                                               sanka_kahi = (a.sanka_kahi == 0 ? true : false),
                                               version = a.version
                                           };

                object[] keywords = new object[3];
                keywords[0] = this.inBo.empId;
                keywords[1] = this.inBo.userName;
                keywords[2] = this.inBo.kengenSelectedIndex;
                IQueryable<UserBo> us = users.UserMstWhereLike(keywords).OrderByDescending(item => item);

                List<UserBo> usersList = new List<UserBo>();
                if (us.Count() > 0)
                {
                    usersList = us.ToList();
                }
                outBo.usersList = usersList;
            }
            return outBo;
        }
    }
}
