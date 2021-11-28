using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace AEDBGencTakimDataBaseEntity.DAO
{
    [Serializable]
    public class SportTblDAO : AEDBGencTakimDataBaseEntity.Entities.SportTblBase
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
                if (SportName != null)
                {
                    fieldsName += "sportName,";
                    fieldsValue += "@sportName,";
                    paramsayi++;
                }

                if (MaxPlayerCount != null)
                {
                    fieldsName += "maxPlayerCount,";
                    fieldsValue += "@maxPlayerCount,";
                    paramsayi++;
                }

                if (MaxSubstituteCount != null)
                {
                    fieldsName += "maxSubstituteCount,";
                    fieldsValue += "@maxSubstituteCount,";
                    paramsayi++;
                }

                fieldsName = fieldsName.Remove(fieldsName.Length - 1, 1);
                fieldsValue = fieldsValue.Remove(fieldsValue.Length - 1, 1);


            }
            else
            {
                if (SportName != null)
                {
                    fieldsName += "sportName=@sportName,";
                    paramsayi++;
                }
                if (MaxPlayerCount != null)
                {
                    fieldsName += "maxPlayerCount=@maxPlayerCount,";
                    paramsayi++;
                }

                if (MaxSubstituteCount != null)
                {
                    fieldsName += "maxSubstituteCount=@maxSubstituteCount,";
                    paramsayi++;
                }

               
                fieldsName = fieldsName.Remove(fieldsName.Length - 1, 1);

            }

            sqlparam = new SqlParameter[paramsayi];

            while (paramsayi > i)
            {
                if (SportName != null)
                {
                    sqlparam[i] = new SqlParameter("@sportName", SportName);
                    i++;
                }
                if (MaxPlayerCount != null)
                {
                    sqlparam[i] = new SqlParameter("@maxPlayerCount", MaxPlayerCount);
                    i++;
                }

                if (MaxSubstituteCount != null)
                {
                    sqlparam[i] = new SqlParameter("@maxSubstituteCount", MaxSubstituteCount);
                    i++;
                }

              
            }

            if (this.Id == 0)
            {
                sqlcum = "Insert INTO [SportTbl](" + fieldsName + ")Values(" + fieldsValue + ")";

                DatabaseOperations.ParameterOperation(sqlcum, sqlparam);
                this.Id = Convert.ToInt32(DatabaseOperations.dtb("select max(Id) from [SportTbl]").Rows[0][0]);
                return "1";
            }
            else
            {
                sqlcum = "UPDATE [SportTbl] SET " + fieldsName + " where Id =" + this.Id;
                DatabaseOperations.ParameterOperation(sqlcum, sqlparam);
                return "2";
            }


        }

        internal string Delete(string _sql, params SqlParameter[] paramss)
        {
            DatabaseOperations.ParameterOperation(_sql, paramss);
            return "3";
        }

        internal SportTblDAO Select(string sql_, params SqlParameter[] paramss)
        {

            SportTblDAO entity = new SportTblDAO();
            DataTable dt = (DataTable) DatabaseOperations.ParameterOperation(sql_, paramss);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();

            if (columnNames.Contains("id")) entity.Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
            if (columnNames.Contains("sportName")) entity.SportName = dt.Rows[0]["sportName"].ToString();
            if (columnNames.Contains("maxPlayerCount")) entity.MaxPlayerCount = Int32.TryParse(dt.Rows[0]["maxPlayerCount"].ToString(), out ii) ? new int?(ii) : null;
            if (columnNames.Contains("maxSubstituteCount")) entity.MaxSubstituteCount = Int32.TryParse(dt.Rows[0]["maxSubstituteCount"].ToString(), out ii) ? new int?(ii) : null;

            return entity;
        } // okuma işlemi bitiyor

        internal List<SportTblDAO> DataSource(string sql_, params SqlParameter[] paramss)
        {

            List<SportTblDAO> list = new List<SportTblDAO>();
            DataTable dt;
            if (paramss == null)
                dt = (DataTable) DatabaseOperations.dtb(sql_);
            else
                dt = (DataTable) DatabaseOperations.ParameterOperation(sql_, paramss);


            string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
            foreach (DataRow r in dt.Rows)
            {
                SportTblDAO entity = new SportTblDAO();

                if (columnNames.Contains("id")) entity.Id = Convert.ToInt32(r["id"].ToString());
                if (columnNames.Contains("sportName")) entity.SportName = r["sportName"].ToString();
                if (columnNames.Contains("maxPlayerCount")) entity.MaxPlayerCount = Int32.TryParse(r["maxPlayerCount"].ToString(), out ii) ? new int?(ii) : null;
                if (columnNames.Contains("maxSubstituteCount")) entity.MaxSubstituteCount = Int32.TryParse(r["maxSubstituteCount"].ToString(), out ii) ? new int?(ii) : null;

                list.Add(entity);
            }

            return list;
        }
    }
}

