using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using AEDBGencTakimDataBaseEntity.DAO;

namespace AEDBGencTakimDataBaseEntity.Transactions
{
    [Serializable]
    public class GameTbl : GameTblDAO
    {
 
        public string Save(GameTblDAO tbl)
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
                return new GameTblDAO().Delete("Delete From [GameTbl] where Id=@Id", new SqlParameter("@Id",Id));
            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
        public GameTblDAO Select(int Id) 
        {
          return new GameTblDAO().Select("select * from [GameTbl] where Id=@Id", new SqlParameter("@Id",Id));
        }

        public List<GameTblDAO> DataSource() // kullanıcı id değeri gönderilecek, maçlar listesi alınacak
        {
           return new GameTblDAO().DataSource("select * from [GameTbl]");
        }

        //public List<GameTblDAO> DataSourceMac(int Id) // kullanıcı id değeri gönderilecek, maçlar listesi alınacak
        //{
        //    return new GameTblDAO().DataSource("select * from [GameTbl] where Id in (select GameId from  GameUserTbl where UserId=@userId)", new SqlParameter("@Id", Id), new SqlParameter("UserId", UserId));
        //}
    }
}

