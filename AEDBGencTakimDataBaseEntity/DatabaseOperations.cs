using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for VeritabaniIslemleri
/// </summary>
/// 
namespace AEDBGencTakimDataBaseEntity
{
   

    public class DatabaseOperations
    {
      public static string CS="";
        public static DataTable dtb(string sqlcum)
        {

            SqlConnection cn;
            SqlDataAdapter da;
            DataTable table = new DataTable();
            cn = new SqlConnection(CS);
            da = new SqlDataAdapter(sqlcum, cn);
            da.Fill(table);
            return table;

        }
        public static DataTable ParameterOperation(string sql, params SqlParameter[] parameters)
        {
            SqlConnection eris;
            SqlDataAdapter adapte;
            DataTable geridonen = new DataTable();
            eris = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand(sql, eris);
            cmd.Parameters.AddRange(parameters);
            adapte = new SqlDataAdapter(cmd);
            adapte.Fill(geridonen);
            return geridonen;
        }
public static DataSet RunStoredProcedure(string ProcedureName, params SqlParameter[] parametres)
        {
            SqlConnection cn;
            SqlCommand scom = new SqlCommand();
            SqlDataAdapter adapte;
            DataSet geridonen = new DataSet();
            cn = new SqlConnection(CS);
            cn.Open();
            scom.Connection = cn;
            scom.CommandType = CommandType.StoredProcedure;
            scom.CommandText = ProcedureName;
            if (parametres.Length != 0 && parametres[0] != null)
                scom.Parameters.AddRange(parametres);
            adapte = new SqlDataAdapter(scom);
            adapte.Fill(geridonen);
            cn.Close();
            return geridonen;

        }

        public static string TransectionReturn(object result, object resultText)
        {
            var s = "";
            switch (result)
            {
                case "1": s = resultText.ToString() + " Kaydedildi."; break;
                case "2": s = resultText.ToString() + " Güncellendi."; break;
                case "3": s = resultText.ToString() + " Silindi."; break;
            }
            return s;
        }

    }
}
