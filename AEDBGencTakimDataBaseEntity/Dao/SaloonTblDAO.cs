using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace AEDBGencTakimDataBaseEntity.DAO
{
    [Serializable]
    public class SaloonTblDAO : AEDBGencTakimDataBaseEntity.Entities.SaloonTblBase
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
                if (SaloonName != null)
                {
                    fieldsName += "saloonName,";
                    fieldsValue += "@saloonName,";
                    paramsayi++;
                }

                if (SaloonFeature != null)
                {
                    fieldsName += "saloonFeature,";
                    fieldsValue += "@saloonFeature,";
                    paramsayi++;
                }

                if (SaloonAddress != null)
                {
                    fieldsName += "saloonAddress,";
                    fieldsValue += "@saloonAddress,";
                    paramsayi++;
                }

                fieldsName = fieldsName.Remove(fieldsName.Length - 1, 1);
                fieldsValue = fieldsValue.Remove(fieldsValue.Length - 1, 1);


            }
            else
            {
                if (SaloonName != null)
                {
                    fieldsName += "saloonName=@saloonName,";
                    paramsayi++;
                }
                if (SaloonFeature != null)
                {
                    fieldsName += "saloonFeature=@saloonFeature,";
                    paramsayi++;
                }

                if (SaloonAddress != null)
                {
                    fieldsName += "saloonAddress=@saloonAddress,";
                    paramsayi++;
                }

               
                fieldsName = fieldsName.Remove(fieldsName.Length - 1, 1);

            }

            sqlparam = new SqlParameter[paramsayi];

            while (paramsayi > i)
            {
                if (SaloonName != null)
                {
                    sqlparam[i] = new SqlParameter("@saloonName", SaloonName);
                    i++;
                }
                if (SaloonFeature != null)
                {
                    sqlparam[i] = new SqlParameter("@saloonFeature", SaloonFeature);
                    i++;
                }

                if (SaloonAddress != null)
                {
                    sqlparam[i] = new SqlParameter("@saloonAddress", SaloonAddress);
                    i++;
                }

              
            }

            if (this.Id == 0)
            {
                sqlcum = "Insert INTO [SaloonTbl](" + fieldsName + ")Values(" + fieldsValue + ")";

                DatabaseOperations.ParameterOperation(sqlcum, sqlparam);
                this.Id = Convert.ToInt32(DatabaseOperations.dtb("select max(Id) from [SaloonTbl]").Rows[0][0]);
                return "1";
            }
            else
            {
                sqlcum = "UPDATE [SaloonTbl] SET " + fieldsName + " where Id =" + this.Id;
                DatabaseOperations.ParameterOperation(sqlcum, sqlparam);
                return "2";
            }


        }

        internal string Delete(string _sql, params SqlParameter[] paramss)
        {
            DatabaseOperations.ParameterOperation(_sql, paramss);
            return "3";
        }

        internal SaloonTblDAO Select(string sql_, params SqlParameter[] paramss)
        {

            SaloonTblDAO entity = new SaloonTblDAO();
            DataTable dt = (DataTable) DatabaseOperations.ParameterOperation(sql_, paramss);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();

            if (columnNames.Contains("id")) entity.Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
            if (columnNames.Contains("saloonName")) entity.SaloonName = dt.Rows[0]["saloonName"].ToString();
            if (columnNames.Contains("saloonFeature")) entity.SaloonFeature = dt.Rows[0]["saloonFeature"].ToString();
            if (columnNames.Contains("saloonAddress")) entity.SaloonAddress = dt.Rows[0]["saloonAddress"].ToString();

            return entity;
        } // okuma işlemi bitiyor

        internal List<SaloonTblDAO> DataSource(string sql_, params SqlParameter[] paramss)
        {

            List<SaloonTblDAO> list = new List<SaloonTblDAO>();
            DataTable dt;
            if (paramss == null)
                dt = (DataTable) DatabaseOperations.dtb(sql_);
            else
                dt = (DataTable) DatabaseOperations.ParameterOperation(sql_, paramss);


            string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
            foreach (DataRow r in dt.Rows)
            {
                SaloonTblDAO entity = new SaloonTblDAO();

                if (columnNames.Contains("id")) entity.Id = Convert.ToInt32(r["id"].ToString());
                if (columnNames.Contains("saloonName")) entity.SaloonName = r["saloonName"].ToString();
                if (columnNames.Contains("saloonFeature")) entity.SaloonFeature = r["saloonFeature"].ToString();
                if (columnNames.Contains("saloonAddress")) entity.SaloonAddress = r["saloonAddress"].ToString();

                list.Add(entity);
            }

            return list;
        }
    }
}

