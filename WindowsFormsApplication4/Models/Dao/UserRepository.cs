using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordConverter_v2.Models.Entity;
using WordConvTool.Const;

namespace WordConverter_v2.Models.Dao
{
    public class UserRepository
    {
        private MyContext context = new MyContext();

        public List<UserMst> FindAllUserMst()
        {
            return context.UserMst.ToList();
        }

        public UserMst FindUserMstByUserId(long userId)
        {
            return context.UserMst.ToList().Single(x => x.user_id == userId && x.delete_flg == 0);
        }

        public UserMst FindMailingListUser()
        {
            IEnumerable<UserMst> users = context.UserMst.ToList().Where(x => x.kengen == (int)KengenKbn.メーリングリスト && x.delete_flg == 0);
            if (users.Count() == 0)
            {
                return new UserMst();
            }
            return context.UserMst.ToList().Single(x => x.kengen == (int)KengenKbn.メーリングリスト && x.delete_flg == 0);
        }

        public List<WordShinsei> FindAllWordShinsei()
        {
            return context.WordShinsei.ToList();
        }

        public List<WordDic> FindAllWordDic()
        {
            return context.WordDic.ToList();
        }

        public void InsertWordDic(WordDic entity)
        {
            context.WordDic.Add(entity);
            context.SaveChanges();
        }

        public void InsertWordShinsei(WordShinsei entity)
        {
            context.WordShinsei.Add(entity);
            context.SaveChanges();
        }
    }
}
