using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_category:IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select distinct cast(name as char) from tbl_routine_categories_11 " +
                                                       "union select distinct cast(name as char) from tbl_routine_categories_14 " +
                                                       "union select distinct cast(name as char) from tbl_routine_categories_17 " +
                                                       "union select distinct cast(name as char) from tbl_routine_categories_2 " +
                                                       "union select distinct cast(name as char) from tbl_routine_categories_20 " +
                                                       "union select distinct cast(name as char) from tbl_routine_categories_22;");
            pMysql.Message = "tbl_category - extraction - START";
            int counter = 0;
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_category(id, name) values(" + ++counter + ",'" + dataReader[0] + "')");
            }
            pPostgres.Insert("insert into tbl_category(id, name) values(9,'Nothing');");
            pPostgres.Message = "tbl_category - extraction - FINISH";
        }
    }
}