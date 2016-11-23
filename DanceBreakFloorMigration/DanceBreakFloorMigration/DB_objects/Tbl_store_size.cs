using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_store_size: IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select id, size from store_sizes;");
            pMysql.Message = "tbl_store_sizes (from store_size)- extraction - START";
            int counter = 0;
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_store_sizes(store_sizes_id, size) values('" + dataReader[0] + "','" + dataReader[1] + "')");
            }
            pPostgres.Message = "tbl_store_sizes - extraction - FINISH";
        }
    }
}