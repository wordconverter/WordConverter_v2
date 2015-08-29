using SQLite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication4.Services;
using WordConverter_v2.Forms;
using WordConverter_v2.Models.Dao;
using WordConverter_v2.Models.Entity;

namespace WindowsFormsApplication4.Forms
{
    public class MailService : IService<MailServiceInBo, MailServiceOutBo>
    {
        private MailServiceInBo inBo;

        public void setInBo(MailServiceInBo inBo)
        {
            this.inBo = inBo;
        }

        public MailServiceOutBo execute()
        {
            MailServiceOutBo outBo = new MailServiceOutBo();

            string message = "単語の承認が完了しました。" + System.Environment.NewLine + System.Environment.NewLine;
            foreach (WordDic obj in this.inBo.shinseiWordDicList)
            {
                message += "論理名1：" + obj.ronri_name1 + "、論理名2：" + obj.ronri_name2 + "、物理名：" + obj.butsuri_name + " " + System.Environment.NewLine;
            }

            UserRepository rep = new UserRepository();
            UserMst user = rep.FindUserMstByUserId(BaseForm.UserInfo.userId);

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage(
                user.mail_address, "kamiyaj@sample.com", "承認完了", message);

            System.Net.Mail.SmtpClient sc = new System.Net.Mail.SmtpClient();
            sc.Host = "localhost";
            sc.Port = 25;
            sc.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            sc.Credentials = new System.Net.NetworkCredential("kamiyaj@sample.com", "jyjkmy987");
            sc.Send(msg);
            msg.Dispose();
            sc.Dispose();

            return outBo;
        }
    }
}
