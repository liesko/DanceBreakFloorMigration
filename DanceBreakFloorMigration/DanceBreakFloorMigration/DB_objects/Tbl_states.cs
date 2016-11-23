using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_states: IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select id, name, abbreviation, countryid from tbl_states;");
            pMysql.Message = "tbl_states (from tbl_states)- extraction - START";
            int counter = 0;
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_states(state_id,name,abbr,country_id) values('" + dataReader[0] + "','" + dataReader[1].ToString().Replace("'", "''") + "','" 
                    + dataReader[2] + "','"+ dataReader[3] + "')");
            }
            pPostgres.Message = "tbl_countries - extraction - FINISH";
        }
    }
}