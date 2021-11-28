using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace AEDBGencTakimDataBaseEntity.DAO
{
    [Serializable]
    public class GameUserTblDAO : AEDBGencTakimDataBaseEntity.Entities.GameUserTblBase
    {
        private DateTime dti;
        private Boolean b;
        private Decimal d;
        private int ii;
        private Int16 ii16;

        internal string Save()
        {
            string sqlcum = "";
            SqlParameter[] sqlparam;
            string fieldsName = "";
            string fieldsValue = "";
            int paramsayi = 0;
            int i = 0;
            if (this.Id == null) this.Id = 0;
            if (this.Id == 0) // insert işlemi ise
            {
                if (UserId != null)
                {
                    fieldsName += "userId,";
                    fieldsValue += "@userId,";
                    paramsayi++;
                }

                if (GameId != null)
                {
                    fieldsName += "gameId,";
                    fieldsValue += "@gameId,";
                    paramsayi++;
                }

                if (GamePlayTime != null)
                {
                    fieldsName += "gamePlayTime,";
                    fieldsValue += "@gamePlayTime,";
                    paramsayi++;
                }

                if (IsSubstitute != null)
                {
                    fieldsName += "isSubstitute,";
                    fieldsValue += "@isSubstitute,";
                    paramsayi++;
                }

                fieldsName = fieldsName.Remove(fieldsName.Length - 1, 1);
                fieldsValue = fieldsValue.Remove(fieldsValue.Length - 1, 1);


            }
            else
            {
                if (UserId != null)
                {
                    fieldsName += "userId=@userId,";
                    paramsayi++;
                }
                if (GameId != null)
                {
                    fieldsName += "gameId=@gameId,";
                    paramsayi++;
                }

                if (GamePlayTime != null)
                {
                    fieldsName += "gamePlayTime=@gamePlayTime,";
                    paramsayi++;
                }

                if (IsSubstitute != null)
                {
                    fieldsName += "isSubstitute=@isSubstitute,";
                    paramsayi++;
                }


                fieldsName = fieldsName.Remove(fieldsName.Length - 1, 1);



            }

            sqlparam = new SqlParameter[paramsayi];

            while (paramsayi > i)
            {
                if (UserId != null)
                {
                    sqlparam[i] = new SqlParameter("@userId", UserId);
                    i++;
                }
                if (GameId != null)
                {
                    sqlparam[i] = new SqlParameter("@gameId", GameId);
                    i++;
                }

                if (GamePlayTime != null)
                {
                    sqlparam[i] = new SqlParameter("@gamePlayTime", GamePlayTime);
                    i++;
                }

                if (IsSubstitute != null)
                {
                    sqlparam[i] = new SqlParameter("@isSubstitute", IsSubstitute);
                    i++;
                }

                
            }

            if (this.Id == 0)
            {
                sqlcum = "Insert INTO [GameUserTbl](" + fieldsName + ")Values(" + fieldsValue + ")";

                DatabaseOperations.ParameterOperation(sqlcum, sqlparam);
                this.Id = Convert.ToInt32(DatabaseOperations.dtb("select max(Id) from [GameUserTbl]").Rows[0][0]);
                return "1";
            }
            else
            {
                sqlcum = "UPDATE [GameUserTbl] SET " + fieldsName + " where Id =" + this.Id;
                DatabaseOperations.ParameterOperation(sqlcum, sqlparam);
                return "2";
            }


        }

        internal string Delete(string _sql, params SqlParameter[] paramss)
        {
            DatabaseOperations.ParameterOperation(_sql, paramss);
            return "3";
        }

        internal GameUserTblDAO Select(string sql_, params SqlParameter[] paramss)
        {

            GameUserTblDAO entity = new GameUserTblDAO();
            DataTable dt = (DataTable) DatabaseOperations.ParameterOperation(sql_, paramss);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();

            if (columnNames.Contains("id")) entity.Id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
            if (columnNames.Contains("userId")) entity.UserId = Convert.ToInt32(dt.Rows[0]["userId"].ToString());
            if (columnNames.Contains("gameId")) entity.GameId = Convert.ToInt32(dt.Rows[0]["gameId"].ToString());
            if (columnNames.Contains("gamePlayTime")) entity.GamePlayTime = DateTime.TryParse(dt.Rows[0]["gamePlayTime"].ToString(), out dti) ? new DateTime?(dti) : null;
            if (columnNames.Contains("isSubstitute")) entity.IsSubstitute = Boolean.TryParse(dt.Rows[0]["isSubstitute"].ToString(),out b)? new Boolean?(b):null;

            return entity;
        } // okuma işlemi bitiyor

        internal List<GameUserTblDAO> DataSource(string sql_, params SqlParameter[] paramss)
        {

            List<GameUserTblDAO> list = new List<GameUserTblDAO>();
            DataTable dt;
            if (paramss == null)
                dt = (DataTable) DatabaseOperations.dtb(sql_);
            else
                dt = (DataTable) DatabaseOperations.ParameterOperation(sql_, paramss);


            string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
            foreach (DataRow r in dt.Rows)
            {
                GameUserTblDAO entity = new GameUserTblDAO();

                if (columnNames.Contains("id")) entity.Id = Convert.ToInt32(r["id"].ToString());
                if (columnNames.Contains("userId")) entity.UserId = Convert.ToInt32(r["userId"].ToString());
                if (columnNames.Contains("gameId")) entity.GameId = Convert.ToInt32(r["gameId"].ToString());
                if (columnNames.Contains("gamePlayTime")) entity.GamePlayTime = DateTime.TryParse(r["gamePlayTime"].ToString(), out dti) ? new DateTime?(dti) : null;
                if (columnNames.Contains("isSubstitute")) entity.IsSubstitute = Boolean.TryParse(r["isSubstitute"].ToString(), out b) ? new Boolean?(b) : null;

                list.Add(entity);
            }

            return list;
        }
    }
}

