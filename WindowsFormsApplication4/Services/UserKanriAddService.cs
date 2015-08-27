using SQLite.Services;
using System.Collections.Generic;
using WordConverter_v2.Common;
using WordConverter_v2.Models;
using WordConverter_v2.Models.Dao;
using WordConverter_v2.Models.InBo;
using WordConverter_v2.Models.OutBo;
using System.Linq;

namespace WordConverter_v2.Services
{
    class UserKanriAddService : IService<UserKanriAddServiceInBo, UserKanriAddServiceOutBo>
    {
        private static CommonFunction common = new CommonFunction();
        private UserKanriAddServiceInBo inBo;

        public void setInBo(UserKanriAddServiceInBo inBo)
        {
            this.inBo = inBo;
        }

        public UserKanriAddServiceOutBo execute()
        {
            UserKanriAddServiceOutBo outBo = new UserKanriAddServiceOutBo();
            using (var context = new MyContext())
            {
                int condition = this.inBo.empId.ToIntType();
                var products = context.UserMst
                    .Where(x => x.emp_id == condition)
                    .ToArray();

                if (products.Count() > 0)
                {
                    outBo.errorMessage = "既に登録されています\n";
                    return outBo;
                }
            }

            for (int i = 0; i < this.inBo.userKanriDataGridView1.Rows.Count; i++)
            {
                if (this.inBo.userKanriDataGridView1.Rows[i].Cells["emp_id"].Value.ToString().ToIntType()
                    == this.inBo.empId.ToIntType())
                {
                    outBo.errorMessage = "既に追加されています\n";
                    return outBo;
                }
            }

            List<UserBo> userList = new List<UserBo>();
            UserBo user = new UserBo();

            for (int i = 0; i < this.inBo.userKanriDataGridView1.Rows.Count; i++)
            {
                user = new UserBo();
                user.user_id = this.inBo.userKanriDataGridView1.Rows[i].Cells["user_id"].Value.ToString().ToIntType();
                user.emp_id = this.inBo.userKanriDataGridView1.Rows[i].Cells["emp_id"].Value.ToString().ToIntType();
                user.user_name = this.inBo.userKanriDataGridView1.Rows[i].Cells["user_name"].Value.ToString();
                user.kengen = this.inBo.userKanriDataGridView1.Rows[i].Cells["kengen"].Value.ToString().ToIntType();
                user.sanka_kahi = (bool)this.inBo.userKanriDataGridView1.Rows[i].Cells["sanka_kahi"].Value;
                user.mail_id = common.nullAble(this.inBo.userKanriDataGridView1.Rows[i].Cells["mail_id"].Value);
                user.mail_address = common.nullAble(this.inBo.userKanriDataGridView1.Rows[i].Cells["mail_address"].Value);
                user.password = common.nullAble(this.inBo.userKanriDataGridView1.Rows[i].Cells["password"].Value);
                user.cre_date = common.nullAble(this.inBo.userKanriDataGridView1.Rows[i].Cells["cre_date"].Value);
                userList.Add(user);
            }

            user = new UserBo();
            user.emp_id = this.inBo.empId.ToIntType();
            user.user_name = this.inBo.userName;
            user.kengen = this.inBo.kengenSelectedIndex;
            user.sanka_kahi = true;
            user.mail_id = this.inBo.empId;
            user.mail_address = this.inBo.empId;
            user.password = this.inBo.empId;
            userList.Add(user);
            outBo.userList = userList;

            return outBo;
        }
    }
}
