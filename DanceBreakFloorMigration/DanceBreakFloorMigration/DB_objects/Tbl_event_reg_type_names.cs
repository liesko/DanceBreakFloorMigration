using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_event_reg_type_names : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("SELECT name FROM tbl_event_reg_types_12 union " +
                                                       "SELECT name FROM tbl_event_reg_types_16 union " +
                                                       "SELECT name FROM tbl_event_reg_types_18 union " +
                                                       "SELECT name FROM tbl_event_reg_types_21 union " +
                                                       "SELECT name FROM tbl_event_reg_types_23");

            pMysql.Message = "Tbl_event_reg_type_names - extraction - START";
            int counter = 0;
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into Tbl_event_reg_type_names(id, name) " +
                                 "values(" + ++counter + ",'"+dataReader["name"]+"');");
            }
            pPostgres.Message = "Tbl_event_reg_type_names - extraction - FINISH";
        }
    }
}