using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace AEDBGencTakimDataBaseEntity.DAO
{
    [Serializable]
    public class GameTblDAO : AEDBGencTakimDataBaseEntity.Entities.GameTblBase
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
                if (SportId != null)
                {
                    fieldsName += "sportId,";
                    fieldsValue += "@sportId,";
                    paramsayi++;
                }

                if (UserId != null)
                {
                    fieldsName += "userId,";
                    fieldsValue += "@userId,";
                    paramsayi++;
                }

                if (SaloonId != null)
                {
                    fieldsName += "saloonId,";
                    fieldsValue += "@saloonId,";
                    paramsayi++;
                }

                if (GameNote != null)
                {
                    fieldsName += "gameNote,";
                    fieldsValue += "@gameNote,";
                    paramsayi++;
                }

                if (GamePassed != null)
                {
                    fieldsName += "gamePassed,";
                    fieldsValue += "@gamePassed,";
                    paramsayi++;
                }

                if (GameTime != null)
                {
                    fieldsName += "gameTime,";
                    fieldsValue += "@gameTime,";
                    paramsayi++;
                }

                if (GamePlayerCount != null)
                {
                    fieldsName += "registrationTime,";
                    fieldsValue += "@registrationTime,";
                    paramsayi++;
                }

                if (GameSubstituteCount != null)
                {
                    fieldsName += "gameSubstituteCount,";
                    fieldsValue += "@gameSubstituteCount,";    
                    paramsayi++;
                }

                fieldsName = fieldsName.Remove(fieldsName.Length - 1, 1);
                fieldsValue = fieldsValue.Remove(fieldsValue.Length - 1, 1);


            }
            else
            {
                if (SportId != null)
                {
                    fieldsName += "sportId=@sportId,";
                    paramsayi++;
                }
                if (UserId != null)
                {
                    fieldsName += "userId=@userId,";
                    paramsayi++;
                }

                if (SaloonId != null)
                {
                    fieldsName += "saloonId=@saloonId,";
                    paramsayi++;
                }

                if (GameNote != null)
                {
                    fieldsName += "gameNote=@gameNote,";
                    paramsayi++;
                }

                if (GamePassed != null)
                {
                    fieldsName += "gamePassed=@gamePassed,";
                    paramsayi++;
                }

                if (GameTime != null)
                {
                    fieldsName += "gameTime=@gameTime,";
                    paramsayi++;
                }

                if (GamePlayerCount != null)
                {
                    fieldsName += "gamePlayerCount=@gamePlayerCount,";
                    paramsayi++;
                }

                if (GameSubstituteCount != null)
                {
                    fieldsName += "gameSubstituteCount=@gameSubstituteCount,";
                    paramsayi++;
                }

                fieldsName = fieldsName.Remove(fieldsName.Length - 1, 1);

            }

            sqlparam = new SqlParameter[paramsayi];

            while (paramsayi > i)
            {
                if (SportId != null)
                {
                    sqlparam[i] = new SqlParameter("@sportId", SportId);
                    i++;
                }
                if (UserId != null)
                {
                    sqlparam[i] = new SqlParameter("@userId", UserId);
                    i++;
                }

                if (SaloonId != null)
                {
                    sqlparam[i] = new SqlParameter("@saloonId", SaloonId);
                    i++;
                }

                if (GameNote != null)
                {
                    sqlparam[i] = new SqlParameter("@gameNote", GameNote);
                    i++;
                }

                if (GamePassed != null)
                {
                    sqlparam[i] = new SqlParameter("@gamePassed", GamePassed);
                    i++;
                }

                if (GameTime != null)
                {
                    sqlparam[i] = new SqlParameter("@gameTime", GameTime);
                    i++;
                }

                if (GamePlayerCount != null)
                {
                    sqlparam[i] = new SqlParameter("@gamePlayerCount", GamePlayerCount);
                    i++;
                }

                if (GameSubstituteCount != null)
                {
                    sqlparam[i] = new SqlParameter("@gameSubstituteCount", GameSubstituteCount);
                    i++;
                }

            }

            if (this.Id == 0)
            {
                sqlcum = "Insert INTO [GameTbl](" + fieldsName + ")Values(" + fieldsValue + ")";

                DatabaseOperations.ParameterOperation(sqlcum, sqlparam);
                this.Id = Convert.ToInt32(DatabaseOperations.dtb("select max(Id) from [GameTbl]").Rows[0][0]);
                return "1";
            }
            else
            {
                sqlcum = "UPDATE [GameTbl] SET " + fieldsName + " where Id =" + this.Id;
                DatabaseOperations.ParameterOperation(sqlcum, sqlparam);
                return "2";
            }


        }

        internal string Delete(string _sql, params SqlParameter[] paramss)
        {
            DatabaseOperations.ParameterOperation(_sql, paramss);
            return "3";
        }

        internal GameTblDAO Select(string sql_, params SqlParameter[] paramss)
        {

            GameTblDAO entity = new GameTblDAO();
            DataTable dt = (DataTable) DatabaseOperations.ParameterOperation(sql_, paramss);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();

            if (columnNames.Contains("id")) entity.Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
            if (columnNames.Contains("sportId")) entity.SportId = Convert.ToInt32(dt.Rows[0]["sportId"].ToString());
            if (columnNames.Contains("userId")) entity.UserId = Convert.ToInt32(dt.Rows[0]["userId"].ToString());
            if (columnNames.Contains("saloonId")) entity.SaloonId = Convert.ToInt32(dt.Rows[0]["saloonId"].ToString());
            if (columnNames.Contains("gameNote")) entity.GameNote = dt.Rows[0]["gameNote"].ToString();
            if (columnNames.Contains("gamePassed")) entity.GamePassed = Boolean.TryParse(dt.Rows[0]["gamePassed"].ToString(), out b) ? new Boolean?(b) : null;
            if (columnNames.Contains("gameTime")) entity.GameTime = DateTime.TryParse(dt.Rows[0]["gameTime"].ToString(), out dti) ? new DateTime?(dti) : null;
            if (columnNames.Contains("gamePlayerCount")) entity.GamePlayerCount = Int32.TryParse(dt.Rows[0]["gamePlayerCount"].ToString(), out ii) ? new int?(ii) : null;
            if (columnNames.Contains("gameSubstituteCount")) entity.GameSubstituteCount = Int32.TryParse(dt.Rows[0]["gameSubstituteCount"].ToString(), out ii) ? new int?(ii) : null;

            return entity;
        } // okuma işlemi bitiyor

        internal List<GameTblDAO> DataSource(string sql_, params SqlParameter[] paramss)
        {

            List<GameTblDAO> list = new List<GameTblDAO>();
            DataTable dt;
            if (paramss == null)
                dt = (DataTable) DatabaseOperations.dtb(sql_);
            else
                dt = (DataTable) DatabaseOperations.ParameterOperation(sql_, paramss);


            string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
            foreach (DataRow r in dt.Rows)
            {
                GameTblDAO entity = new GameTblDAO();

                if (columnNames.Contains("id")) entity.Id = Convert.ToInt32(r["id"].ToString());
                if (columnNames.Contains("sportId")) entity.SportId = Int32.TryParse(r["sportId"].ToString(), out ii) ? new int?(ii) : null;
                if (columnNames.Contains("userId")) entity.UserId = Int32.TryParse(r["userId"].ToString(), out ii) ? new int?(ii) : null;
                if (columnNames.Contains("saloonId")) entity.SaloonId = Int32.TryParse(r["saloonId"].ToString(), out ii) ? new int?(ii) : null;
                if (columnNames.Contains("gameNote")) entity.GameNote = r["gameNote"].ToString(); 
                if (columnNames.Contains("gamePassed")) entity.GamePassed = Boolean.TryParse(r["gamePassed"].ToString(), out b) ? new Boolean?(b) : null;
                if (columnNames.Contains("gameTime")) entity.GameTime = (DateTime)(DateTime.TryParse(r["gameTime"].ToString(), out dti) ? new DateTime?(dti) : null);
                if (columnNames.Contains("gamePlayerCount")) entity.GamePlayerCount = Int32.TryParse(r["gamePlayerCount"].ToString(), out ii) ? new int?(ii) : null;
                if (columnNames.Contains("gameSubstituteCount")) entity.GameSubstituteCount = Int32.TryParse(r["gameSubstituteCount"].ToString(), out ii) ? new int?(ii) : null;

                list.Add(entity);
            }

            return list;
        }
    }
}

