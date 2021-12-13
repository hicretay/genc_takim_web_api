using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace AEDBGencTakimDataBaseEntity.DAO
{
    [Serializable]
    public class GameViewDAO : AEDBGencTakimDataBaseEntity.Entities.GameViewBase
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
                if (GameNote != null)
                {
                    fieldsName += "GameNote,";
                    fieldsValue += "@GameNote,";
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

                if (GameTime != null)
                {
                    fieldsName += "GameTime,";
                    fieldsValue += "@GameTime,";
                    paramsayi++;
                }

                if (SaloonId != null)
                {
                    fieldsName += "SaloonId,";
                    fieldsValue += "@SaloonId,";
                    paramsayi++;
                }

                if (UserId != null)
                {
                    fieldsName += "UserId,";
                    fieldsValue += "@UserId,";
                    paramsayi++;
                }

                if (MaxPlayerCount != null)
                {
                    fieldsName += "MaxPlayerCount,";
                    fieldsValue += "@MaxPlayerCount,";    
                    paramsayi++;
                }
                if (MaxSubstituteCount != null)
                {
                    fieldsName += "MaxSubstituteCount,";
                    fieldsValue += "@MaxSubstituteCount,";
                    paramsayi++;
                }
                if (SportName != null)
                {
                    fieldsName += "SportName,";
                    fieldsValue += "@SportName,";
                    paramsayi++;
                }
                if (SaloonAddress != null)
                {
                    fieldsName += "SaloonAddress,";
                    fieldsValue += "@SaloonAddress,";
                    paramsayi++;
                }
                if (SaloonFeature != null)
                {
                    fieldsName += "SaloonFeature,";
                    fieldsValue += "@SaloonFeature,";
                    paramsayi++;
                }
                if (SaloonName != null)
                {
                    fieldsName += "SaloonName,";
                    fieldsValue += "@SaloonName,";
                    paramsayi++;
                }
                if (IsPassed != null)
                {
                    fieldsName += "IsPassed,";
                    fieldsValue += "@IsPassed,";
                    paramsayi++;
                }

                fieldsName = fieldsName.Remove(fieldsName.Length - 1, 1);
                fieldsValue = fieldsValue.Remove(fieldsValue.Length - 1, 1);


            }
            else
            {
                if (GameNote != null)
                {
                    fieldsName += "GameNote=@GameNote,";
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

                if (GameTime != null)
                {
                    fieldsName += "GameTime=@GameTime,";
                    paramsayi++;
                }

                if (SaloonId != null)
                {
                    fieldsName += "SaloonId=@SaloonId,";
                    paramsayi++;
                }

                if (UserId != null)
                {
                    fieldsName += "UserId=@UserId,";
                    paramsayi++;
                }

                if (MaxPlayerCount != null)
                {
                    fieldsName += "MaxPlayerCount=@MaxPlayerCount,";
                    paramsayi++;
                }

                if (MaxSubstituteCount != null)
                {
                    fieldsName += "MaxSubstituteCount=@MaxSubstituteCount,";
                    paramsayi++;
                }
                if (SportName != null)
                {
                    fieldsName += "SportName=@SportName,";
                    paramsayi++;
                }

                if (SaloonAddress != null)
                {
                    fieldsName += "SaloonAddress=@SaloonAddress,";
                    paramsayi++;
                }

                if (SaloonFeature != null)
                {
                    fieldsName += "SaloonFeature=@SaloonFeature,";
                    paramsayi++;
                }
                if (SaloonName != null)
                {
                    fieldsName += "SaloonName=@SaloonName,";
                    paramsayi++;
                }
                if (IsPassed != null)
                {
                    fieldsName += "IsPassed=@IsPassed,";
                    paramsayi++;
                }

                fieldsName = fieldsName.Remove(fieldsName.Length - 1, 1);

            }

            sqlparam = new SqlParameter[paramsayi];

            while (paramsayi > i)
            {
                if (GameNote != null)
                {
                    sqlparam[i] = new SqlParameter("@GameNote", GameNote);
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

                if (GameTime != null)
                {
                    sqlparam[i] = new SqlParameter("@GameTime", GameTime);
                    i++;
                }

                if (SaloonId != null)
                {
                    sqlparam[i] = new SqlParameter("@SaloonId", SaloonId);
                    i++;
                }

                if (UserId != null)
                {
                    sqlparam[i] = new SqlParameter("@UserId", UserId);
                    i++;
                }

                if (MaxPlayerCount != null)
                {
                    sqlparam[i] = new SqlParameter("@MaxPlayerCount", MaxPlayerCount);
                    i++;
                }

                if (MaxSubstituteCount != null)
                {
                    sqlparam[i] = new SqlParameter("@MaxSubstituteCount", MaxSubstituteCount);
                    i++;
                }
                if (SportName != null)
                {
                    sqlparam[i] = new SqlParameter("@SportName", SportName);
                    i++;
                }

                if (SaloonAddress != null)
                {
                    sqlparam[i] = new SqlParameter("@SaloonAddress", SaloonAddress);
                    i++;
                }

                if (SaloonFeature != null)
                {
                    sqlparam[i] = new SqlParameter("@SaloonFeature", SaloonFeature);
                    i++;
                }

                if (SaloonName != null)
                {
                    sqlparam[i] = new SqlParameter("@SaloonName", SaloonName);
                    i++;
                }

                if (IsPassed != null)
                {
                    sqlparam[i] = new SqlParameter("@IsPassed", IsPassed);
                    i++;
                }

            }

            if (this.Id == 0)
            {
                sqlcum = "Insert INTO [GameView](" + fieldsName + ")Values(" + fieldsValue + ")";

                DatabaseOperations.ParameterOperation(sqlcum, sqlparam);
                this.Id = Convert.ToInt32(DatabaseOperations.dtb("select max(Id) from [GameView]").Rows[0][0]);
                return "1";
            }
            else
            {
                sqlcum = "UPDATE [GameView] SET " + fieldsName + " where Id =" + this.Id;
                DatabaseOperations.ParameterOperation(sqlcum, sqlparam);
                return "2";
            }


        }

        internal string Delete(string _sql, params SqlParameter[] paramss)
        {
            DatabaseOperations.ParameterOperation(_sql, paramss);
            return "3";
        }

        internal GameViewDAO Select(string sql_, params SqlParameter[] paramss)
        {

            GameViewDAO entity = new GameViewDAO();
            DataTable dt = (DataTable) DatabaseOperations.ParameterOperation(sql_, paramss);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();

            if (columnNames.Contains("Id")) entity.Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
            if (columnNames.Contains("GameNote")) entity.GameNote = dt.Rows[0]["GameNote"].ToString();
            if (columnNames.Contains("GamePlayerCount")) entity.GamePlayerCount = Int32.TryParse(dt.Rows[0]["GamePlayerCount"].ToString(), out ii) ? new int?(ii) : null;
            if (columnNames.Contains("GameSubstituteCount")) entity.GameSubstituteCount = Int32.TryParse(dt.Rows[0]["GameSubstituteCount"].ToString(), out ii) ? new int?(ii) : null;
            if (columnNames.Contains("GameTime")) entity.GameTime = DateTime.TryParse(dt.Rows[0]["GameTime"].ToString(), out dti) ? new DateTime?(dti) : null;
            if (columnNames.Contains("SaloonId")) entity.SaloonId = Convert.ToInt32(dt.Rows[0]["SaloonId"].ToString());
            if (columnNames.Contains("UserId")) entity.UserId = Convert.ToInt32(dt.Rows[0]["UserId"].ToString());
            if (columnNames.Contains("MaxPlayerCount")) entity.MaxPlayerCount = Int32.TryParse(dt.Rows[0]["MaxPlayerCount"].ToString(), out ii) ? new int?(ii) : null;
            if (columnNames.Contains("MaxSubstituteCount")) entity.MaxSubstituteCount = Int32.TryParse(dt.Rows[0]["MaxSubstituteCount"].ToString(), out ii) ? new int?(ii) : null;
            if (columnNames.Contains("SportName")) entity.SportName = dt.Rows[0]["SportName"].ToString();
            if (columnNames.Contains("SaloonAddress")) entity.SaloonAddress = dt.Rows[0]["SaloonAddress"].ToString();
            if (columnNames.Contains("SaloonFeature")) entity.SaloonFeature = dt.Rows[0]["SaloonFeature"].ToString();
            if (columnNames.Contains("SaloonName")) entity.SaloonName = dt.Rows[0]["SaloonName"].ToString();
            if (columnNames.Contains("IsPassed")) entity.IsPassed = Boolean.TryParse(dt.Rows[0]["IsPassed"].ToString(), out b) ? new Boolean?(b) : null;




            return entity;
        } // okuma işlemi bitiyor

        internal List<GameViewDAO> DataSource(string sql_, params SqlParameter[] paramss)
        {

            List<GameViewDAO> list = new List<GameViewDAO>();
            DataTable dt;
            if (paramss == null)
                dt = (DataTable) DatabaseOperations.dtb(sql_);
            else
                dt = (DataTable) DatabaseOperations.ParameterOperation(sql_, paramss);


            string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
            foreach (DataRow r in dt.Rows)
            {
                GameViewDAO entity = new GameViewDAO();

                if (columnNames.Contains("Id")) entity.Id = Convert.ToInt32(r["Id"].ToString());
                if (columnNames.Contains("GameNote")) entity.GameNote = r["GameNote"].ToString();
                if (columnNames.Contains("GamePlayerCount")) entity.GamePlayerCount = Int32.TryParse(r["GamePlayerCount"].ToString(), out ii) ? new int?(ii) : null;
                if (columnNames.Contains("GameSubstituteCount")) entity.GameSubstituteCount = Int32.TryParse(r["GameSubstituteCount"].ToString(), out ii) ? new int?(ii) : null;
                if (columnNames.Contains("GameTime")) entity.GameTime = DateTime.TryParse(r["GameTime"].ToString(), out dti) ? new DateTime?(dti) : null;
                if (columnNames.Contains("SaloonId")) entity.SaloonId = Convert.ToInt32(r["SaloonId"].ToString());
                if (columnNames.Contains("UserId")) entity.UserId = Convert.ToInt32(r["UserId"].ToString());
                if (columnNames.Contains("MaxPlayerCount")) entity.MaxPlayerCount = Int32.TryParse(r["MaxPlayerCount"].ToString(), out ii) ? new int?(ii) : null;
                if (columnNames.Contains("MaxSubstituteCount")) entity.MaxSubstituteCount = Int32.TryParse(r["MaxSubstituteCount"].ToString(), out ii) ? new int?(ii) : null;
                if (columnNames.Contains("SportName")) entity.SportName = r["SportName"].ToString();
                if (columnNames.Contains("SaloonAddress")) entity.SaloonAddress = r["SaloonAddress"].ToString();
                if (columnNames.Contains("SaloonFeature")) entity.SaloonFeature = r["SaloonFeature"].ToString();
                if (columnNames.Contains("SaloonName")) entity.SaloonName = r["SaloonName"].ToString();
                if (columnNames.Contains("IsPassed")) entity.IsPassed = Boolean.TryParse(r["IsPassed"].ToString(), out b) ? new Boolean?(b) : null;

                list.Add(entity);
            }

            return list;
        }
    }
}

