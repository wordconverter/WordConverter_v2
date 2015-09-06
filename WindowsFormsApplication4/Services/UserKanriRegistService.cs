using SQLite.Services;
using System;
using WordConverter_v2.Common;
using WordConverter_v2.Const;
using WordConverter_v2.Models.Dao;
using WordConverter_v2.Models.Entity;
using WordConverter_v2.Models.InBo;
using WordConverter_v2.Models.OutBo;
using System.Linq;
using WordConverter_v2.Forms;

namespace WordConverter_v2.Services
{
    class UserKanriRegistService : IService<UserKanriRegistServiceInBo, UserKanriRegistServiceOutBo>
    {
        private UserKanriRegistServiceInBo inBo;
        private static CommonFunction common = new CommonFunction();

        public void setInBo(UserKanriRegistServiceInBo inBo)
        {
            this.inBo = inBo;
        }

        public UserKanriRegistServiceOutBo execute()
        {
            UserKanriRegistServiceOutBo outBo = new UserKanriRegistServiceOutBo();
            if (this.inputCheck(this.inBo, ref outBo)) { return outBo; }

            for (int i = 0; i < this.inBo.userKanriDataGridView1.Rows.Count; i++)
            {
                if (this.inBo.userKanriDataGridView1.Rows[i].Cells[0].Value == null
                    || (bool)this.inBo.userKanriDataGridView1.Rows[i].Cells[0].Value == false)
                {
                    continue;
                }

                using (var context = new MyContext())
                {
                    long condtion = Convert.ToInt64(this.inBo.userKanriDataGridView1.Rows[i].Cells["user_id"].Value.ToString());
                    var upUser = context.UserMst.Where(x => x.user_id == condtion);
                    if (upUser.Count() == 1)
                    {
                        var u = context.UserMst.Single(x => x.user_id == condtion);
                        int empId = this.inBo.userKanriDataGridView1.Rows[i].Cells["emp_id"].Value.ToString().ToIntType();
                        u.emp_id = empId;
                        u.user_name = Convert.ToString(this.inBo.userKanriDataGridView1.Rows[i].Cells["user_name"].Value);
                        u.kengen = this.inBo.userKanriDataGridView1.Rows[i].Cells["kengen"].Value.ToString().ToIntType();
                        u.sanka_kahi = (bool)this.inBo.userKanriDataGridView1.Rows[i].Cells["sanka_kahi"].Value ? 0 : 1;
                        u.mail_id = this.inBo.userKanriDataGridView1.Rows[i].Cells["mail_id"].Value.ToString();
                        u.mail_address = this.inBo.userKanriDataGridView1.Rows[i].Cells["mail_address"].Value.ToString();
                        u.password = this.inBo.userKanriDataGridView1.Rows[i].Cells["password"].Value.ToString();
                        u.cre_date = System.DateTime.Now.ToString();
                        context.SaveChanges();
                        if (BaseForm.UserInfo.empId == empId)
                        {
                            outBo.empId = empId;
                        }
                        continue;
                    }
                    UserMst user = new UserMst();
                    user.emp_id = this.inBo.userKanriDataGridView1.Rows[i].Cells["emp_id"].Value.ToString().ToIntType();
                    user.user_name = this.inBo.userKanriDataGridView1.Rows[i].Cells["user_name"].Value.ToString();
                    user.kengen = this.inBo.userKanriDataGridView1.Rows[i].Cells["kengen"].Value.ToString().ToIntType();
                    user.sanka_kahi = (bool)this.inBo.userKanriDataGridView1.Rows[i].Cells["sanka_kahi"].Value ? 0 : 1;
                    user.mail_id = this.inBo.userKanriDataGridView1.Rows[i].Cells["mail_id"].Value.ToString();
                    user.mail_address = this.inBo.userKanriDataGridView1.Rows[i].Cells["mail_address"].Value.ToString();
                    user.password = this.inBo.userKanriDataGridView1.Rows[i].Cells["password"].Value.ToString();
                    user.cre_date = System.DateTime.Now.ToString();
                    context.UserMst.Add(user);
                    context.SaveChanges();
                }
            }
            return outBo;
        }

        private bool inputCheck(UserKanriRegistServiceInBo userKanriRegistServiceInBo, ref UserKanriRegistServiceOutBo outBo)
        {
            bool isExistCheck = false;
            for (int i = 0; i < this.inBo.userKanriDataGridView1.Rows.Count; i++)
            {
                if (this.inBo.userKanriDataGridView1.Rows[i].Cells[0].Value == null
                    || (bool)this.inBo.userKanriDataGridView1.Rows[i].Cells[0].Value == false)
                {
                    continue;
                }

                if (this.inBo.userKanriDataGridView1.Rows[i].Cells["mail_id"].Value == null
                    || this.inBo.userKanriDataGridView1.Rows[i].Cells["mail_address"].Value == null
                    || this.inBo.userKanriDataGridView1.Rows[i].Cells["password"].Value == null)
                {
                    outBo.errorMessage = "社員ID:" + this.inBo.userKanriDataGridView1.Rows[i].Cells["emp_id"].Value.ToString() + MessageConst.ERR_006;
                    return true;
                }
                isExistCheck = true;
            }
            if (!isExistCheck)
            {
                outBo.errorMessage = MessageConst.ERR_005;
                return true;
            }
            return false;
        }
    }
}
