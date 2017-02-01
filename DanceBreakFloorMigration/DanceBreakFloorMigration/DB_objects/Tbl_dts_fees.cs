using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_dts_fees : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_dts_fees;");
            pMysql.Message = "tbl_dts_fees - extraction - START ";
            while (dataReader.Read())
            {             
                pPostgres.Insert("insert into tbl_dts_fees(id,offername,offerval) " +
                                 "values("+dataReader["id"]+",'"+dataReader["offername"] +"', "+dataReader["offerval"] +");");
            }

            pPostgres.Message = "tbl_dts_fees - extraction - FINISH";
        }
    }
}