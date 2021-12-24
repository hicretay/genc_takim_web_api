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
                    fieldsName += "UserId,";
                    fieldsValue += "@UserId,";
                    paramsayi++;
                }

                if (GameId != null)
                {
                    fieldsName += "GameId,";
                    fieldsValue += "@GameId,";
                    paramsayi++;
                }

                if (IsSubstitute != null)
                {
                    fieldsName += "IsSubstitute,";
                    fieldsValue += "@IsSubstitute,";
                    paramsayi++;
                }
                if (UserLocation != null)
                {
                    fieldsName += "UserLocation,";
                    fieldsValue += "@UserLocation,";
                    paramsayi++;
                }

                fieldsName = fieldsName.Remove(fieldsName.Length - 1, 1);
                fieldsValue = fieldsValue.Remove(fieldsValue.Length - 1, 1);


            }
            else
            {
                if (UserId != null)
                {
                    fieldsName += "UserId=@UserId,";
                    paramsayi++;
                }
                if (GameId != null)
                {
                    fieldsName += "GameId=@GameId,";
                    paramsayi++;
                }

                if (IsSubstitute != null)
                {
                    fieldsName += "IsSubstitute=@IsSubstitute,";
                    paramsayi++;
                }

                if (UserLocation != null)
                {
                    fieldsName += "UserLocation=@UserLocation,";
                    paramsayi++;
                }


                fieldsName = fieldsName.Remove(fieldsName.Length - 1, 1);



            }

            sqlparam = new SqlParameter[paramsayi];

            while (paramsayi > i)
            {
                if (UserId != null)
                {
                    sqlparam[i] = new SqlParameter("@UserId", UserId);
                    i++;
                }
                if (GameId != null)
                {
                    sqlparam[i] = new SqlParameter("@GameId", GameId);
                    i++;
                }

                if (IsSubstitute != null)
                {
                    sqlparam[i] = new SqlParameter("@IsSubstitute", IsSubstitute);
                    i++;
                }

                if (UserLocation != null)
                {
                    sqlparam[i] = new SqlParameter("@UserLocation", UserLocation);
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

            if (columnNames.Contains("Id")) entity.Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
            if (columnNames.Contains("UserId")) entity.UserId = Convert.ToInt32(dt.Rows[0]["UserId"].ToString());
            if (columnNames.Contains("GameId")) entity.GameId = Convert.ToInt32(dt.Rows[0]["GameId"].ToString());
            if (columnNames.Contains("IsSubstitute")) entity.IsSubstitute = Boolean.TryParse(dt.Rows[0]["IsSubstitute"].ToString(),out b)? new Boolean?(b):null;
            if (columnNames.Contains("UserLocation")) entity.UserLocation = Convert.ToInt32(dt.Rows[0]["UserLocation"].ToString());

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

                if (columnNames.Contains("Id")) entity.Id = Convert.ToInt32(r["Id"].ToString());
                if (columnNames.Contains("UserId")) entity.UserId = Convert.ToInt32(r["UserId"].ToString());
                if (columnNames.Contains("GameId")) entity.GameId = Convert.ToInt32(r["GameId"].ToString());
                if (columnNames.Contains("IsSubstitute")) entity.IsSubstitute = Boolean.TryParse(r["IsSubstitute"].ToString(), out b) ? new Boolean?(b) : null;
                if (columnNames.Contains("UserLocation")) entity.UserLocation = Convert.ToInt32(r["UserLocation"].ToString());

                list.Add(entity);
            }

            return list;
        }
    }
}

