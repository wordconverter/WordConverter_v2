using System;
using System.Linq;
using System.Linq.Expressions;
using WordConverter_v2.Models;
using WordConvTool.Const;

namespace WordConverter_v2.Common
{
    public static class LinqExtension
    {
        private static CommonFunction common = new CommonFunction();

 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static IQueryable<UserBo> UserMstWhereLike(
            this IQueryable<UserBo> source, object[] keyword)
        {
            Expression<Func<UserBo, bool>> predict = x => 1 == 1;
            var empId = keyword[0].ToString().ToIntType();
            var userName = keyword[1].ToString();
            var kengen = keyword[2].ToString().ToIntType();

            if (!String.IsNullOrEmpty(keyword[0].ToString()) &&
                !String.IsNullOrEmpty(keyword[1].ToString()) &&
                keyword[2].ToString().ToIntType() != -1 &&
                keyword[2].ToString().ToIntType() != 2)
            {
                predict = x => x.emp_id == empId && x.user_name.Contains(userName) && x.kengen == kengen;
                return source.Where(predict);
            }

            if (!String.IsNullOrEmpty(keyword[0].ToString()) &&
                !String.IsNullOrEmpty(keyword[1].ToString()) &&
                (keyword[2].ToString().ToIntType() == -1 ||
                keyword[2].ToString().ToIntType() == 2))
            {
                predict = x => x.emp_id == empId && x.user_name.Contains(userName);
                return source.Where(predict);
            }

            if (!String.IsNullOrEmpty(keyword[0].ToString()) &&
                String.IsNullOrEmpty(keyword[1].ToString()) &&
                keyword[2].ToString().ToIntType() != -1 &&
                keyword[2].ToString().ToIntType() != 2)
            {
                predict = x => x.emp_id == empId && x.kengen == kengen;
                return source.Where(predict);
            }

            if (String.IsNullOrEmpty(keyword[0].ToString()) &&
                !String.IsNullOrEmpty(keyword[1].ToString()) &&
                keyword[2].ToString().ToIntType() != -1 &&
                keyword[2].ToString().ToIntType() != 2)
            {
                predict = x => x.user_name.Contains(userName) && x.kengen == kengen;
                return source.Where(predict);
            }

            if (!String.IsNullOrEmpty(keyword[0].ToString()))
            {
                predict = x => x.emp_id == empId;
                return source.Where(predict);
            }

            if (!String.IsNullOrEmpty(keyword[1].ToString()))
            {
                predict = x => x.user_name.Contains(userName);
                return source.Where(predict);
            }

            if (keyword[2].ToString().ToIntType() == (int)KengenKbn.一般
                || keyword[2].ToString().ToIntType() == (int)KengenKbn.管理
                || keyword[2].ToString().ToIntType() == (int)KengenKbn.メーリングリスト)
            {
                predict = x => x.kengen == kengen;
                return source.Where(predict);
            }

            return source.Where(predict);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static IQueryable<HenshuWordBo> WordDicWhereLike(
        this IQueryable<HenshuWordBo> source, object[] keyword)
        {
            Expression<Func<HenshuWordBo, bool>> predict = x => 1 == 1;
            //var ronriname1 = keyword[0].ToString();
            //// ronriname2 = keyword[1].ToString();
            //var butsuriname = keyword[1].ToString();

            //if (!String.IsNullOrEmpty(keyword[0].ToString()) &&
            //    !String.IsNullOrEmpty(keyword[1].ToString()) &&
            //    !String.IsNullOrEmpty(keyword[2].ToString()))
            //{
            //    predict = x => x.ronri_name1.Contains(ronriname1) && x.ronri_name2.Contains(ronriname2) && x.butsuri_name.Contains(butsuriname);
            //    return source.Where(predict);
            //}

            //if (!String.IsNullOrEmpty(keyword[0].ToString()) &&
            //    !String.IsNullOrEmpty(keyword[1].ToString()) &&
            //    String.IsNullOrEmpty(keyword[2].ToString()))
            //{
            //    predict = x => x.ronri_name1.Contains(ronriname1) && x.ronri_name2.Contains(ronriname2);
            //    return source.Where(predict);
            //}

            //if (!String.IsNullOrEmpty(keyword[0].ToString()) &&
            //    String.IsNullOrEmpty(keyword[1].ToString()) &&
            //    !String.IsNullOrEmpty(keyword[2].ToString()))
            //{
            //    predict = x => x.ronri_name1.Contains(ronriname1) && x.butsuri_name.Contains(butsuriname);
            //    return source.Where(predict);
            //}

            //if (String.IsNullOrEmpty(keyword[0].ToString()) &&
            //    !String.IsNullOrEmpty(keyword[1].ToString()) &&
            //    !String.IsNullOrEmpty(keyword[2].ToString()))
            //{
            //    predict = x => x.ronri_name2.Contains(ronriname2) && x.butsuri_name.Contains(butsuriname);
            //    return source.Where(predict);
            //}

            //if (!String.IsNullOrEmpty(keyword[0].ToString()) &&
            //    String.IsNullOrEmpty(keyword[1].ToString()) &&
            //    String.IsNullOrEmpty(keyword[2].ToString()))
            //{
            //    predict = x => x.ronri_name1.Contains(ronriname1);
            //    return source.Where(predict);
            //}

            //if (String.IsNullOrEmpty(keyword[0].ToString()) &&
            //    !String.IsNullOrEmpty(keyword[1].ToString()) &&
            //    String.IsNullOrEmpty(keyword[2].ToString()))
            //{
            //    predict = x => x.ronri_name2.Contains(ronriname2);
            //    return source.Where(predict);
            //}

            //if (String.IsNullOrEmpty(keyword[0].ToString()) &&
            //    String.IsNullOrEmpty(keyword[1].ToString()) &&
            //    !String.IsNullOrEmpty(keyword[2].ToString()))
            //{
            //    predict = x => x.butsuri_name.Contains(butsuriname);
            //    return source.Where(predict);
            //}

            return source.Where(predict);
        }
    }
}
