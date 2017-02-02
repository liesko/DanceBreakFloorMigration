using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_event_types:IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select distinct id, name from tbl_event_types;");
            pMysql.Message = "tbl_event_types - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_event_types(id, name) values('" + dataReader[0] + "','"+ dataReader[1] + "')");
            }
            pPostgres.Message = "tbl_event_types - extraction - FINISH";
        }
    }
}