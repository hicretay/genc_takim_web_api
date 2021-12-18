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
                    fieldsName += "SportId,";
                    fieldsValue += "@SportId,";
                    paramsayi++;
                }

                if (UserId != null)
                {
                    fieldsName += "UserId,";
                    fieldsValue += "@UserId,";
                    paramsayi++;
                }

                if (SaloonId != null)
                {
                    fieldsName += "SaloonId,";
                    fieldsValue += "@SaloonId,";
                    paramsayi++;
                }

                if (GameNote != null)
                {
                    fieldsName += "GameNote,";
                    fieldsValue += "@GameNote,";
                    paramsayi++;
                }

                if (GamePassed != null)
                {
                    fieldsName += "GamePassed,";
                    fieldsValue += "@GamePassed,";
                    paramsayi++;
                }

                if (GameTime != null)
                {
                    fieldsName += "GameTime,";
                    fieldsValue += "@GameTime,";
                    paramsayi++;
                }

                if (GamePlayerCount != null)
                {
                    fieldsName += "GamePlayerCount,";
                    fieldsValue += "@GamePlayerCount,";
                    paramsayi++;
                }

                if (GameSubstituteCount != null)
                {
                    fieldsName += "GameSubstituteCount,";
                    fieldsValue += "@GameSubstituteCount,";    
                    paramsayi++;
                }

                fieldsName = fieldsName.Remove(fieldsName.Length - 1, 1);
                fieldsValue = fieldsValue.Remove(fieldsValue.Length - 1, 1);


            }
            else
            {
                if (SportId != null)
                {
                    fieldsName += "SportId=@SportId,";
                    paramsayi++;
                }
                if (UserId != null)
                {
                    fieldsName += "UserId=@UserId,";
                    paramsayi++;
                }

                if (SaloonId != null)
                {
                    fieldsName += "SaloonId=@SaloonId,";
                    paramsayi++;
                }

                if (GameNote != null)
                {
                    fieldsName += "GameNote=@GameNote,";
                    paramsayi++;
                }

                if (GamePassed != null)
                {
                    fieldsName += "GamePassed=@GamePassed,";
                    paramsayi++;
                }

                if (GameTime != null)
                {
                    fieldsName += "GameTime=@GameTime,";
                    paramsayi++;
                }

                if (GamePlayerCount != null)
                {
                    fieldsName += "GamePlayerCount=@GamePlayerCount,";
                    paramsayi++;
                }

                if (GameSubstituteCount != null)
                {
                    fieldsName += "GameSubstituteCount=@GameSubstituteCount,";
                    paramsayi++;
                }

                fieldsName = fieldsName.Remove(fieldsName.Length - 1, 1);

            }

            sqlparam = new SqlParameter[paramsayi];

            while (paramsayi > i)
            {
                if (SportId != null)
                {
                    sqlparam[i] = new SqlParameter("@SportId", SportId);
                    i++;
                }
                if (UserId != null)
                {
                    sqlparam[i] = new SqlParameter("@UserId", UserId);
                    i++;
                }

                if (SaloonId != null)
                {
                    sqlparam[i] = new SqlParameter("@SaloonId", SaloonId);
                    i++;
                }

                if (GameNote != null)
                {
                    sqlparam[i] = new SqlParameter("@GameNote", GameNote);
                    i++;
                }

                if (GamePassed != null)
                {
                    sqlparam[i] = new SqlParameter("@GamePassed", GamePassed);
                    i++;
                }

                if (GameTime != null)
                {
                    sqlparam[i] = new SqlParameter("@GameTime", GameTime);
                    i++;
                }

                if (GamePlayerCount != null)
                {
                    sqlparam[i] = new SqlParameter("@GamePlayerCount", GamePlayerCount);
                    i++;
                }

                if (GameSubstituteCount != null)
                {
                    sqlparam[i] = new SqlParameter("@GameSubstituteCount", GameSubstituteCount);
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

            if (columnNames.Contains("Id")) entity.Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
            if (columnNames.Contains("SportId")) entity.SportId = Convert.ToInt32(dt.Rows[0]["SportId"].ToString());
            if (columnNames.Contains("UserId")) entity.UserId = Convert.ToInt32(dt.Rows[0]["UserId"].ToString());
            if (columnNames.Contains("SaloonId")) entity.SaloonId = Convert.ToInt32(dt.Rows[0]["SaloonId"].ToString());
            if (columnNames.Contains("GameNote")) entity.GameNote = dt.Rows[0]["GameNote"].ToString();
            if (columnNames.Contains("GamePassed")) entity.GamePassed = Boolean.TryParse(dt.Rows[0]["GamePassed"].ToString(), out b) ? new Boolean?(b) : null;
            if (columnNames.Contains("GameTime")) entity.GameTime = DateTime.TryParse(dt.Rows[0]["GameTime"].ToString(), out dti) ? new DateTime?(dti) : null;
            if (columnNames.Contains("GamePlayerCount")) entity.GamePlayerCount = Int32.TryParse(dt.Rows[0]["GamePlayerCount"].ToString(), out ii) ? new int?(ii) : null;
            if (columnNames.Contains("GameSubstituteCount")) entity.GameSubstituteCount = Int32.TryParse(dt.Rows[0]["GameSubstituteCount"].ToString(), out ii) ? new int?(ii) : null;

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

                if (columnNames.Contains("Id")) entity.Id = Convert.ToInt32(r["Id"].ToString());
                if (columnNames.Contains("SportId")) entity.SportId = Int32.TryParse(r["SportId"].ToString(), out ii) ? new int?(ii) : null;
                if (columnNames.Contains("UserId")) entity.UserId = Int32.TryParse(r["UserId"].ToString(), out ii) ? new int?(ii) : null;
                if (columnNames.Contains("SaloonId")) entity.SaloonId = Int32.TryParse(r["SaloonId"].ToString(), out ii) ? new int?(ii) : null;
                if (columnNames.Contains("GameNote")) entity.GameNote = r["GameNote"].ToString(); 
                if (columnNames.Contains("GamePassed")) entity.GamePassed = Boolean.TryParse(r["GamePassed"].ToString(), out b) ? new Boolean?(b) : null;
                if (columnNames.Contains("GameTime")) entity.GameTime = (DateTime)(DateTime.TryParse(r["GameTime"].ToString(), out dti) ? new DateTime?(dti) : null);
                if (columnNames.Contains("GamePlayerCount")) entity.GamePlayerCount = Int32.TryParse(r["GamePlayerCount"].ToString(), out ii) ? new int?(ii) : null;
                if (columnNames.Contains("GameSubstituteCount")) entity.GameSubstituteCount = Int32.TryParse(r["GameSubstituteCount"].ToString(), out ii) ? new int?(ii) : null;

                list.Add(entity);
            }

            return list;
        }
    }
}

