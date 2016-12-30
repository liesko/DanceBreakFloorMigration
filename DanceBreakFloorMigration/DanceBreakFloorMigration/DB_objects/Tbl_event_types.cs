using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_event_types:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select distinct id, name from tbl_event_types;");
            pMysql.Message = "tbl_event_types - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_event_types(event_types_id, name) values('" + dataReader[0] + "','"+ dataReader[1] + "')");
            }
            pPostgres.Message = "tbl_event_types - extraction - FINISH";
        }
    }
}