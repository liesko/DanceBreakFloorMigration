using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_states: IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select id, name, abbreviation, countryid from tbl_states;");
            pMysql.Message = "tbl_states (from tbl_states)- extraction - START";
            string countryid = "null";
            while (dataReader.Read())
            {
                countryid = (dataReader[3].ToString() == "") ? "null" : "'" + dataReader[3].ToString() + "'";
                pPostgres.Insert("insert into tbl_states(id,name,abbr,country_id) values('" + dataReader[0] + "','" + dataReader[1].ToString().Replace("'", "''") + "','"
                    + dataReader[2] + "'," + countryid + ")");
            }
            pPostgres.Message = "tbl_states - extraction - FINISH";
        }
    }
}