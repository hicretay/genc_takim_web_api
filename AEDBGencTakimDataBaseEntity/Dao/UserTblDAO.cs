using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace AEDBGencTakimDataBaseEntity.DAO
{
    [Serializable]
    public class UserTblDAO : AEDBGencTakimDataBaseEntity.Entities.UserTblBase
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
                if (UserName != null)
                {
                    fieldsName += "UserName,";
                    fieldsValue += "@UserName,";
                    paramsayi++;
                }

                if (UserEmail != null)
                {
                    fieldsName += "UserEmail,";
                    fieldsValue += "@UserEmail,";
                    paramsayi++;
                }

                if (UserPassword != null)
                {
                    fieldsName += "UserPassword,";
                    fieldsValue += "@UserPassword,";
                    paramsayi++;
                }

                if (Active != null)
                {
                    fieldsName += "Active,";
                    fieldsValue += "@Active,";
                    paramsayi++;
                }

                if (UserTelephone != null)
                {
                    fieldsName += "UserTelephone,";
                    fieldsValue += "@UserTelephone,";
                    paramsayi++;
                }

                if (Birthdate != 0)
                {
                    fieldsName += "Birthdate,";
                    fieldsValue += "@Birthdate,";
                    paramsayi++;
                }

                if (RegistrationTime != null)
                {
                    fieldsName += "RegistrationTime,";
                    fieldsValue += "@RegistrationTime,";
                    paramsayi++;
                }

                fieldsName = fieldsName.Remove(fieldsName.Length - 1, 1);
                fieldsValue = fieldsValue.Remove(fieldsValue.Length - 1, 1);


            }
            else
            {
                if (UserName != null)
                {
                    fieldsName += "UserName=@UserName,";
                    paramsayi++;
                }
                if (UserEmail != null)
                {
                    fieldsName += "UserEmail=@UserEmail,";
                    paramsayi++;
                }

                if (UserPassword != null)
                {
                    fieldsName += "UserPassword=@UserPassword,";
                    paramsayi++;
                }

                if (Active != null)
                {
                    fieldsName += "Active=@Active,";
                    paramsayi++;
                }

                if (UserTelephone != null)
                {
                    fieldsName += "UserTelephone=@UserTelephone,";
                    paramsayi++;
                }

                if (Birthdate != 0)
                {
                    fieldsName += "Birthdate=@Birthdate,";
                    paramsayi++;
                }

                if (RegistrationTime != null)
                {
                    fieldsName += "RegistrationTime=@RegistrationTime,";
                    paramsayi++;
                }

                fieldsName = fieldsName.Remove(fieldsName.Length - 1, 1);



            }

            sqlparam = new SqlParameter[paramsayi];

            while (paramsayi > i)
            {
                if (UserName != null)
                {
                    sqlparam[i] = new SqlParameter("@UserName", UserName);
                    i++;
                }
                if (UserEmail != null)
                {
                    sqlparam[i] = new SqlParameter("@UserEmail", UserEmail);
                    i++;
                }

                if (UserPassword != null)
                {
                    sqlparam[i] = new SqlParameter("@UserPassword", UserPassword);
                    i++;
                }

                if (Active != null)
                {
                    sqlparam[i] = new SqlParameter("@Active", Active);
                    i++;
                }

                if (UserTelephone != null)
                {
                    sqlparam[i] = new SqlParameter("@userTelephone", UserTelephone);
                    i++;
                }

                if (Birthdate != 0)
                {
                    sqlparam[i] = new SqlParameter("@Birthdate", Birthdate);
                    i++;
                }

                if (RegistrationTime != null)
                {
                    sqlparam[i] = new SqlParameter("@RegistrationTime", RegistrationTime);
                    i++;
                }

            }

            if (this.Id == 0)
            {
                sqlcum = "Insert INTO [UserTbl](" + fieldsName + ")Values(" + fieldsValue + ")";

                DatabaseOperations.ParameterOperation(sqlcum, sqlparam);
                this.Id = Convert.ToInt32(DatabaseOperations.dtb("select max(Id) from [UserTbl]").Rows[0][0]);
                return "1";
            }
            else
            {
                sqlcum = "UPDATE [UserTbl] SET " + fieldsName + " where Id =" + this.Id;
                DatabaseOperations.ParameterOperation(sqlcum, sqlparam);
                return "2";
            }


        }

        internal string Delete(string _sql, params SqlParameter[] paramss)
        {
            DatabaseOperations.ParameterOperation(_sql, paramss);
            return "3";
        }

        internal UserTblDAO Select(string sql_, params SqlParameter[] paramss)
        {

            UserTblDAO entity = new UserTblDAO();
            DataTable dt = (DataTable) DatabaseOperations.ParameterOperation(sql_, paramss);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();

            if (columnNames.Contains("Id")) entity.Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
            if (columnNames.Contains("UserName")) entity.UserName = dt.Rows[0]["UserName"].ToString();
            if (columnNames.Contains("UserEmail")) entity.UserEmail = dt.Rows[0]["UserEmail"].ToString();
            if (columnNames.Contains("UserPassword")) entity.UserPassword = dt.Rows[0]["UserPassword"].ToString();
            if (columnNames.Contains("Active")) entity.Active = Boolean.TryParse(dt.Rows[0]["Active"].ToString(),out b)? new Boolean?(b):null;
            if (columnNames.Contains("UserTelephone")) entity.UserTelephone = dt.Rows[0]["UserTelephone"].ToString();
            if (columnNames.Contains("Birthdate")) entity.Birthdate = Int32.TryParse(dt.Rows[0]["Birthdate"].ToString(), out ii) ? new int?(ii) : null;
            if (columnNames.Contains("RegistrationTime")) entity.RegistrationTime = DateTime.TryParse(dt.Rows[0]["RegistrationTime"].ToString(), out dti) ? new DateTime?(dti) : null;

            return entity;
        } // okuma işlemi bitiyor

        internal List<UserTblDAO> DataSource(string sql_, params SqlParameter[] paramss)
        {

            List<UserTblDAO> list = new List<UserTblDAO>();
            DataTable dt;
            if (paramss == null)
                dt = (DataTable) DatabaseOperations.dtb(sql_);
            else
                dt = (DataTable) DatabaseOperations.ParameterOperation(sql_, paramss);


            string[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
            foreach (DataRow r in dt.Rows)
            {
                UserTblDAO entity = new UserTblDAO();

                if (columnNames.Contains("Id")) entity.Id = Convert.ToInt32(r["Id"].ToString());
                if (columnNames.Contains("UserName")) entity.UserName = r["UserName"].ToString();
                if (columnNames.Contains("UserEmail")) entity.UserEmail = r["UserEmail"].ToString();
                if (columnNames.Contains("UserPassword")) entity.UserPassword = r["UserPassword"].ToString();
                if (columnNames.Contains("Active")) entity.Active = Boolean.TryParse(r["Active"].ToString(), out b) ? new Boolean?(b) : null;
                if (columnNames.Contains("UserTelephone")) entity.UserTelephone = r["UserTelephone"].ToString();
                if (columnNames.Contains("Birthdate")) entity.Birthdate = Int32.TryParse(r["Birthdate"].ToString(), out ii) ? new int?(ii) : null;
                if (columnNames.Contains("RegistrationTime")) entity.RegistrationTime =DateTime.TryParse(r["RegistrationTime"].ToString(), out dti) ? new DateTime?(dti) : null;

                list.Add(entity);
            }

            return list;
        }
    }
}

