using SQLite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using WordConverter_v2.Forms;
using WordConverter_v2.Models.Dao;
using WordConverter_v2.Models.Entity;
using WordConverter_v2.Models.InBo;
using WordConverter_v2.Models.OutBo;

namespace WordConverter_v2.Services
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

            UserRepository rep = new UserRepository();
            UserMst fromUser = rep.FindUserMstByUserId(BaseForm.UserInfo.userId);
            UserMst toUser = rep.FindMailingListUser();
            string body = "承認者：" + fromUser.user_name + System.Environment.NewLine + this.inBo.messageBody;

            System.Net.Mail.MailMessage msg = new MailMessage();
            System.Net.Mail.SmtpClient sc = new System.Net.Mail.SmtpClient();
            try
            {
                msg = new System.Net.Mail.MailMessage(fromUser.mail_address, toUser.mail_address, this.inBo.messageSubject, body);
                sc.Host = "localhost";
                sc.Port = 25;
                sc.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                sc.Credentials = new System.Net.NetworkCredential(fromUser.mail_address, fromUser.password);
                sc.Send(msg);
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(ex.Message);
                sb.AppendLine("TO・・・" + "ユーザー名：" + toUser.user_name + "、メールアドレス：" + toUser.mail_address);
                sb.AppendLine("FROM・・・" + "ユーザー名：" + fromUser.user_name + "、メールアドレス：" + fromUser.mail_address);
                outBo.errorMessage = sb.ToString();
            }
            finally
            {
                msg.Dispose();
                sc.Dispose();
            }
            return outBo;
        }
    }
}
