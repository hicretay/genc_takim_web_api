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
                    fieldsName += "SaloonName,";
                    fieldsValue += "@SaloonName,";
                    paramsayi++;
                }

                if (SaloonFeature != null)
                {
                    fieldsName += "SaloonFeature,";
                    fieldsValue += "@SaloonFeature,";
                    paramsayi++;
                }

                if (SaloonAddress != null)
                {
                    fieldsName += "SaloonAddress,";
                    fieldsValue += "@SaloonAddress,";
                    paramsayi++;
                }

                fieldsName = fieldsName.Remove(fieldsName.Length - 1, 1);
                fieldsValue = fieldsValue.Remove(fieldsValue.Length - 1, 1);


            }
            else
            {
                if (SaloonName != null)
                {
                    fieldsName += "SaloonName=@SaloonName,";
                    paramsayi++;
                }
                if (SaloonFeature != null)
                {
                    fieldsName += "SaloonFeature=@SaloonFeature,";
                    paramsayi++;
                }

                if (SaloonAddress != null)
                {
                    fieldsName += "SaloonAddress=@SaloonAddress,";
                    paramsayi++;
                }

               
                fieldsName = fieldsName.Remove(fieldsName.Length - 1, 1);

            }

            sqlparam = new SqlParameter[paramsayi];

            while (paramsayi > i)
            {
                if (SaloonName != null)
                {
                    sqlparam[i] = new SqlParameter("@SaloonName", SaloonName);
                    i++;
                }
                if (SaloonFeature != null)
                {
                    sqlparam[i] = new SqlParameter("@SaloonFeature", SaloonFeature);
                    i++;
                }

                if (SaloonAddress != null)
                {
                    sqlparam[i] = new SqlParameter("@SaloonAddress", SaloonAddress);
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

            if (columnNames.Contains("Id")) entity.Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
            if (columnNames.Contains("SaloonName")) entity.SaloonName = dt.Rows[0]["SaloonName"].ToString();
            if (columnNames.Contains("SaloonFeature")) entity.SaloonFeature = dt.Rows[0]["SaloonFeature"].ToString();
            if (columnNames.Contains("SaloonAddress")) entity.SaloonAddress = dt.Rows[0]["SaloonAddress"].ToString();

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

                if (columnNames.Contains("Id")) entity.Id = Convert.ToInt32(r["Id"].ToString());
                if (columnNames.Contains("SaloonName")) entity.SaloonName = r["SaloonName"].ToString();
                if (columnNames.Contains("SaloonFeature")) entity.SaloonFeature = r["SaloonFeature"].ToString();
                if (columnNames.Contains("SaloonAddress")) entity.SaloonAddress = r["SaloonAddress"].ToString();

                list.Add(entity);
            }

            return list;
        }
    }
}

