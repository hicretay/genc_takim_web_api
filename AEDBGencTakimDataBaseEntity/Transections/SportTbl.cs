using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using AEDBGencTakimDataBaseEntity.DAO;

namespace AEDBGencTakimDataBaseEntity.Transactions
{
    [Serializable]
    public class SportTbl : SportTblDAO
    {
 
        public string Save(SportTblDAO tbl)
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
                return new SportTblDAO().Delete("Delete From [SportTbl] where Id=@Id", new SqlParameter("@Id",Id));
            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
        public SportTblDAO Select(int Id) // salon id değerine göre sporlar listelenecek
        {
          return new SportTblDAO().Select("select * from [SportTbl] where Id=@Id", new SqlParameter("@Id",Id));
        }

        public List<SportTblDAO> DataSource()
        {
           return new SportTblDAO().DataSource("select * from [SportTbl]");
        }
    }
}

