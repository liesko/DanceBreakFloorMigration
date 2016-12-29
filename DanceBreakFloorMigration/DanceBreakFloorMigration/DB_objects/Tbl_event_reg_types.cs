using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_event_reg_types:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select name from tbl_event_reg_types_12 " +
                                                       "union select name from tbl_event_reg_types_16 " +
                                                       "union select name from tbl_event_reg_types_18 " +
                                                       "union select name from tbl_event_reg_types_21 " +
                                                       "union select name from tbl_event_reg_types_23");
            pMysql.Message = "tbl_event_reg_types - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_event_reg_types(name) values('"+dataReader["name"]+"');");
            }
            pPostgres.Message = "tbl_event_reg_types - extraction - FINISH";
        }
    }
}