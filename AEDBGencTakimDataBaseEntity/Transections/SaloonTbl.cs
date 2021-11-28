using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using AEDBGencTakimDataBaseEntity.DAO;

namespace AEDBGencTakimDataBaseEntity.Transactions
{
    [Serializable]
    public class SaloonTbl : SaloonTblDAO
    {
 
        public string Save(SaloonTblDAO tbl)
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
                return new SaloonTblDAO().Delete("Delete From [SaloonTbl] where Id=@Id", new SqlParameter("@Id",Id));
            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
        public SaloonTblDAO Select() // tüm spor salonlarının listelenmesi 
        {
          return new SaloonTblDAO().Select("select * from [SaloonTbl]");
        }

        public List<SaloonTblDAO> DataSource()
        {
           return new SaloonTblDAO().DataSource("select * from [SaloonTbl]");
        }
    }
}

