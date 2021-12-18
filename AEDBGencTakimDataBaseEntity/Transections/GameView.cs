using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using AEDBGencTakimDataBaseEntity.DAO;

namespace AEDBGencTakimDataBaseEntity.Transactions
{
    [Serializable]
    public class GameView : GameViewDAO
    {
 
        public string Save(GameViewDAO tbl)
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
                return new GameTblDAO().Delete("Delete From [GameView] where Id=@Id", new SqlParameter("@Id",Id));
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

        public GameViewDAO Select(int Id) 
        {
          return new GameViewDAO().Select("select * from [GameView] where Id=@Id", new SqlParameter("@Id",Id));
        }

        public List<GameViewDAO> DataSource(int UserId, bool IsPassed) // kullanıcı id değeri gönderilecek, maçlar listesi alınacak
        {
            return new GameViewDAO().DataSource("select * from [GameView] where UserId=@UserId and IsPassed=@IsPassed", new SqlParameter("UserId", UserId), new SqlParameter("IsPassed", IsPassed));

        }

        public List<GameViewDAO> DataSource() // tüm maçların listesi 
        {
            return new GameViewDAO().DataSource("select * from [GameView]");
        }

        public List<GameViewDAO> DataSource(bool IsPassed) // yaklaşan maçların listesi 
        {
            return new GameViewDAO().DataSource("select * from [GameView] where IsPassed=@IsPassed", new SqlParameter("IsPassed", IsPassed));
        }
    }
}

