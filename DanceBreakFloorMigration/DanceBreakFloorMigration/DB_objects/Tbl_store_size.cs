using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_store_size: IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select id, size from store_sizes;");
            pMysql.Message = "tbl_store_sizes (from store_size)- extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_store_sizes(id, size) values('" + dataReader[0] + "','" + dataReader[1] + "')");
            }
            pPostgres.Message = "tbl_store_sizes - extraction - FINISH";
        }
    }
}