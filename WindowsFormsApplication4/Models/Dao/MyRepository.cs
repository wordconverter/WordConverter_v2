using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordConverter_v2.Models.Entity;
using WordConvTool.Const;

namespace WordConverter_v2.Models.Dao
{
    public class MyRepository
    {
        private MyContext context;
        private string dbType;

        public MyRepository(string dbType)
        {
            context = new MyContext(dbType);
        }

        public List<UserMst> FindAllUserMst()
        {
            return context.UserMst.ToList();
        }

        public UserMst FindUserMstByUserId(long userId)
        {
            var tt = context.UserMst.ToArray();
            return context.UserMst.SingleOrDefault(x => x.user_id == userId && x.delete_flg == 0);
        }

        public UserMst FindSankaUserByEmpId(int empId)
        {
            IEnumerable<UserMst> list = context.UserMst.ToList().Where(x => x.emp_id == empId && x.delete_flg == 0);
            if (list.Count() == 1)
            {
                return context.UserMst.ToList().Single(x => x.emp_id == empId && x.delete_flg == 0);
            }
            return new UserMst();
        }

        public OrMap FindOrMapByDbDataType(string dbDataType)
        {
            IEnumerable<OrMap> list = context.OrMap.ToList().Where(x => x.db_data_type == dbDataType && x.delete_flg == 0);
            if (list.Count() == 1)
            {
                return context.OrMap.ToList().Single(x => x.db_data_type == dbDataType && x.delete_flg == 0);
            }
            return new OrMap();
        }

        public bool DeleteUserByUserId(long userId)
        {
            var u = context.UserMst.Single(x => x.user_id == userId);
            u.delete_flg = 1;
            u.cre_date = System.DateTime.Now.ToString();
            context.SaveChanges();
            return true;
        }

        public bool IsExistUser(long empId)
        {
            IEnumerable<UserMst> users = context.UserMst.ToList().Where(x => x.emp_id == empId && x.delete_flg == 0);
            if (users.Count() == 1)
            {
                return true;
            }
            return false;
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
