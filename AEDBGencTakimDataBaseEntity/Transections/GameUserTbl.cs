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

        public List<GameUserTblDAO> DataSource()
        {
           return new GameUserTblDAO().DataSource("select * from [GameUserTbl]");
        }
    }
}

