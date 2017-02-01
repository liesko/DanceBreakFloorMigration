using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_routine_types:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select id, name from tbl_routine_types;");
            pMysql.Message = "tbl_routine_types - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_routine_types(id, name) " +
                                 "values(" + dataReader[0] + ",'" + dataReader[1] + "')");
            }
            pPostgres.Insert("insert into tbl_routine_types(id, name) values(0,'Nothing');");
            pPostgres.Message = "tbl_routine_types - extraction - FINISH";
        }
    }
}