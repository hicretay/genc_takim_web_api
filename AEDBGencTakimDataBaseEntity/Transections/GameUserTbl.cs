using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using AEDBGencTakimDataBaseEntity.DAO;

namespace AEDBGencTakimDataBaseEntity.Transactions
{
    [Serializable]
    public class GameUserTbl : GameUserTblDAO
    {
 
        public string Save(GameUserTblDAO tbl)
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
                return new GameUserTblDAO().Delete("Delete From [GameUserTbl] where Id=@Id", new SqlParameter("@Id",Id));
            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
        public GameUserTblDAO Select(int Id)
        {
          return new GameUserTblDAO().Select("select * from [GameUserTbl] where Id=@Id", new SqlParameter("@Id",Id));
        }

        public GameUserTblDAO SelectDifferent(int Id)
        {
            return new GameUserTblDAO().Select("select * from [GameUserTbl] where Id=@Id", new SqlParameter("@Id", Id));
        }

        public List<GameUserTblDAO> DataSource()
        {
           return new GameUserTblDAO().DataSource("select * from [GameUserTbl]");
        }

        public GameUserTblDAO SelectDifferentUserLocation(int userId, int gameId)
        {
            return new GameUserTblDAO().Select("select * from [GameUserTbl] where UserId=@UserId and GameId=@GameId", new SqlParameter("@userId", userId), new SqlParameter("@gameId", gameId));
        }

        public GameUserTblDAO SelectDifLocation(int userLocation, int gameId)   
        {
            return new GameUserTblDAO().Select("select * from [GameUserTbl] where UserLocation=@UserLocation and GameId=@GameId", new SqlParameter("@UserLocation", userLocation), new SqlParameter("@gameId", gameId));
        }
    }
}

