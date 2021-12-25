using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using AEDBGencTakimDataBaseEntity.DAO;

namespace AEDBGencTakimDataBaseEntity.Transactions
{
    [Serializable]
    public class UserTbl : UserTblDAO
    {
 
        public string Save(UserTblDAO tbl)
        {//kaydetme başlar
            try
            {
                return tbl.Save();
            }
            catch (Exception ex)
            {
                return ex.Message;

            }

        }//kaydetme biter

        public string Delete(int Id)
        {
             try
            {
                return new UserTblDAO().Delete("Delete From [UserTbl] where Id=@Id",new SqlParameter("@Id",Id));
            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
        public UserTblDAO Select(int Id)
        {
            return new UserTblDAO().Select("select * from [UsersTbl] where id=@Id",new SqlParameter("@Id",Id));
        }

        public List<UserTblDAO> DataSource() // bütün kullanıcıları getirir, parametre gönderilerek özelleştirilir
        {
           return new UserTblDAO().DataSource("select * from [UserTbl]"); // parametreye göre sorgu sonuna where cümlesi eklenir
        }

        public UserTblDAO Select(string userEmail, string userPassword)     
        {
            return new UserTblDAO().Select("select * from [UserTbl] where UserEmail=@userEmail and UserPassword=@userPassword", new SqlParameter("@userEmail", userEmail), new SqlParameter("@userPassword", userPassword));
        }

        public UserTblDAO SelectDifferentUser(string userEmail)
        {
            return new UserTblDAO().Select("select * from [UserTbl] where UserEmail=@userEmail", new SqlParameter("@userEmail", userEmail));
        }
    }
}

