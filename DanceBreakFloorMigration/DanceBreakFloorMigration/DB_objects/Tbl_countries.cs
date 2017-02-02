using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_countries: IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select id, name, abbr from tbl_countries;");
            pMysql.Message = "tbl_countries (from tbl_countries)- extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_countries(id, name, abbr) values('" + dataReader[0] + "','" + dataReader[1].ToString().Replace("'","''") + "','" 
                    + dataReader[2] + "')"); // PROBLEM WITH NULL????
            }
            pPostgres.Message = "tbl_countries - extraction - FINISH";
        }
    }
}