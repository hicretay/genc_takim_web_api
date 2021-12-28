using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using AEDBGencTakimDataBaseEntity.DAO;

namespace AEDBGencTakimDataBaseEntity.Transactions
{
    [Serializable]
    public class GameUserView : GameUserViewDAO
    {
 
        public string Save(GameUserViewDAO tbl)
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
                return new GameUserViewDAO().Delete("Delete From [GameUserView] where Id=@Id", new SqlParameter("@Id",Id));
            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }

        public object DataSourceMac(int? ıd)
        {
            throw new NotImplementedException();
        }

        public GameUserViewDAO Select(int Id) 
        {
          return new GameUserViewDAO().Select("select * from [GameUserView] where Id=@Id", new SqlParameter("@Id",Id));
        }

        public List<GameUserViewDAO> DataSource(int UserId, bool IsPassed) // kullanıcı id değeri gönderilecek, maçlar listesi alınacak
        {
            return new GameUserViewDAO().DataSource("select * from [GameUserView] where UserId=@UserId and IsPassed=@IsPassed", new SqlParameter("UserId", UserId), new SqlParameter("IsPassed", IsPassed));

        }

        public List<GameUserViewDAO> DataSource() // tüm maçların listesi 
        {
            return new GameUserViewDAO().DataSource("select * from [GameUserView]");
        }

        public List<GameUserViewDAO> DataSource(bool IsPassed) // yaklaşan maçların listesi 
        {
            return new GameUserViewDAO().DataSource("select * from [GameUserView] where IsPassed=@IsPassed", new SqlParameter("IsPassed", IsPassed));
        }

        public List<GameUserViewDAO> ExistLocation(int Id)
        {
            return new GameUserViewDAO().DataSource("select * from [GameUserView] where Id=@Id", new SqlParameter("@Id", Id));
        }

    }
}

